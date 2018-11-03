using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3
{
    public class CellLayer : MonoBehaviour
    {
        private Cell[,] _cells;

        /// <summary>
        /// 
        /// </summary>
        public Cell[,] Cells
        {
            get { return _cells; }
        }

        /// <summary>
        /// Calculate the density of alive/dead cells of this layer
        /// </summary>
        /// <returns></returns>
        public float CalculateDensity()
        {
            int totalcells = _cells.GetLength(0) * _cells.GetLength(1);
            int livingcount = 0;
            for (int j = 0; j < _cells.GetLength(0); j++)
            {
                for (int i = 0; i < _cells.GetLength(1); i++)
                {
                    livingcount += _cells[j, i].State;
                }
            }
            float output = ((float)livingcount)/((float)totalcells);
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Initialize(Cell cellPrefab, int rows, int columns)
        {
            // create cell array
            _cells = new Cell[rows, columns];

            // instantiate cell prefabs and store in array
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Cell cell = Instantiate(cellPrefab, transform);

                    cell.transform.localPosition = new Vector3(j, 0.0f, i);
                    _cells[i, j] = cell;
                }
            }
        }
    }
}
