using ProjectLomdaWithLoginAndRegister.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLomdaWithLoginAndRegister.ViewModel
{

    internal class GameDataBase
    {
        private static List<GameData> _gameDataList = new List<GameData>
                {
                    new GameData
                    {
                        WordEnglish ="Apple",
                        TranslationHebrew = "תפוח",
                        ImageUrl ="C:\\Users\\User\\source\\repos\\WordsGameNew\\WordsGameNew\\Images\\APPLE.jpeg"
                    },
                    new GameData
                    {
                        WordEnglish ="Banana",
                        TranslationHebrew = "בננה",
                        ImageUrl ="C:\\Users\\User\\source\\repos\\WordsGameNew\\WordsGameNew\\Images\\BANANA.jpeg"
                    },
                    new GameData
                    {
                        WordEnglish ="Orange",
                        TranslationHebrew = "תפוז",
                        ImageUrl ="C:\\Users\\User\\source\\repos\\WordsGameNew\\WordsGameNew\\Images\\ORANGE.jpeg"
                    },
                    new GameData
                    {
                        WordEnglish ="Peach",
                        TranslationHebrew = "אפרסק",
                        ImageUrl ="C:\\Users\\User\\source\\repos\\WordsGameNew\\WordsGameNew\\Images\\PEACH.jpeg"
                    },
                    new GameData
                    {
                        WordEnglish ="Watermelon",
                        TranslationHebrew = "אבטיח",
                        ImageUrl ="C:\\Users\\User\\source\\repos\\WordsGameNew\\WordsGameNew\\Images\\WATERMELON.jpeg"
                    },
                };

        public static List<GameData> GameDataList
        {
            get { return _gameDataList; }
            set { _gameDataList = value; }
        }

    }
}
