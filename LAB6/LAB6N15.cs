class LAB6N15
{
    public static void DelFL(List<int> L, int x) //Составить программу, которая удаляет из списка L все элементы с указанным значением.
    {
        for (int i = L.Count - 1; i >= 0; i--)
        {
            if (L[i] == x)
                L.RemoveAt(i);
        }
    }

    public static void SwapBetweenE(LinkedList<int> L, int E)// списке L переставить в обратном порядке все элементы между первым и последним 
                                                             // вхождениями элемента E, если E входит в L не менее двух раз
    {
        if (L.Count == 0) return;
        LinkedListNode<int> pos1 = null;
        LinkedListNode<int> pos2 = null;

        var curr = L.First;
        while (curr != null)
        {
            if (curr.Value == E)
            {
                if (pos1 == null)
                    pos1 = curr;
                pos2 = curr;
            }
            curr = curr.Next;
        }

        if (pos1 == null || pos2 == null || pos1 == pos2)
            return;

        var nodesBetween = new List<LinkedListNode<int>>();
        curr = pos1.Next;

        while (curr != null && curr != pos2)
        {
            nodesBetween.Add(curr);
            curr = curr.Next;
        }

        if (nodesBetween.Count == 0) return;

        int left = 0;
        int right = nodesBetween.Count - 1;

        while (left < right)
        {
            int temp = nodesBetween[left].Value;
            nodesBetween[left].Value = nodesBetween[right].Value;
            nodesBetween[right].Value = temp;

            left++;
            right--;
        }
    }
    public static (HashSet<string> allWatched, HashSet<string> someWatched, HashSet<string> noneWatched)
    AnalyzeMovies(HashSet<string> allMovies, List<HashSet<string>> viewers) //Есть перечень фильмов. Определить для каждого фильма, какие из них посмотрели все n
                                                                            //зрителей, какие — некоторые из зрителей, и какие — никто из зрителей
    {
        if (viewers == null || viewers.Count == 0)
        {
            return (new HashSet<string>(), new HashSet<string>(), new HashSet<string>(allMovies));
        }

        // Фильмы, которые посмотрели ВСЕ зрители
        HashSet<string> allWatched = new HashSet<string>(viewers[0]);
        for (int i = 1; i < viewers.Count; i++)
        {
            allWatched.IntersectWith(viewers[i]);
        }
        // Фильмы, которые посмотрел ХОТЯ БЫ ОДИН зритель
        HashSet<string> anyWatched = new HashSet<string>();
        foreach (var viewer in viewers)
        {
            anyWatched.UnionWith(viewer);
        }
        // Фильмы, которые посмотрели НЕКОТОРЫЕ (но не все)
        HashSet<string> someWatched = new HashSet<string>(anyWatched);
        someWatched.ExceptWith(allWatched);
        // Фильмы, которые НИКТО не посмотрел
        HashSet<string> noneWatched = new HashSet<string>(allMovies);
        noneWatched.ExceptWith(anyWatched);
        return (allWatched, someWatched, noneWatched);
    }
    public static void PrintCons(string filePath)//Файл содержит текст на русском языке. Напечатать в алфавитном порядке все звонкие
                                                 //согласные буквы, которые входят более чем в одно слово.
    {
        string text = File.ReadAllText(filePath).ToLower();
        HashSet<char> Cons = new HashSet<char>
            {
                'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'л', 'м', 'н', 'р'
            };
        var words = text.Split(" .,!?;:()-—\"\'\n\r\t".ToCharArray(),
                            StringSplitOptions.RemoveEmptyEntries);

        Dictionary<char, int> WordCount = new Dictionary<char, int>();
        foreach (string word in words)
        {
            HashSet<char> CInWord = new HashSet<char>();

            foreach (char c in word)
            {
                if (Cons.Contains(c))
                {
                    CInWord.Add(c);
                }
            }

            foreach (char consonant in CInWord)
            {
                if (WordCount.ContainsKey(consonant))
                    WordCount[consonant]++;
                else
                    WordCount[consonant] = 1;
            }
        }

        var result = WordCount
            .Where(pair => pair.Value > 1)
            .Select(pair => pair.Key)
            .OrderBy(c => c);

        Console.WriteLine("Звонкие согласные, которые входят более чем в одно слово:");
        foreach (char consonant in result)
        {
            Console.WriteLine(consonant);
        }
    }
    public static float CalcAvEmployees(Dictionary<string, string> Data)
    //На вход программе подаются сведения о телефонах всех сотрудников некоторого учреждения. В
    //первой строке сообщается количество сотрудников N, каждая из следующих N строк имеет
    //следующий формат:
    //<Фамилия><Инициалы><телефон>
    //где <Фамилия> – строка, состоящая не более чем из 20 символов, <Инициалы> - строка, состоящая
    //не более чем из 4-х символов (буква, точка, буква, точка), <телефон> – семизначный номер, 3-я и
    //4, я, а также 5-я и 6-я цифры которого разделены символом «–». <Фамилия> и <Инициалы>, а
    //также <Инициалы> и <телефон> разделены одним пробелом. Пример входной строки:
    //Иванов П.С. 555-66-77
    //Сотрудники одного подразделения имеют один и тот же номер телефона. Номера телефонов в
    //учреждении отличаются только двумя последними цифрами. Требуется написать эффективную
    //программу, которая будет выводить на экран информацию, сколько в среднем сотрудников
    //работает в одном подразделении данного учреждения
    {
        if (Data.Count == 0) return 0;
        var dep = Data
            .GroupBy(x =>
        {
            string phone = x.Value;
            string cleanPhone = phone.Replace("-", "");
            return cleanPhone.Substring(0, cleanPhone.Length - 2);
        })
            .Select(g => g.Count());
        return (float)dep.Average(); //сложность О(N)
    }
}