using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using SpatialSlur;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public class StackAnalyser : MonoBehaviour
    {
        private CellLayer[] _layers;
        private float _stackDensity;
        private int _currentIndex;
        private int _maxAge = 0;

        private List<Vector3> _aliveCellsCenters;
        private bool _showAliveCenters = false;
        private GameObject analysisResults;
        [SerializeField] GameObject lineRendererPefab;

        private void Start()
        {
            // link the analyser to the stack
            _layers = GetComponent<StackManager>().Layers;

            // create the list to store the alive cells centers for analysis
            _aliveCellsCenters = new List<Vector3>();

            // create a game object to hold the analysis results
            analysisResults = new GameObject();
            analysisResults.name = "Analysis Results";     
        }

        public void AddCellCenter(Vector3 cellCenter){
            _aliveCellsCenters.Add(cellCenter);
        }

        private void ShowCellsCenterPoints(){
            analysisResults.SetActive(true);
            for (int i = 0; i < _aliveCellsCenters.Count; i++){
                GameObject cellCenterSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                cellCenterSphere.transform.parent = analysisResults.transform;
                cellCenterSphere.transform.position = _aliveCellsCenters[i];
                cellCenterSphere.tag = "Destroyable";
            }
        }

        private void HideCellCenterPoints(){
            analysisResults.SetActive(false);
        }

        private void DestroyCellsCenterPoints(){
            GameObject[] destroyableObjects;
            destroyableObjects = GameObject.FindGameObjectsWithTag("Destroyable");
            foreach(GameObject objectToDestroy in destroyableObjects)
            {
                Destroy(objectToDestroy);
            }
        }

        public void CreateLineRenders()
        {
            // create a line renderer
            GameObject newLineRender = Instantiate(lineRendererPefab, Vector3.zero, Quaternion.identity, analysisResults.transform);
            newLineRender.tag = "Destroyable";
            newLineRender.transform.parent = analysisResults.transform;

            // connects all cell centers
            LineRenderer lineRenderer = newLineRender.GetComponent<LineRenderer>();
            List<Vector3> linePoints = SetAllCenterPointsLine();
            var points = new Vector3[linePoints.Count];
            for (int i = 0; i < linePoints.Count; i++)
            {
                points[i] = linePoints[i];
            }
            lineRenderer.positionCount = points.Length;
            lineRenderer.SetPositions(points);
        }

        public void ToggleCenterPointsDisplay(){
            _showAliveCenters = !_showAliveCenters;

            if (_showAliveCenters)
            {
                ShowCellsCenterPoints();
            }
            else
            {
                HideCellCenterPoints();
            }
        }

        public List<Vector3> SetAllCenterPointsLine(){
            return _aliveCellsCenters;
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
        public float StackDensity
        {
            get { return _stackDensity; }
        }


        /// <summary>
        /// Index of the most recently analysed layer
        /// </summary>
        public int CurrentLayerIndex
        {
            get { return _currentIndex; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int MaxAge
        {
            get { return _maxAge; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i0"></param>
        /// <param name="j0"></param>
        /// <param name="k0"></param>
        /// <param name="neighborhood"></param>
        /// <returns></returns>
        public int GetNeighborSum3(int i0, int j0, int k0, Index3[] neighborhood)
        {
            Cell[,] cells = _layers[k0].Cells;

            int m = cells.GetLength(0);
            int n = cells.GetLength(1);
            int p = _layers.Length;
            int sum = 0;

            foreach (Index3 offset in neighborhood)
            {
                int i1 = Wrap(i0 + offset.I, m);
                int j1 = Wrap(j0 + offset.J, n);
                int k1 = Wrap(k0 + offset.K, p);
                
                if (_layers[k1].Cells[i1, j1].State > 0)
                    sum++;
            }

            return sum;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int Wrap(int i, int n)
        {
            i %= n;
            return (i < 0) ? i + n : i;
        }


        /// <summary>
        /// 
        /// </summary>
        public void UpdateAnalysis()
        {
            CellLayer currentLayer = _layers[_currentIndex];
            Cell[,] cells = currentLayer.Cells;

            //update highest cell age
            foreach (var cell in cells)
                _maxAge = Math.Max(cell.Age, _maxAge);

            //update layer current density
            currentLayer.Density = CalculateDensity(cells);

            //update density of stack overall so far
            _stackDensity = _layers.Take(_currentIndex + 1).Average(layer => layer.Density);

            _currentIndex++;

        }


        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            _currentIndex = 0;
            DestroyCellsCenterPoints();
            _aliveCellsCenters.Clear();
        }


        /// <summary>
        /// Calculate the density of alive cells for the given layer
        /// </summary>
        /// <returns></returns>
        public float CalculateDensity(Cell[,] cells)
        {
            int aliveCount = 0;

            foreach (var cell in cells)
                aliveCount += cell.State;

            return (float)aliveCount / cells.Length;
        }
    }
}
