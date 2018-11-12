using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SpatialSlur;

namespace RC3
{

    public class PopulationManager : MonoBehaviour
    {
        private int popSize = 10;
        private int currentPopSize = 0;
        private int minPopBreed = 10;
        private int popCount = 0;
        private List<CellStack[]> popHistory = new List<CellStack[]>();

        [SerializeField] private CellStack _stackPrefab;
        private CellStack currentStack;
        private CellStack nextStack;

        private StackModel _model;

        //private populationHistory

        //Current Population

        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            if (GetComponent<StackModel>() == null)
            {
                Debug.Log("No StackModel Component!");
            }

            _model = GetComponent<StackModel>();
            //currentStack = Instantiate(_stackPrefab, transform);
        }


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            //check if stack is finished build

            //analyse stack

            //if stack analysis is finished, move the stack

            //Natural Selection

            //Breed new stack

        }

        /// <summary>
        /// 
        /// </summary>
        private void AddStackToPopulation()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        private void NaturalSelection()
        {

        }

        private void Breed(Stack stack1, Stack stack2)
        {

        }

        private void BreedNewPopulation()
        {

        }


    }
}
