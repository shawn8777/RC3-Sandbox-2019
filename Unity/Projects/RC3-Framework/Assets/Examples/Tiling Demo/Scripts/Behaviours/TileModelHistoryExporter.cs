using UnityEngine;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [RequireComponent(typeof(TileModelRecorderData))]
    public class TileModelHistoryExporter : MonoBehaviour
    {
        [SerializeField] private string _path;

        private TileModelHistory _history;


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            _history = GetComponent<TileModelRecorderData>().History;
        }


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
                Export();
        }


        /// <summary>
        /// 
        /// </summary>
        public void Export()
        {
            Utilities.SerializeBinary(_history.Data, _path);
            Debug.Log("TileModelHistory export complete!");
        }
    }
}
