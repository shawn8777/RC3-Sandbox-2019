using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using SpatialSlur.Collections;

namespace RC3
{
    namespace WS2
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

            [SerializeField] private GameObject _UITextPrefab;

            private CellLayer[] _layers;

            private IDNAF _dna;
            private float _fitness = 1;
            private Texture2D _seed;

            private string _name = "";
            private float _meanStackDensity = 0;
            private float _maxLayerDensity = 0;
            private float _minLayerDensity = float.MaxValue;
            private float _maxAge = 0;
            private float _avgAge = 0;

            private Text _nameText;
            private Text _genesText;
            private Text _fitnessText;
            private Text _meanStackDensityText;
            private Text _maxLayerDensityText;
            private Text _minLayerDensityText;
            private Text _maxAgeText;
            private Text _avgAgeText;

            private MaterialPropertyBlock _properties;

            public MaterialPropertyBlock MaterialProperties
            {
                get { return _properties; }
                set { _properties = value; }
            }

            /// <summary>
            /// 
            /// </summary>
            private void Awake()
            {
                _properties = new MaterialPropertyBlock();
                _dna = new DNAF();
                InitializeCells();
                SetupUIText();

            }


            /// <summary>
            /// 
            /// </summary>
            private void SetupUIText()
            {
                if (_UITextPrefab != null)
                {
                    Transform canvastrans = _UITextPrefab.transform.parent;
                    _UITextPrefab = Instantiate(_UITextPrefab, canvastrans);
                    int count = _UITextPrefab.transform.childCount;

                    for (int i = 0; i < count; i++)
                    {
                        GameObject childobj = _UITextPrefab.transform.GetChild(i).gameObject;
                        if (childobj.name == "StackNameText")
                        {
                            _nameText = childobj.GetComponent<Text>();
                        }

                        if (childobj.name == "StackGenesText")
                        {
                            _genesText = childobj.GetComponent<Text>();
                        }

                        if (childobj.name == "StackFitnessText")
                        {
                            _fitnessText = childobj.GetComponent<Text>();
                        }

                        if (childobj.name == "StackMeanDensityText")
                        {
                            _meanStackDensityText = childobj.GetComponent<Text>();
                        }

                        if (childobj.name == "StackMaxLayerDensityText")
                        {
                            _maxLayerDensityText = childobj.GetComponent<Text>();
                        }

                        if (childobj.name == "StackMinLayerDensityText")
                        {
                            _minLayerDensityText = childobj.GetComponent<Text>();
                        }

                        if (childobj.name == "StackMaxAgeText")
                        {
                            _maxAgeText = childobj.GetComponent<Text>();
                        }


                        if (childobj.name == "StackAvgAgeText")
                        {
                            _avgAgeText = childobj.GetComponent<Text>();
                        }
                    }
                }

                else
                {
                    Debug.Log("No Text UI Object!!");
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetPosition(Vector3 pos)
            {
                transform.localPosition = pos;
                pos = new Vector3(pos.x, 0, pos.z - 5);
                if (_UITextPrefab != null)
                {
                    _UITextPrefab.transform.position = pos;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public void MovePosition(Vector3 move)
            {
                transform.localPosition += move;

                //move = new Vector3(move.x, move.z, 0);
                if (_UITextPrefab != null)
                {
                    _UITextPrefab.transform.position += move;
                }

            }

            /// <summary>
            /// 
            /// </summary>
            public GameObject UITextObj
            {
                get { return _UITextPrefab; }
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetName(string name)
            {
                _name = name;
            }

            /// <summary>
            /// 
            /// </summary>
            public float MeanStackDensity
            {
                get { return _meanStackDensity; }
            }


            /// <summary>
            /// 
            /// </summary>
            public void SetMeanStackDensity(float meanStackDensity)
            {
                _meanStackDensity = meanStackDensity;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public float MaxLayerDensity
            {
                get { return _maxLayerDensity; }
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetMaxLayerDensity(float maxLayerDensity)
            {
                _maxLayerDensity = maxLayerDensity;
            }

            /// <summary>
            /// 
            /// </summary>
            public float MinLayerDensity
            {
                get { return _minLayerDensity; }
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetMinLayerDensity(float minLayerDensity)
            {
                _minLayerDensity = minLayerDensity;
            }

            /// <summary>
            /// 
            /// </summary>
            public float MaxAge
            {
                get { return _maxAge; }
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetMaxAge(float maxAge)
            {
                _maxAge = maxAge;
            }

            /// <summary>
            /// 
            /// </summary>
            public float AvgAge
            {
                get { return _avgAge; }
            }

            /// <summary>
            /// 
            /// </summary>
            public void SetAvgAge(float avgAge)
            {
                _avgAge = avgAge;
            }

            /// <summary>
            /// 
            /// </summary>
            public void UpdateDataText()
            {
                if (_UITextPrefab != null)
                {
                    _UITextPrefab.SetActive(true);
                    _nameText.text = _name;

                    List<float> roundedgenes = new List<float>();
                    foreach (var gene in _dna.Genes)
                    {
                        roundedgenes.Add((float)Math.Round(gene, 3));
                    }

                    _genesText.text = "Genes= [ " + String.Join(",", roundedgenes) + " ]";
                    _fitnessText.text = "Fitness= " + _fitness;
                    _meanStackDensityText.text = "Mean Stack Density= " + _meanStackDensity;
                    _maxLayerDensityText.text = "Max Layer Density= " + _maxLayerDensity;
                    _minLayerDensityText.text = "Min Layer Density= " + _minLayerDensity;
                    _maxAgeText.text = "Max Age= " + _maxAge;
                    _avgAgeText.text = "Avg Age= " + _avgAge;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public IDNAF DNA
            {
                get { return _dna; }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="dna"></param>
            public void SetDNA(IDNAF dna)
            {
                _dna = dna;
            }

            /// <summary>
            /// 
            /// </summary>
            public Texture2D Seed
            {
                get { return _seed; }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="seed"></param>
            public void SetSeed(Texture2D seed)
            {
                _seed = seed;
            }

            /// <summary>
            /// 
            /// </summary>
            public float Fitness
            {
                get { return _fitness; }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="value"></param>
            public void SetFitness(float value)
            {
                _fitness = value;
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
                //transform.localPosition = new Vector3(_columnCount, 0, _rowCount) * -0.5f;

                //place lower corner on origin
                transform.localPosition = new Vector3(0, 0, 0);

            }
        }
    }
}
