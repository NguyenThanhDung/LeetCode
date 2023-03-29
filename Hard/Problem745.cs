using System;
using System.IO;
using System.Text.Json;

public class Problem745
{
    public Problem745()
    {
        string[] words = new string[] { "apple" };
        WordFilter wordFilter = new WordFilter(words);
        int index = wordFilter.F("a", "e");
        Console.WriteLine(index == 0);

        Input input = new Input("Hard", "input4.json");
        // Input input = new Input("Hard", "input.txt");
        // foreach (string word in input.words)
        //     Console.Write(word + " ");
        // Console.WriteLine();
        // foreach (string[] pair in input.filters)
        //     Console.Write("[" + pair[0] + "," + pair[1] + "] ");
        // Console.WriteLine();
    }

    public class WordFilter
    {
        private string[] words;

        public WordFilter(string[] words)
        {
            this.words = words;
        }

        public int F(string pref, string suff)
        {
            int index = -1;
            for (int i = words.Length - 1; i >= 0; i--)
            {
                if (words[i].StartsWith(pref) && words[i].EndsWith(suff))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }

    public class Input
    {
        public string[] words;
        public string[][] filters;

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
            public string Word { get; set; }
            public List<List<string>> Code { get; set; }
        }

        public Input(string level, string filename)
        {
            string path = Path.Join(Directory.GetCurrentDirectory(), level, filename);
            string text = File.ReadAllText(path);

            using (JsonDocument doc = JsonDocument.Parse(text))
            {
                JsonElement root = doc.RootElement;
                Person person = new Person
                {
                    Name = root.GetProperty("Name").GetString(),
                    Age = root.GetProperty("Age").GetInt32(),
                    Email = root.GetProperty("Email").GetString(),
                    Word = JsonSerializer.Deserialize<string>(root.GetProperty("Input")[0].GetRawText())
                };

                person.Code = new List<List<string>>();
                int length = root.GetProperty("Input").GetArrayLength();
                for(int i = 1; i < length; i++)
                {
                    List<string> pair = JsonSerializer.Deserialize<List<string>>(root.GetProperty("Input")[i].GetRawText());
                    person.Code.Add(pair);
                }

                Console.WriteLine();
            }

            // string[] lines = File.ReadAllLines(path);
            // JsonElement element = JsonSerializer.Deserialize<JsonElement>(lines[1]);
            // words = element[0][0]
            //     .EnumerateArray()
            //     .Select(x => new string(x.GetString()))
            //     .ToArray();
            // filters = element[1]
            //     .EnumerateArray()
            //     .Select(x => x.EnumerateArray()
            //         .Select(y => y.GetString())
            //         .ToArray())
            //     .ToArray();
        }
    }
}