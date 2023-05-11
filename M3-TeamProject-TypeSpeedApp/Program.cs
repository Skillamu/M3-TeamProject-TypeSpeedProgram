using System.Diagnostics;
using System.Text.Json;

namespace M3_TeamProject_TypeSpeedApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generate = new Generate();
            var game = new Game(generate);

            game.Run();
        }
    }
}