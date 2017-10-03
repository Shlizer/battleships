using System;

namespace Battleships
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Battleships()) game.Run();
        }
    }
}
