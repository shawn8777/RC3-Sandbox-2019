namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public static class Neighborhoods
    {
        /// <summary>
        /// 
        /// </summary>
        static Neighborhoods()
        {
            MooreR2 = new IndexPair[24];
            int index = 0;

            for(int i = -2; i < 3; i++)
            {
                for (int j = -2; j < 3; j++)
                {
                    if (i != j)
                        MooreR2[index++] = new IndexPair(i, j);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public static readonly IndexPair[] MooreR1 =
        {
            new IndexPair(-1, -1),
            new IndexPair(-1, 0),
            new IndexPair(-1, 1),
            new IndexPair(0, -1),

            new IndexPair(0, 1),
            new IndexPair(1, -1),
            new IndexPair(1, 0),
            new IndexPair(1, 1)
        };


        /// <summary>
        /// 
        /// </summary>
        public static readonly IndexPair[] MooreR2;


        /// <summary>
        /// 
        /// </summary>
        public static readonly IndexPair[] VonNeumannR1 =
        {
            new IndexPair(-1, 0),
            new IndexPair(0, -1),
            new IndexPair(0, 1),
            new IndexPair(1, 0)
        };


        /// <summary>
        /// 
        /// </summary>
        public static readonly IndexPair[] VonNeumannR2 =
        {
            new IndexPair(-2, 0),
            new IndexPair(-1, -1),
            new IndexPair(-1, 0),
            new IndexPair(-1, 1),

            new IndexPair(0, -2),
            new IndexPair(0, -1),
            new IndexPair(0, 1),
            new IndexPair(0, 2),

            new IndexPair(1, -1),
            new IndexPair(1, 0),
            new IndexPair(1, 1),
            new IndexPair(2, 0)
        };
    }
}