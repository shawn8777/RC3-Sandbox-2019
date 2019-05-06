using System.Collections;

using UnityEngine;

using Domino;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(TileModelData))]
    public class TileModelExporter : MonoBehaviour
    {
        [SerializeField] private string _path;

        private TileGraph _graph;


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _graph = GetComponent<TileModelData>().Graph;
        }


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
                Export();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Export()
        {
            Utilities.SerializeBinary(_graph.TileIndices, _path);
            Debug.Log("TileModel export complete!");
        }
    }
}
