using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Речник
{
    internal class Program
    {
        static Dictionary<string, string> synonyms = new Dictionary<string, string>(); //според извеждането на резултата*
        static Dictionary<string, string> dictionary = new Dictionary<string, string>();
        static Dictionary<string, string> translations = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            //Данните да се съхраняват в подходяща колекция (Dictionary, StringDictionary)*
            //Да се създаде меню със следните опции: 1 – въвеждане на нова дума.
            int choice; // декларираме променлива
            do
            {
                Console.WriteLine("Choose operation:");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 4);
                //докато входът не е успешно преобразуван към цяло число или входното число е извън
                //допустимия обхват, продължавай да четеш вход от потребителя
                //В случая "!" се прилага пред int.TryParse(Console.ReadLine(), out choice), като това означава "ако int.TryParse() не успее да преобразува входа от потребителя към цяло число" или "ако преобразуването не е успешно", тогава условието е истина. Това означава, че цикълът ще продължи да се изпълнява докато потребителят не въведе валидно цяло число. Така, "!int.TryParse(Console.ReadLine(), out choice)" проверява дали входът е валидно цяло число.Ако е валидно, то цикълът продължава.Ако входът не е валидно цяло число, цикълът продължава да чака вход от потребителя, докато не въведе валидно цяло число.

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Thank you!");
                        break;
                    case 1:
                        AddNewWord(); //за всеки case има нов static void, който изпълнява условиата
                        break;
                    case 2:
                        SearchWord();
                        break;
                    case 3:
                        DeleteWord();
                        break;
                    case 4:
                        PrintStatistics();
                        break;
                }
            } while (choice != 0) ; //Програмата да се изпълнява докато не се избере опция за приключване (0).
        }

        private static void PrintStatistics()
        {
            Console.WriteLine("Words in synonyms: " + synonyms.Count);
            Console.WriteLine("Words in dictionary: " + dictionary.Count);
            Console.WriteLine("Words in translations: " + translations.Count);
        }

        private static void DeleteWord()
        {
            string word = Console.ReadLine();
            if (synonyms.ContainsKey(word))
            {
                synonyms.Remove(word);
            }
            else
            {
                Console.WriteLine("The word does not exist in synonyms");
            }

            if (dictionary.ContainsKey(word))
            {
                dictionary.Remove(word);
            }
            else
            {
                Console.WriteLine("The word does not exist in dictionary");
            }

            if (translations.ContainsKey(word))
            {
                translations.Remove(word);
            }
            else
            {
                Console.WriteLine("The word does not exist in translations");
            }
        }

        private static void SearchWord()
        {
            string word = Console.ReadLine();
            if (synonyms.ContainsKey(word))
            {
                Console.WriteLine("Synonyms: " + synonyms[word]);
            }
            if (dictionary.ContainsKey(word))
            {
                Console.WriteLine("Description: " + dictionary[word]);
            }
            if (translations.ContainsKey(word))
            {
                Console.WriteLine("Translation: " + translations[word]);
            }
        }

        static void AddNewWord()
        {
            Console.WriteLine("New word: ");
            string word = Console.ReadLine();

            if (!synonyms.ContainsKey(word)) //ако думата не същесвува
            {
                Console.WriteLine("Synonym:");
                string synonym = Console.ReadLine();
                synonyms.Add(word, synonym); //!
                Console.WriteLine("The word has been added in synonyms");
            }
            else
            {
                Console.WriteLine("The word exists in synonyms");
            }

            if (!dictionary.ContainsKey(word))
            {
                Console.WriteLine("Description:");
                string description = Console.ReadLine();
                dictionary.Add(word, description);
                Console.WriteLine("The word has been added in dictionary");
            }
            else
            {
                Console.WriteLine("The word exists in dictionary");
            }

            if (!translations.ContainsKey(word))
            {
                Console.WriteLine("Translation:");
                string translation = Console.ReadLine();
                translations.Add(word, translation);
                Console.WriteLine("The word has been added in translations");
            }
            else
            {
                Console.WriteLine("The word exists in translations");
            }
        }
    }
}
