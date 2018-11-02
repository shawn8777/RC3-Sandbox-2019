using UnityEngine;

namespace RC3
{
    [CreateAssetMenu(menuName = "RC3/WS1/ImageInitializer")]
    public class ImageInitializer : ModelInitializer
    {
        [SerializeField] private Texture2D _texture;
        [SerializeField] private float _threshold = 0.5f;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public override void Initialize(int[,] state)
        {
            int countY = state.GetLength(0);
            int countX = state.GetLength(1);

            float ty = 1.0f / (countY - 1);
            float tx = 1.0f / (countX - 1);

            for (int y = 0; y < countY; y++)
            {
                for(int x = 0; x < countX; x++)
                {
                    Color color = _texture.GetPixelBilinear(x * tx, y * ty);

                    if (color.grayscale > _threshold)
                        state[y, x] = 1;
                    else
                        state[y, x] = 0;
                }
            }
        }
    }
}
