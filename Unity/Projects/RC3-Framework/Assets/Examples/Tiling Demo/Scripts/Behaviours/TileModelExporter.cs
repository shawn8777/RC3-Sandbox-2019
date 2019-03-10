using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Domino;

namespace RC3.Unity.TilingDemo
{
    public class TileModelExporter : MonoBehaviour
    {
        [SerializeField] private string _path;

        private TileModel _model;


        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.E))
                Export();
        }


        private void Export()
        {
            if(_model == null)
            {
                var manager = GetComponent<TileModelManager>();
                _model = manager.Model;
            }

            int[] tiles = new int[_model.PositionCount];

            for(int i = 0; i < tiles.Length; i++)
                tiles[i] = _model.GetAssigned(i);

            Utilities.SerializeBinary(tiles, _path);

            Debug.Log("TileModel export complete!");
        }
    }
}
