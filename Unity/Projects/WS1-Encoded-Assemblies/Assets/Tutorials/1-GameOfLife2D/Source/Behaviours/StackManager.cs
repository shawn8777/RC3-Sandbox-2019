using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC3
{
    public class StackManager : MonoBehaviour
    {
        [SerializeField] private ModelInitializer _initializer;
        [SerializeField] private CellLayer _layerPrefab;
        [SerializeField] private Cell _cellPrefab;

        [SerializeField] private int _layerWidth = 10;
        [SerializeField] private int _layerLength = 10;
        [SerializeField] private int _layerCount = 10;

        private CellLayer[] _layers;
        private GameOfLife2D _model;
        private int _stepCount;

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _layers = new CellLayer[_layerCount];

            // instantiate layers
            for(int i = 0; i < _layerCount; i++)
            {
                CellLayer copy = Instantiate(_layerPrefab, transform);
                copy.transform.localPosition = new Vector3(0.0f, -i, 0.0f);

                copy.Initialize(_cellPrefab, _layerWidth, _layerLength);
                _layers[i] = copy;
            }

            // instantiate model
            _model = new GameOfLife2D(_layerWidth, _layerLength);

            // initialize mode
            _initializer.Initialize(_model.CurrentState);

            // center manager gameobject at the world origin
            transform.localPosition = new Vector3(_layerWidth, _layerCount, _layerLength) * -0.5f;
        }


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _initializer.Initialize(_model.CurrentState);

            _model.Step();
            _stepCount++;

            // update the current layer
            CellLayer currentLayer = _layers[_stepCount % _layerCount];
            UpdateLayer(currentLayer);

            // move layers
            MoveLayers();
        }


        /// <summary>
        /// Updates cells from the given layer based on the current state of the model
        /// </summary>
        /// <param name="layer"></param>
        private void UpdateLayer(CellLayer layer)
        {
            Cell[,] cells = layer.Cells;
            int[,] state = _model.CurrentState;

            for (int i = 0; i < _layerLength; i++)
            {
                for (int j = 0; j < _layerWidth; j++)
                    cells[i, j].SetState(state[i, j]);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void MoveLayers()
        {
            for(int i = 0; i < _layerCount; i++)
            {
                Transform xform = _layers[i].transform;
                Vector3 pos = xform.localPosition;

                int y = Mathf.RoundToInt(pos.y);
                if (++y >= _layerCount) y = 0;

                pos.y = y;
                xform.localPosition = pos;
            }
        }
    }
}
