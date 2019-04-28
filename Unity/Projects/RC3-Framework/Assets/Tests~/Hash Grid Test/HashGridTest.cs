using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using SpatialSlur;
using SpatialSlur.Collections;

using Random = System.Random;
using Stopwatch = System.Diagnostics.Stopwatch;

namespace RC3.Unity.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class HashGridTest : MonoBehaviour
    {
        [SerializeField] private bool _logResults;

        private Vector3d[] _points;
        private Random _random = new Random(0);

        private HashGrid3d<int> _grid = new HashGrid3d<int>();

        private Vector3d _boundsMin = new Vector3d(0.0);
        private Vector3d _boundsMax = new Vector3d(50.0);

        private double _searchRadius = 30.0; // 2.0;
        private double _gridScale = 10.0; // 5.0;
        private int _pointCount = 100;

        private Stopwatch _timer = new Stopwatch();


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _points = new Vector3d[_pointCount];
            _grid = new HashGrid3d<int>();
        }


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            Profile();
        }


        /// <summary>
        /// 
        /// </summary>
        private void Profile()
        {
            var points = _points;
            var grid = _grid;
            var random = _random;

            var bounds = new Interval3d(_boundsMin, _boundsMax);
            var offset = new Vector3d(_searchRadius);

            _timer.Start();

            // Setting the scale also clears the grid
            grid.Scale = _gridScale;

            // Insert points
            for (int i = 0; i < points.Length; i++)
            {
                var p = random.NextVector3d(bounds);
                grid.Insert(p, i);
                points[i] = p;
            }

            int hitCount = 0;

            // Search from each point
            for (int i = 0; i < points.Length; i++)
            {
                var p = points[i];
                var b = new Interval3d(p - offset, p + offset);

                foreach (var j in grid.Search(b))
                    hitCount++;
            }

            _timer.Stop();

            if (_logResults)
            {
                var n = points.Length;
                var message = $"{_timer.Elapsed.TotalMilliseconds:0.000} ms elapsed | {hitCount}/{n * n} hits over {n} searches\n---";
                Debug.Log(message);
            }

            _timer.Reset();
        }
    }
}
