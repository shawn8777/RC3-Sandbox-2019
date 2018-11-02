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
        /// 
        /// </summary>
        public void Initialize(Cell cellPrefab, int width, int length)
        {
            // create cell array
            _cells = new Cell[length, width];

            // instantiate cell prefabs and store in array
            for (int j = 0; j < length; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Cell cell = Instantiate(cellPrefab, transform);
                    cell.transform.localPosition = new Vector3(i, 0.0f, j);
                    _cells[j, i] = cell;
                }
            }
        }
    }
}
