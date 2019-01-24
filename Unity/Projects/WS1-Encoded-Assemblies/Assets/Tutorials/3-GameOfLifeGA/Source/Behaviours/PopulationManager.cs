using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using SpatialSlur;

namespace RC3
{
    namespace WS2
    {
        public class PopulationManager : MonoBehaviour
        {
            private int _genSize = 3;
            private int _curCount = 0;
            private List<IDNAF> _matingPool = new List<IDNAF>();
            private CellStack[] _currentGeneration;
            private CellStack _currentStack;
            private bool _fitnessComplete = false;

            [SerializeField] private StackModel _model;
            [SerializeField] private StackAnalyser _analyser;
            [SerializeField] private CellStack _stackPrefab;
            [SerializeField] private SharedTextures _seeds;
            [SerializeField] private StackPopulation _population;

            bool _pause = false;
            bool _hideCurGen = false;

            /// <summary>
            /// 
            /// </summary>
            private void Awake()
            {
                _currentStack = _model.Stack;
                _currentGeneration = new CellStack[_genSize];
                _population.Reset();
                InitializeMatingPool();
            }


            /// <summary>
            /// 
            /// </summary>
            private void Update()
            {
                if (_pause == false)
                {
                    //check if stack is finished building

                    //if build not complete, leave function
                    if (_model.BuildComplete == false)
                    {
                        return;
                    }

                    //if stack building is complete, get fitness / update
                    if (_model.BuildComplete == true)
                    {
                        //calculate fitness
                        _analyser.Fitness();

                        //move the stack position
                        var generations = _population.Population.Count + 1;

                        //child of population manager
                        _currentStack.transform.parent = gameObject.transform;

                        Vector3 vector = new Vector3(2f * (_currentStack.RowCount) * (_curCount), 0, 2f * (_currentStack.ColumnCount));
                        _currentStack.SetPosition(vector);

                        //add stack to current generation
                        AddStackToGeneration(_currentStack);

                        //update the name and ui data text in the stack
                        _currentStack.SetName("GEN " + generations + " | STACK " + _curCount);
                        _currentStack.UpdateDataText();

                        _curCount++;

                        //if count == popsize recalculate the mating pool
                        if (_curCount == _genSize)
                        {
                            //add generation to the population history
                            AddGenToPopulation(_currentGeneration);

                            //UpdatePopulation()

                            //run natural selection to generate breeding pool
                            UpdateMatingPool();

                            //reset current population array
                            _currentGeneration = new CellStack[_genSize];

                            //reset popcounter
                            _curCount = 0;

                            //move population
                            Vector3 vec = new Vector3(0, 0, 2f * (_currentStack.ColumnCount));
                            foreach (var stack in _population.Population)
                            {
                                //stack.transform.localPosition += vec;
                                stack.MovePosition(vec);
                            }
                        }

                        //breed new dna from mating pool
                        IDNAF childdna = Breed();

                        //turn off/deactivate the stack
                        //_currentStack.gameObject.SetActive(false);

                        //reset the stack and insert new dna
                        _currentStack = Instantiate(_stackPrefab);
                        _currentStack.SetDNA(childdna);
                        _model.SetStack(_currentStack);

                        //synthesize 4 images from child gene 
                        Texture2D texture1 = _seeds[Mathf.RoundToInt(childdna.GetGene(0))];
                        Texture2D texture2 = _seeds[Mathf.RoundToInt(childdna.GetGene(1))];
                        Texture2D texture3 = _seeds[Mathf.RoundToInt(childdna.GetGene(2))];
                        Texture2D texture4 = _seeds[Mathf.RoundToInt(childdna.GetGene(3))];
                        Texture2D combined = ImageSynthesizer.CombineFour(texture1, texture2, texture3, texture4, _currentStack.RowCount, _currentStack.ColumnCount);

                        //place the synthesized image into the stack
                        _currentStack.SetSeed(combined);

                        //resets/initializes the model using the synthesized image
                        _model.ResetModel(combined);
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public bool Pause
            {
                get { return _pause; }
                set { _pause = value; }
            }

            /// <summary>
            /// Adds a stack to the current generation of stacks
            /// </summary>
            private void AddStackToGeneration(CellStack stack)
            {
                //add stack to current generation of stacks
                _currentGeneration[_curCount] = stack;
            }

            /// <summary>
            /// Adds the generation of stacks to the population and updates max and min population fitness
            /// </summary>
            private void AddGenToPopulation(CellStack[] generation)
            {
                //update min & max fitness of the population
                foreach (var stack in generation)
                {
                    if (stack.Fitness > _population.MaxFitness)
                    {
                        _population.MaxFitness = stack.Fitness;
                    }

                    if (stack.Fitness < _population.MinFitness)
                    {
                        _population.MinFitness = stack.Fitness;
                    }
                }
                //add generation of stacks to the population
                _population.AddGeneration(generation);

            }



            /// <summary>
            /// Initializes the mating pool
            /// </summary>
            private void InitializeMatingPool()
            {
                //initialize mating pool with random instances of dna
                _matingPool = new List<IDNAF>();
                for (int i = 0; i < _genSize; i++)
                {
                    _matingPool.Add(new DNAF());
                }
            }

            /// <summary>
            /// Updates the mating pool
            /// </summary>
            private void UpdateMatingPool()
            {
                //reset mating pool
                _matingPool.Clear();

                //get flattened stack population
                var population = _population.Population;
                //sort by fitness value (highest first - descending)
                var sortedList = population.OrderByDescending(o => (o.Fitness)).ToList();

                if (sortedList.Count < _genSize * 2)
                {
                    //add DNA to mating pool weighted by fitness value
                    int quantity = sortedList.Count;
                    float totalfitness = TotalFitness(sortedList, quantity);
                    for (int i = 0; i < quantity; i++)
                    {
                        int weightedQuantity = (int)((sortedList[i].Fitness / totalfitness) * 1000);
                        for (int j = 0; j < weightedQuantity; j++)
                        {
                            _matingPool.Add(sortedList[i].DNA);
                        }
                    }
                }

                else
                {
                    //add DNA to mating pool weighted by fitness value
                    int quantity = sortedList.Count / 2;
                    float totalfitness = TotalFitness(sortedList, quantity);
                    for (int i = 0; i < quantity; i++)
                    {
                        int weightedQuantity = (int)((sortedList[i].Fitness / totalfitness) * 1000);
                        for (int j = 0; j < weightedQuantity; j++)
                        {
                            _matingPool.Add(sortedList[i].DNA);
                        }
                    }
                }

            }

            /// <summary>
            /// Calculate total fitness from list of stacks and quantity of that list to include
            /// </summary>
            /// <param name="sortedfitnesslist"></param>
            /// <param name="quantity"></param>
            /// <returns></returns>
            private float TotalFitness(List<CellStack> sortedfitnesslist, int quantity)
            {
                float totfitness = 0;
                for (int i = 0; i < quantity; i++)
                {
                    totfitness += sortedfitnesslist[i].Fitness;
                }

                return totfitness;
            }

            /// <summary>
            /// Create child dna by breeding two parents from the mating pool
            /// </summary>
            /// <param name="dna1"></param>
            /// <param name="dna2"></param>
            /// <returns></returns>
            private IDNAF Breed()
            {
                IDNAF child = new DNAF();
                IDNAF parent1 = _matingPool[UnityEngine.Random.Range(0, _matingPool.Count)];
                IDNAF parent2 = _matingPool[UnityEngine.Random.Range(0, _matingPool.Count)];
                child.Crossover(parent1, parent2);
                return child;
            }

            /// <summary>
            /// 
            /// </summary>
            public StackPopulation Population
            {
                get { return _population; }
            }

            /// <summary>
            /// 
            /// </summary>
            public int GenSize
            {
                get { return _genSize; }
            }

            /// <summary>
            /// 
            /// </summary>
            public CellStack[] CurrentGeneration
            {
                get { return _currentGeneration; }
            }
        }
    }
}
