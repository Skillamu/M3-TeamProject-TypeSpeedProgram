using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;

namespace M3_TeamProject_TypeSpeedApp
{
    internal class Game
    {
        private int _points;
        private int _time;
        private bool _gameIsRunning;
        private Stopwatch _stopwatch;
        private Generate _generate;

        public Game(Generate generate)
        {
            _time = 30;
            _stopwatch = new Stopwatch();
            _generate = generate;
        }
        
        public void Run()
        {
            _stopwatch.Start();
            _gameIsRunning = true;

            StartThreadOne();
            StartThreadTwo();
        }

        private void StartThreadOne()
        {
            var t1 = new Thread(() =>
            {
                while (true)
                {
                    if (_stopwatch.Elapsed.Seconds > _time)
                    {
                        _stopwatch.Stop();
                        _gameIsRunning = false;
                        break;
                    }
                }
                GameOverScreen();
            });

            t1.Start();
        }

        private void StartThreadTwo()
        {
            var t2 = new Thread(() =>
            {
                while (_gameIsRunning)
                {
                    _generate.ShowText();
                    var input = Console.ReadLine();
                    _points += _generate.CheckCurrentWord(input);
                }
            });

            t2.Start();
        }

        private void GameOverScreen()
        {
            Console.Clear();
            Console.WriteLine($"Antall riktige ord: {_points}");
            Console.WriteLine($"Ord per minutt: {Math.Floor(_points / (double)(_stopwatch.Elapsed.Seconds) * 100)}");
            Console.WriteLine("\nAvslutter programmet...");
            Thread.Sleep(10000);
            Environment.Exit(0);
        }
    }
}
