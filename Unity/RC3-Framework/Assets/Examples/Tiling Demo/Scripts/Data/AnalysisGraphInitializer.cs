using System.Collections.Generic;

using UnityEngine;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class AnalysisGraphInitializer : Initializer<UniformGraph>
    {
        [SerializeField] TileGraph _tileGraph;
        [SerializeField] string[] _connectedLabels;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public override void Initialize(UniformGraph target)
        {
            var adj0 = _tileGraph.Adjacency;
            var n = adj0.GetLength(0);
            var m = adj0.GetLength(1);

            target.Initialize(n, m);
            var adj1 = target.Adjacency;

            var tileSet = _tileGraph.TileSet;
            var tileIndices = _tileGraph.TileIndices;
            var connectedLabelSet = new HashSet<string>(_connectedLabels);

            for (int i = 0; i < n; i++)
            {
                int tileIndex = tileIndices[i];

                if (tileIndex == -1)
                    throw new System.ArgumentException($"Tile has not yet been assigned at position {i}");
                
                var labels = tileSet[tileIndex].Labels;
                
                for(int j = 0; j < m; j++)
                {
                    if (connectedLabelSet.Contains(labels[j]))
                        adj1[i, j] = adj0[i, j];
                    else
                        adj1[i, j] = -1;
                }
            }
        }
    }
}
