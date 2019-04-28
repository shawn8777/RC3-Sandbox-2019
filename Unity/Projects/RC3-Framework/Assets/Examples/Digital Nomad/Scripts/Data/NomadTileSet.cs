/*

    TODO

    - Read tile meshes directly from the source file

*/

using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using Domino;

namespace RC3.DigitalNomad
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/DigitalNomad/Tile Set")]
    public class NomadTileSet : TilingDemo.TileSet
    {
        [SerializeField] private string _sourcePath;

        private List<NomadTile> _tiles;

        /// <summary>
        /// 
        /// </summary>
        public List<NomadTile> Tiles
        {
            get { return _tiles;}
        }
        
        /// <summary>
        /// 
        /// </summary>
        public TileType TileType
        {
            get { return TileType.Cube; }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Awake()
        {
            // Load meshes and tiles from the given path

            // TODO: also responsible for creating rotations and reflections
            // Use naming convention of imported tiles to determine rotations and reflections
        }

        /// <summary>
        /// 
        /// </summary>
        private IEnumerable<NomadTile> CreateRotations(NomadTile tile)
        {
            int nX = tile.RotationX ? 1 : 4;
            int nY = tile.RotationY ? 1 : 4;
            int nZ = tile.RotationZ ? 1 : 4;

            float halfPi = Mathf.PI * 0.5f;

            for(int i = 0; i < nZ; i++)
            {
                for(int j = 0; j < nY; j++)
                {
                    for(int k = 0; k < nX; k++)
                    {
                        float angleX = halfPi * k; 
                        float angleY = halfPi * j; 
                        float angleZ = halfPi * i;

                        // Create rotation from Euler angles
                        var quat = Quaternion.EulerRotation(angleX, angleY, angleZ);

                        // 
                        var copy = CreateInstance<NomadTile>();

                        // TODO
                        // Set labels of the copy (need a table of rotations)
                        copy.Transform = Matrix4x4.Rotate(quat);
                        copy.Mesh = tile.Mesh;
                        copy.
                          
                    }
                }
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public override TileMap CreateMap()
        {
            // TODO
            throw new System.NotImplementedException();
        }
    }
}
