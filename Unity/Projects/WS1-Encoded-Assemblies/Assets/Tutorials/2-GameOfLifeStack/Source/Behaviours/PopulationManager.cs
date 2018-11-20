using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using SpatialSlur;

namespace RC3
{

    public class PopulationManager : MonoBehaviour
    {
        private int _popSize = 10;
        private int _popCount = 0;
        private int _generationCount = 0;
        private List<CellStack[]> _populationHistory = new List<CellStack[]>();
        private List<IDNAF> _matingPool = new List<IDNAF>();
        private CellStack[] _currentPopulation;

        [SerializeField] private StackModel _model;
        [SerializeField] private StackAnalyser _analyser;
        [SerializeField] private CellStack _stackPrefab;
        [SerializeField] private SharedTextures _seeds;
        private CellStack _currentStack;
        private CellStack _nextStack;

        private bool _fitnessComplete = false;

        //Current Population

        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            _currentStack = _model.Stack;
            _currentPopulation = new CellStack[_popSize];
            InitializeMatingPool();
        }


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {

            //check if stack is finished build / fitness 
            if (_model.BuildComplete == false)
            {
                return;
            }

            if (_model.BuildComplete == true)
            {
                //calculate fitness
                _analyser.Fitness();

                //move the stack position
                var generations = _populationHistory.Count + 1;
                Vector3 vector = new Vector3(1.5f * (_currentStack.RowCount) * (_popCount - 1), 0, 1.5f * (_currentStack.ColumnCount) * (generations + 1));
                _currentStack.transform.localPosition = vector;
                _currentStack.transform.parent = gameObject.transform;

                //add stack to current generation
                AddStackToPopulation(_currentStack);

                _popCount++;

                //if count == popsize recalculate the mating pool
                if (_popCount == _popSize)
                {
                    //add generation to the population history
                    AddPopulationToHistory(_currentPopulation);

                    //run natural selection to generate breeding pool
                    UpdateMatingPool();

                    //reset current population array
                    _currentPopulation = new CellStack[_popSize];

                    //reset popcounter
                    _popCount = 0;
                }

                //breed new dna from mating pool
                IDNAF childdna = Breed();

                //turn off stack
                _currentStack.gameObject.SetActive(false);

                //reset the stack and insert new dna
                _currentStack = Instantiate(_stackPrefab);
                _currentStack.SetDNA(childdna);
                _model.SetStack(_currentStack);

                //synthesize images 
                /*
                Debug.Log(Mathf.RoundToInt(childdna.GetGene(0)));
                Debug.Log(_model.Seeds[Mathf.RoundToInt(childdna.GetGene(0))]);

                Debug.Log(Mathf.RoundToInt(childdna.GetGene(1)));
                Debug.Log(_model.Seeds[Mathf.RoundToInt(childdna.GetGene(1))]);

                Debug.Log(Mathf.RoundToInt(childdna.GetGene(2)));
                Debug.Log(_model.Seeds[Mathf.RoundToInt(childdna.GetGene(2))]);

                Debug.Log(Mathf.RoundToInt(childdna.GetGene(3)));
                Debug.Log(_model.Seeds[Mathf.RoundToInt(childdna.GetGene(3))]);
                */
                Texture2D texture1 = _model.Seeds[Mathf.RoundToInt(childdna.GetGene(0))];
                Texture2D texture2 = _model.Seeds[Mathf.RoundToInt(childdna.GetGene(1))];
                Texture2D texture3 = _model.Seeds[Mathf.RoundToInt(childdna.GetGene(2))];
                Texture2D texture4 = _model.Seeds[Mathf.RoundToInt(childdna.GetGene(3))];

                Texture2D combined = ImageSynthesizer.CombineFour(texture1, texture2, texture3, texture4, _currentStack.RowCount, _currentStack.ColumnCount);
                Texture2D texture5 = _model.Seeds[0];
                _model.ResetModel(combined);


            }

        }


        /// <summary>
        /// 
        /// </summary>
        private void AddStackToPopulation(CellStack stack)
        {
            _currentPopulation[_popCount] = stack;
        }

        /// <summary>
        /// 
        /// </summary>
        private void AddPopulationToHistory(CellStack[] population)
        {
            _populationHistory.Add(population);
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeMatingPool()
        {
            _matingPool = new List<IDNAF>();
            for (int i = 0; i < _popSize; i++)
            {
                _matingPool.Add(new DNAF());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateMatingPool()
        {
            _matingPool.Clear();

            //get flattened stack population
            var population = _populationHistory.SelectMany(i => i);
            //sort by fitness value (highest first - descending)
            var sortedList = population.OrderByDescending(o => (o.Fitness)).ToList();

            if (sortedList.Count < _popSize * 2)
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
        /// 
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
        /// 
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


    }
}
