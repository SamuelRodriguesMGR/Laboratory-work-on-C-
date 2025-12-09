using System.Collections.Generic;
using System.Net;


public class EnterNums
{
    public static List<T> RemoveAfterE<T>(List<T> list, T element)
    {
        List<T> result = new List<T>();
        for (int i = 0; i < list.Count; i++)
        {
            result.Add(list[i]);

            if (list[i].Equals(element) &&
                i + 1 < list.Count &&
                !list[i + 1].Equals(element))
            {
                i++;
            }
        }

        return result;
    }

    public static bool HasEqualNeighbors<T>(List<T> list)
    {
        // короче блин, если один элемент или меньше, то бан без объяснений
        if (list == null || list.Count <= 1)
            return false;

        for (int i = 0; i < list.Count; i++)
        {
            int nextIndex = (i + 1) % list.Count;
            if (list[i].Equals(list[nextIndex]))
                return true;
        }

        return false;
    }
    public static void AnalyzeTouristCountries(HashSet<String> countries, Dictionary<string, HashSet<String>> touristVisits)
    {
        foreach (String country in countries)
        {
            int count = 0;
            foreach (var visits in touristVisits.Values)
            {
                if (visits.Contains(country)) // содержится ли страна
                    count++;
            }
            if (count == touristVisits.Count)
            {
                Console.WriteLine($"Страну {country} посетили все {touristVisits.Count} туристов");
            }
            else if (count > 0)
            {
                Console.WriteLine($"Страну {country} посетили некоторые из туристов ({count})");
            }
            else 
            {
                Console.WriteLine($"Страну {country} никто не посетил из туристов");
            }
            
        }
    }

    public static void FindDeafConsonants(String filePath)
    {

        static int GetIndex(char element, HashSet<char> Collection)
        {
            int index = 0;

            foreach (char el in Collection)
            {
                if (el == element)
                {
                    return index;
                }
                index += 1;
            }
            return 0;
        }

        // Читаем и разделяем
        string text = File.ReadAllText(filePath).ToLower();
        char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '(', ')', '\n' };
        string[] words = text.Split(separators);
        
        //
        HashSet<char> deafConsonants = new HashSet<char> { 'п', 'ф', 'к', 'т', 'ш', 'с', 'х', 'ц', 'ч', 'щ' };
        List<int> CountConsonants = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        foreach (string word in words)
        {
            HashSet<char> CountWord = new HashSet<char>();
            
            foreach (char c in word)
            {
                if (deafConsonants.Contains(c)) // есть еть глухая согласная
                {
                    CountWord.Add(c);
                }
            }
            // Console.WriteLine(word + " * " + String.Join(" ", CountWord));

            foreach (char c in CountWord)
            {
                CountConsonants[GetIndex(c, deafConsonants)] ++;
            }
        }   
        
        List<char> result = new List<char>();

        for (int i = 0; i < deafConsonants.Count; i++)
        {

            if (CountConsonants[i] != 1)
            {
                result.Add(deafConsonants.ElementAt(i));
            }
        }

        result.Sort();
        Console.WriteLine(String.Join(", ", result));
               
    }

    public static void ProcessApplicants(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        Dictionary<string, List<int>> failedApplicants = new Dictionary<string, List<int>> {};
        
        for (int i = 1; i < lines.Length; i++)
        {
            var data = lines[i].Split();
            
            if (int.Parse(data[2]) < 30 || int.Parse(data[3]) < 30)
            {
                failedApplicants.Add(data[0]+" "+data[1], [int.Parse(data[2]), int.Parse(data[3])]);
            }
            
        }

        List<string> result = new List<string>();

        foreach (var applicant in failedApplicants)
        {
            result.Add($"{applicant.Key}");
        }

        result.Sort();
        Console.WriteLine(String.Join(", ", result));
    }

}
