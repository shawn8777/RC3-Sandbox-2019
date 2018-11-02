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
            int m = state.GetLength(0);
            int n = state.GetLength(1);

            float tm = 1.0f / (m - 1);
            float tn = 1.0f / (n - 1);

            for (int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Color color = _texture.GetPixelBilinear(j * tn, i * tm);

                    if (color.grayscale > _threshold)
                        state[i, j] = 1;
                    else
                        state[i, j] = 0;
                }
            }
        }
    }
}
