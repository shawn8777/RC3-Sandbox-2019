
using System.Text;

namespace RC3
{
    public static class Interop
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToString(int[,] source)
        {
            int m = source.GetLength(0);
            int n = source.GetLength(1);

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                    text.Append($"{source[i, j]}, ");
            }

            return text.ToString();
        }
    }
}
