using System;

namespace FinickyFeline
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new FinickyFelineGame())
                game.Run();
        }
    }
}
