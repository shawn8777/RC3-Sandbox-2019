/*
 * Notes
 */

using UnityEngine;

using Domino;

namespace RC3.Unity.TilingDemo
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(menuName = "RC3/Tiling Demo/Tile Model Initializers/Image Initializer")]
    public class ImageInitializer : TileModelInitializer
    {
        [SerializeField] private TileGraph _graph;
        [SerializeField] private Texture2D _texture;
        [SerializeField] private float _threshold = 0.5f;
        [SerializeField] private int[] _domain;


        /// <summary>
        /// 
        /// </summary>
        public override void Initialize(TileModel model)
        {
            var positions = _graph.Positions;

            // Compute bounding box
            var bounds = new Bounds();
            {
                for (int i = 0; i < positions.Length; i++)
                    bounds.Encapsulate(positions[i]);
            }

            // Set domains based on texture
            {
                var p0 = bounds.min;
                var d = bounds.size;

                for(int i = 0; i < positions.Length; i++)
                {
                    // Normalize point within bounds
                    var p = positions[i] - p0;
                    float u = p.x / d.x;
                    float v = p.y / d.y;

                    // Sample texture
                    Color color = _texture.GetPixelBilinear(u, v);

                    // Reduce domain if above the threshold
                    if(color.grayscale > _threshold)
                        model.SetDomain(i, _domain);
                }
            }
        }
    }
}
