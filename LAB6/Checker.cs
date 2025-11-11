class Checker
{
    public static bool IsPositiveInt(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;
        bool isNumber = int.TryParse(input, out int number);
        return isNumber && number > 0;
    }

    public static int GetPositiveInt(string prompt = null)
    {
        if (prompt != null)
            Console.Write(prompt);

        string input = Console.ReadLine();

        while (!IsPositiveInt(input))
        {
            Console.WriteLine("Ошибка! Введите положительное целое число: ");
            input = Console.ReadLine();
        }
        return int.Parse(input);
    }
    public static int? TryParseInt(string input)
    {
        if (int.TryParse(input, out int result))
        {
            return result;
        }
        return null;
    }
    public static int? TryParsePositiveInt(string input)
    {
        if (int.TryParse(input, out int result) && result > 0)
        {
            return result;
        }
        return null;
    }
    public static int? TryParseNonNegativeInt(string input)
    {
        if (int.TryParse(input, out int result) && result >= 0)
        {
            return result;
        }
        return null;
    }
}