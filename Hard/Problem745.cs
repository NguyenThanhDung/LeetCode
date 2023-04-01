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

        Input input = new Input("Hard", "input.json");
        wordFilter = new WordFilter(input.Words.ToArray());
        DateTime start = DateTime.Now;
        foreach(List<string> filter in input.Filters)
            Console.WriteLine(wordFilter.F(filter[0], filter[1]));
        Console.WriteLine(DateTime.Now - start);
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
            public List<string> Words { get; set; }
            public List<List<string>> Filters { get; set; }

        public Input(string level, string filename)
        {
            string path = Path.Join(Directory.GetCurrentDirectory(), level, filename);
            string text = File.ReadAllText(path);

            using (JsonDocument doc = JsonDocument.Parse(text))
            {
                JsonElement root = doc.RootElement;
                Words = JsonSerializer.Deserialize<List<string>>(root.GetProperty("Words").GetRawText());

                Filters = new List<List<string>>();
                int length = root.GetProperty("Filters").GetArrayLength();
                for(int i = 0; i < length; i++)
                {
                    List<string> pair = JsonSerializer.Deserialize<List<string>>(root.GetProperty("Filters")[i].GetRawText());
                    Filters.Add(pair);
                }
            }
        }
    }
}