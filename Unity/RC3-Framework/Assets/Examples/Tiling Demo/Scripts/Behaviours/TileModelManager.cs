﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SpatialSlur;

using Domino;
using Domino.Collections;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(TileModelData))]
    public class TileModelManager : MonoBehaviour
    {
        [SerializeField] private int _substeps = 10;
        [SerializeField] private int _seed = 1;

        [SerializeField] private TileSelector _selector; // Optional
        [SerializeField] private TileModelInitializer _modelInit; // Optional

        [SerializeField] private Event _modelCompleted; // Optional
        [SerializeField] private Event _modelContradicted; // Optional

        private TileGraph _graph;
        private TileModel _model;
        private TileMap _map;
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
        private void Start()
        {
            _graph = GetComponent<TileModelData>().Graph;

            _map = _graph.TileSet.CreateMap();
            _model = TileModel.Create(_graph.Adjacency, _map, _seed);

            _model.DomainChanged += OnDomainChanged;
            _status = TileModelStatus.Incomplete;

            // Optional initialization
            {
                if (_selector != null)
                    _model.Selector = _selector;

                if (_modelInit != null)
                {
                    _modelInit.Graph = _graph; // Pass graph to initializer
                    _modelInit.Initialize(_model);
                }
            }

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
        /// <param name="position"></param>
        /// <param name="domain"></param>
        private void OnDomainChanged(int position)
        {
            var domain = _model.GetDomain(position);

            if (domain.Count == 1)
                _graph.TileIndices[position] = domain.First();
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
                        Debug.Log("Contradiction found! Reset the model and try again.");
                        OnContradiction();
                        return;
                    }
                    else if (_status == TileModelStatus.Complete)
                    {
                        Debug.Log("Collapse complete!");
                        OnComplete();
                        return;
                    }
                }
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


        /// <summary>
        /// 
        /// </summary>
        private void ResetModel()
        {
            _graph.TileIndices.Set(-1);

            _model.ResetAllDomains();
            _modelInit?.Initialize(_model);
            _status = TileModelStatus.Incomplete;
        }
    }
}
