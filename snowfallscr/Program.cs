namespace snowfallscr
{
    static class Program
    {
        /// <summary>
        /// Основная точка входа в приложение.
        /// </summary>
        static void Main(string[] args)
        {
            using (Snowfall game = new Snowfall())
            {
                game.Run();
            }
        }
    }
}
