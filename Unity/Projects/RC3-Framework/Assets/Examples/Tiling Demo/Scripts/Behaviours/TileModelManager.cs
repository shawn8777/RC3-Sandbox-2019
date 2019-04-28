using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SpatialSlur;

using Domino;
using Domino.Collections;

namespace RC3.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class TileModelManager : MonoBehaviour
    {
        [SerializeField] private TileGraph _graph;
        [SerializeField] private TileGraphInitializer _graphInit;
        [Space(10)]
        [SerializeField] private int _substeps = 10;
        [SerializeField] private int _seed = 1;
        [SerializeField] private TileModelInitializer _modelInit; // Optional
        [SerializeField] private TileSelector _tileSelector; // Optional
        [SerializeField] private NodeSelector _nodeSelector; // Optional
        [Space(10)]
        [SerializeField] private Event _modelCompleted; // Optional
        [SerializeField] private Event _modelContradicted; // Optional

        private TileMap _map;
        private TileModel _model;
        private TileModelStatus _status;


        /// <summary>
        /// 
        /// </summary>
        public TileModel Model
        {
            get { return _model; }
        }


        /// <summary>
        /// 
        /// </summary>
        public TileGraph Graph
        {
            get { return _graph; }
        }


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _graphInit.Initialize(_graph);

            _map = _graph.TileSet.CreateMap();
            _model = TileModel.Create(_graph.Adjacency, _map, _tileSelector, _nodeSelector);

            _model.DomainChanged += OnDomainChanged;
            _status = TileModelStatus.Incomplete;

            // Initialize model
            _modelInit?.Initialize(_model, _graph);

            // Center at world origin
            {
                var positions = _graph.Positions;
                Vector3 sum = Vector3.zero;

                for(int i = 0; i < positions.Length; i++)
                    sum += positions[i];

                transform.localPosition = sum * (-1.0f / positions.Length);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
                ResetModel();
            
            if (_status == TileModelStatus.Incomplete)
            {
                for (int i = 0; i < _substeps; i++)
                {
                    _status = _model.Step();

                    if (_status == TileModelStatus.Contradiction)
                    {
                        Debug.Log("Contradiction found! Reset to try again.");
                        OnContradiction();
                        return;
                    }
                    else if (_status == TileModelStatus.Complete)
                    {
                        Debug.Log("Tiling complete!");
                        OnComplete();
                        return;
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void ResetModel()
        {
            _model.ResetAllDomains();
            _modelInit?.Initialize(_model, _graph);
            _status = TileModelStatus.Incomplete;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="domain"></param>
        private void OnDomainChanged(TileModel model, int node)
        {
            var d = model.GetDomain(node);
            var n = d.Count;

            if (n > 0)
            {
                _graph.DomainSizes[node] = n;
                _graph.AssignedTiles[node] = n == 1 ? d.First() : -1;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void OnContradiction()
        {
            if (_modelContradicted != null)
                _modelContradicted.Raise();
        }


        /// <summary>
        /// 
        /// </summary>
        private void OnComplete()
        {
            if(_modelCompleted != null)
                _modelCompleted.Raise();
        }
    }
}
