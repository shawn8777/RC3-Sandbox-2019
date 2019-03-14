using UnityEngine;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    public class TileModelData : MonoBehaviour
    {
        [SerializeField] private TileGraph _graph;
        [SerializeField] private TileGraphInitializer _graphInit;


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
        private void Awake()
        {
            _graphInit.Initialize(_graph);
        }
    }
}
