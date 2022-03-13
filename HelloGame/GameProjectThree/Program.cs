using System;


namespace GameProjectThree
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new FireflyGame())
                game.Run();
        }
    }
}
