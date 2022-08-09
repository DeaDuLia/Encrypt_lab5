namespace lab_5
{
    class Frequency
    {
        private List<char> rusLetters;
        private List<char> cryptLetters;
        private string input;

        public Frequency(string textName, string freqName)
        {
            rusLetters = new List<char>();
            cryptLetters = new List<char>();
            getFrequencyRUS(freqName);
            getFrequencyCrypt(textName);
        }

        private void getFrequencyRUS(string textName)
        {
            Dictionary<char, double> frequencyRusDict = new Dictionary<char, double>();
            string line;
            StreamReader file = new StreamReader(@textName);
            string[] separator = { " " };
            string[] tmp = new string[2];
            while ((line = file.ReadLine()) != null)
            {
                tmp = line.Split(separator, StringSplitOptions.None);
                if (!frequencyRusDict.ContainsKey(Convert.ToChar(tmp[0])))
                {
                    frequencyRusDict.Add(Convert.ToChar(tmp[0]), Convert.ToDouble(tmp[1]));
                }
            }
            file.Close();
            foreach (var letter in frequencyRusDict.OrderBy(pair => pair.Value))
            {
                rusLetters.Add(letter.Key);
            }
            rusLetters.Reverse();
        }

        private void getFrequencyCrypt(string textName)
        {
            Dictionary<char, int> frequencyCryptDict = new Dictionary<char, int>();
            StreamReader file = new StreamReader(@textName);
            int count = 0;
            while (file.Peek() != -1)
            {
                input = Convert.ToString(file.ReadToEnd());
            }
            for(int i = 0; i < rusLetters.Count(); i++)
            {
                for (int j = 0; j < input.Count(); j++)
                {
                    if (rusLetters[i] == input[j])
                    {
                        count++;
                    }
                }
                if (!frequencyCryptDict.ContainsKey(rusLetters[i]))
                {
                    frequencyCryptDict.Add(rusLetters[i], count);
                    count = 0;
                }
            }
            foreach (var letter in frequencyCryptDict.OrderBy(pair => pair.Value))
            {
                cryptLetters.Add(letter.Key);
            }
            cryptLetters.Reverse();
        }

        private char x;
        public string Decrypt()
        {
            string output = "";
            foreach (char letter in input)
            {
                x = letter;
                for (int i = 0; i < rusLetters.Count(); i++)
                {
                    if (letter == cryptLetters[i])
                    {
                        x = rusLetters[i];
                    }
                }
                output += x;
            }            
            return output;
        }
    }
}