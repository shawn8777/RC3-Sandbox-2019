using System;
using UnityEngine;

using SpatialSlur.Collections;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public class CellStack : MonoBehaviour
    {
        [SerializeField] CellLayer _layerPrefab;
        [SerializeField] Cell _cellPrefab;

        [SerializeField] private int _columnCount = 10;
        [SerializeField] private int _rowCount = 10;
        [SerializeField] private int _layerCount = 10;

        private CellLayer[] _layers;


        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            InitializeCells();
        }


        /// <summary>
        /// 
        /// </summary>
        public CellLayer[] Layers
        {
            get { return _layers; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int RowCount
        {
            get { return _rowCount; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int ColumnCount
        {
            get { return _columnCount; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int LayerCount
        {
            get { return _layerCount; }
        }


        /// <summary>
        /// 
        /// </summary>
        private void InitializeCells()
        {
            _layers = new CellLayer[_layerCount];

            // instantiate layers
            for (int i = 0; i < _layerCount; i++)
            {
                CellLayer copy = Instantiate(_layerPrefab, transform);
                copy.transform.localPosition = new Vector3(0.0f, i, 0.0f);

                // create cell layer
                copy.Initialize(_cellPrefab, _rowCount, _columnCount);
                _layers[i] = copy;
            }

            // center at the world origin
            transform.localPosition = new Vector3(_columnCount, _layerCount, _rowCount) * -0.5f;
        }
    }
}
