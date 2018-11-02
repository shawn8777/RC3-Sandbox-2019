
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
            int ni = source.GetLength(0);
            int nj = source.GetLength(1);

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < ni; i++)
            {
                for (int j = 0; j < nj; j++)
                    text.Append($"{source[i, j]}, ");
            }

            return text.ToString();
        }
    }
}
