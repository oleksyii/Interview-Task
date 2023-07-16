using System.Text.RegularExpressions;

namespace WebApplication2.Sevices
{
    public class Logic : ILogic
    {
        private Dictionary<char, int> generalLetterCount = new Dictionary<char, int>();

        public string FindLetter(string text)
        {
            if(text.Length <= 0)
            {
                return "";
            }

            //.ToLower() шоб ігнорувати кейс

            List<String> smt = new List<String>(text.Split(' '));


            //HashSet<char> tmp = new HashSet<char>(smt[0]);
            foreach (String word in smt)
            {

                Dictionary<char, int> letterCount = new Dictionary<char, int>();

                foreach (char letter in word)
                {
                    if (letterCount.ContainsKey(letter))
                    {
                        letterCount[letter]++;
                    }
                    else
                    {
                        letterCount[letter] = 1;
                    }
                }

                // Iterate through the word again and return the first letter with count 1
                foreach (char letter in word)
                {
                    if (letterCount[letter] == 1)
                    {
                        insertToDictionary(letter);
                    }
                }
            }
                return "The Desired letter is: " + getTheAnswer();
        }

        private void insertToDictionary(char letter)
        {
            if (generalLetterCount.ContainsKey(letter))
            {
                generalLetterCount[letter]++;
            }
            else
            {
                generalLetterCount[letter] = 1;
            }
        }

        private char getTheAnswer()
        {
            Regex regex = new Regex(@"^[a-z]$");

            foreach (char letter in generalLetterCount.Keys)

            {
                if (generalLetterCount[letter] == 1 && regex.IsMatch(letter.ToString()))
                {
                    return letter;
                }
            }

            return '\0';
        }
    }
}
