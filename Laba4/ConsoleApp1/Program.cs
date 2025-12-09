

class Program
{
    static void Main(string[] args)
    {
        String path = "/home/marat/Development/C#/Laboratory-Work-CSharp/Laba4/ConsoleApp1/";
        // Console.WriteLine(string.Join(", ", EnterNums.RemoveAfterE([1, 1, 3, 4], 1)));
        // Console.WriteLine(EnterNums.HasEqualNeighbors([1, 2, 3, 1]));

        // Создаем данные для передачи в функцию
        // HashSet<String> countries = new HashSet<String>() { "Франция", "Бельгия", "Колумбия", "Челябинск" }; 

        // Dictionary<string, HashSet<String>> tourists = new Dictionary<string, HashSet<String>>()
        // {
        //     { "Иван" , ["Франция", "Бельгия"]},
        //     { "Марат" , ["Франция", "Бельгия"]},
        //     { "Афродий" , ["Франция", "Челябинск"]},
        //     { "Зак" , ["Франция"]}
        // };
        // EnterNums.AnalyzeTouristCountries(countries, tourists);

        
        // EnterNums.FindDeafConsonants(path + "Num4.txt");

        // EnterNums.ProcessApplicants(path + "Num5.txt");

        RightTriangle triangle = new RightTriangle(2.0, 3.0);
        Console.WriteLine(triangle);
    }
}

