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
    public static void AnalyzeTouristCountries(HashSet<String> countries, List<HashSet<string>> touristVisits)
    {
        HashSet<String> countriesSome = new HashSet<string>();

        foreach (HashSet<String> tour in touristVisits)
        {
            countriesSome.UnionWith(tour);
        }

        // (посещенные всеми)
        HashSet<string> visitedAll = touristVisits[0];
        for (int i = 1; i < touristVisits.Count; i++)
        {
            visitedAll.IntersectWith(touristVisits[i]);
        }
        Console.WriteLine(String.Join(" ", visitedAll) + " -- Все туристы");

        //  (все посещенные) - (посещенные всеми)
        HashSet<string> visitedBySome = new HashSet<string>(countriesSome);
        visitedBySome.ExceptWith(visitedAll);
        Console.WriteLine(String.Join(" ", visitedBySome) + " -- Некоторые из туристов");

        // (все страны) - (посещенные кем-либо)
        HashSet<string> visitedByNoOne = new HashSet<string>(countries);
        visitedByNoOne.ExceptWith(countriesSome);
        Console.WriteLine(String.Join(" ", visitedByNoOne) + " -- Никто не посетил");

    }

    public static void AnalyzeTouristCountries1(HashSet<String> countries, Dictionary<string, HashSet<String>> touristVisits)
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
        // Читаем и разделяем
        string text = File.ReadAllText(filePath).ToLower();
        char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '(', ')', '\n' };
        string[] words = text.Split(separators);

        HashSet<char> deafConsonants = new HashSet<char> { 'п', 'ф', 'к', 'т', 'ш', 'с', 'х', 'ц', 'ч', 'щ' };
        HashSet<char> words1 = new HashSet<char> { };
        HashSet<char> words2 = new HashSet<char> { };

        foreach (string word in words)
        {
            HashSet<char> CountWord = new HashSet<char>();

            foreach (char c in word)
            {
                CountWord.Add(c);
            }
            
            foreach (char c in CountWord)
            {
                if (deafConsonants.Contains(c)) // есть еть глухая согласная
                {
                    if (!words2.Contains(c))
                    {
                        if (words1.Contains(c))
                        {
                            words2.Add(c);
                            words1.Remove(c);
                        }
                        else
                        {
                            words1.Add(c);
                        }
                        
                    }
                }
            }
        }
        Console.WriteLine(String.Join(" ", words1));

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
