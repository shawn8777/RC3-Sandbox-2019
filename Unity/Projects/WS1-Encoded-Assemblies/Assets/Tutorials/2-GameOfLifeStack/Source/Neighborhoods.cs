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