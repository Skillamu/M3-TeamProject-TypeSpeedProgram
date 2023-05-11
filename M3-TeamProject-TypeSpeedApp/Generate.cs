using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace M3_TeamProject_TypeSpeedApp
{
    internal class Generate
    {
        private string[]? _ord;
        private string[] _setning;
        private int _currentIndex;

        public Generate()
        {
            var json = File.ReadAllText(@"../../../words.json");
            _ord = JsonSerializer.Deserialize<string[]>(json);
            _setning = GenerateSentence();
        }

        private string[] GenerateSentence()
        {
            var random = new Random();

            var setning = new string[200];

            for (int i = 0; i < 200; i++)
            {
                var randomTall = random.Next(_ord.Length);
                setning[i] = _ord[randomTall];
            }

            return setning;
        }

        public void ShowText()
        {
            Console.Clear();

            Console.WriteLine("Skriv inn første ordet i setningen og trykk ENTER\n");

            string displayText = "";

            for (int i = 0; i <= 15; i++)
            {
                if (i % 8 == 0)
                {
                    if(i != 0) displayText += "\n";
                }

                displayText += $"{_setning[_currentIndex + i]} ";
            }


            Console.WriteLine(displayText);
        }

        public int CheckCurrentWord(string input)
        {
            if (input == _setning[_currentIndex])
            {
                _currentIndex++;
                return 1;
            }
            _currentIndex++;
            return 0;
        }
    }
}
