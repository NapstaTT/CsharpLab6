//Я не уверен в своём варианте, поэтому решал 5й(единственная информация - мой вариант нечетный и в начале)
namespace LAB6
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Введите номер задачи от 1 до 5");
                string? input = Console.ReadLine();
                if (Checker.IsPositiveInt(input))
                {
                    int? x = Convert.ToInt32(input);
                    switch (x)
                    {
                        case 1:
                            {
                                List<int> L = new List<int>();
                                Console.WriteLine("Введите длину списка");

                                while (true)
                                {
                                    input = Console.ReadLine();
                                    x = Checker.TryParsePositiveInt(input);

                                    if (x.HasValue)
                                    {
                                        Console.WriteLine("Введите элементы списка через клавишу enter");
                                        for (int i = 0; i < x.Value; i++)
                                        {
                                            Console.Write($"Элемент {i + 1}: ");
                                            input = Console.ReadLine();
                                            int? element = Checker.TryParseInt(input);

                                            if (element.HasValue)
                                            {
                                                L.Add(element.Value);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Ошибка! Введите целое число.");
                                                i--;
                                            }
                                        }
                                        Console.WriteLine("Введенный список: " + string.Join(", ", L));
                                        while (true)
                                        {
                                            Console.WriteLine("Какое значение удалить?");
                                            while (true)
                                            {
                                                input = Console.ReadLine();
                                                x = Checker.TryParseInt(input);

                                                if (x.HasValue)
                                                {
                                                    LAB6N15.DelFL(L, x.Value);
                                                    Console.WriteLine("Получившийся список: " + string.Join(", ", L));
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Ошибка! Введите целое число для удаления:");
                                                }
                                            }
                                            break;
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ошибка! Введите положительное целое число для длины списка:");
                                    }
                                }
                                break;
                            }
                        case 2:
                            {
                                LinkedList<int> L = new LinkedList<int>();
                                Console.WriteLine("Введите длину связного списка");
                                int? length = null;
                                while (!length.HasValue)
                                {
                                    input = Console.ReadLine();
                                    length = Checker.TryParsePositiveInt(input);
                                    if (!length.HasValue)
                                    {
                                        Console.WriteLine("Ошибка! Введите положительное целое число для длины списка:");
                                    }
                                }
                                Console.WriteLine("Введите элементы списка через клавишу enter");
                                for (int i = 0; i < length.Value; i++)
                                {
                                    Console.Write($"Элемент {i + 1}: ");

                                    x = null;
                                    while (!x.HasValue)
                                    {
                                        input = Console.ReadLine();
                                        x = Checker.TryParseInt(input);
                                        if (!x.HasValue)
                                        {
                                            Console.WriteLine("Ошибка! Введите целое число:");
                                        }
                                    }

                                    L.AddLast(x.Value);
                                }
                                Console.WriteLine("Заполненный список: " + string.Join(" -> ", L));
                                Console.WriteLine("Введите значение элемента E:");
                                x = null;
                                while (!x.HasValue)
                                {
                                    input = Console.ReadLine();
                                    x = Checker.TryParseInt(input);
                                    if (!x.HasValue)
                                    {
                                        Console.WriteLine("Ошибка! Введите целое число для E:");
                                    }
                                }

                                // Вызов метода и вывод результата
                                LAB6N15.SwapBetweenE(L, x.Value);
                                Console.WriteLine("Список после изменений: " + string.Join(" -> ", L));
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Введите количество фильмов:");
                                x = null;
                                while (!x.HasValue)
                                {
                                    x = Checker.TryParsePositiveInt(Console.ReadLine());
                                    if (!x.HasValue)
                                        Console.WriteLine("Ошибка! Введите положительное целое число:");
                                }

                                HashSet<string> allMovies = new HashSet<string>();
                                Console.WriteLine("Введите названия фильмов:");
                                for (int i = 0; i < x.Value; i++)
                                {
                                    Console.Write($"Фильм {i + 1}: ");
                                    string movie = Console.ReadLine();
                                    allMovies.Add(movie);
                                }

                                Console.WriteLine("\nСписок всех фильмов: " + string.Join(", ", allMovies));

                                Console.WriteLine("\nВведите количество зрителей:");
                                x = null;
                                while (!x.HasValue)
                                {
                                    x = Checker.TryParsePositiveInt(Console.ReadLine());
                                    if (!x.HasValue)
                                        Console.WriteLine("Ошибка! Введите положительное целое число:");
                                }

                                List<HashSet<string>> viewers = new List<HashSet<string>>();
                                for (int i = 0; i < x.Value; i++)
                                {
                                    Console.WriteLine($"\nЗритель {i + 1}:");

                                    Console.WriteLine("Сколько фильмов посмотрел этот зритель?");
                                    int? watchedCount = null;
                                    while (!watchedCount.HasValue)
                                    {
                                        watchedCount = Checker.TryParseNonNegativeInt(Console.ReadLine());
                                        if (!watchedCount.HasValue)
                                            Console.WriteLine("Ошибка! Введите неотрицательное целое число:");
                                    }

                                    HashSet<string> watchedMovies = new HashSet<string>();
                                    for (int j = 0; j < watchedCount.Value; j++)
                                    {
                                        Console.Write($"Просмотренный фильм {j + 1}: ");
                                        string movie = Console.ReadLine();
                                        watchedMovies.Add(movie);
                                    }

                                    viewers.Add(watchedMovies);

                                    Console.WriteLine($"Фильмы зрителя {i + 1}: " + string.Join(", ", watchedMovies));
                                }

                                var result = LAB6N15.AnalyzeMovies(allMovies, viewers);

                                Console.WriteLine("\n=== РЕЗУЛЬТАТЫ АНАЛИЗА ===");
                                Console.WriteLine("Все просмотренные фильмы: " + string.Join(", ", result.allWatched));
                                Console.WriteLine("Фильмы, просмотренные некоторыми: " + string.Join(", ", result.someWatched));
                                Console.WriteLine("Непросмотренные фильмы: " + string.Join(", ", result.noneWatched));
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Работа с текстовым файлом");
                                Console.WriteLine("Введите полный путь до файла:");

                                string filePath;
                                bool fileExists = false;

                                while (!fileExists)
                                {
                                    filePath = Console.ReadLine();

                                    if (string.IsNullOrWhiteSpace(filePath))
                                    {
                                        Console.WriteLine("Ошибка! Путь не может быть пустым. Введите путь снова:");
                                        continue;
                                    }

                                    if (File.Exists(filePath))
                                    {
                                        fileExists = true;
                                        Console.WriteLine("Файл найден!");
                                        LAB6N15.PrintCons(filePath);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Файл не найден! Проверьте путь и введите снова:");
                                    }
                                }
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Введите количество сотрудников:");
                                Dictionary<string, string> employees = new Dictionary<string, string>();
                                int? employeesCount = null;
                                while (!employeesCount.HasValue)
                                {
                                    employeesCount = Checker.TryParsePositiveInt(Console.ReadLine());
                                    if (!employeesCount.HasValue)
                                        Console.WriteLine("Ошибка! Введите положительное целое число:");
                                }

                                for (int i = 0; i < employeesCount.Value; i++)
                                {
                                    Console.WriteLine($"\nСотрудник {i + 1}:");
                                    Console.Write("Введите Фамилию и Инициалы (например: Иванов И.И.): ");
                                    string fullName;
                                    while (true)
                                    {
                                        fullName = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(fullName))
                                        {
                                            Console.WriteLine("Ошибка! Поле не может быть пустым. Введите снова:");
                                            continue;
                                        }

                                        if (employees.ContainsKey(fullName))
                                        {
                                            Console.WriteLine("Ошибка! Такой сотрудник уже существует. Введите другое ФИО:");
                                            continue;
                                        }

                                        break;
                                    }

                                    Console.Write("Введите телефон (формат: 555-66-44): ");
                                    string phone;
                                    while (true)
                                    {
                                        phone = Console.ReadLine();

                                        if (string.IsNullOrWhiteSpace(phone))
                                        {
                                            Console.WriteLine("Ошибка! Телефон не может быть пустым. Введите снова:");
                                            continue;
                                        }
                                        string cleanedPhone = new string(phone.Where(char.IsDigit).ToArray());

                                        if (cleanedPhone.Length != 7)
                                        {
                                            Console.WriteLine($"Ошибка! После удаления дефисов/пробелов осталось {cleanedPhone.Length} цифр, а должно быть 7. Введите снова:");
                                            continue;
                                        }

                                        phone = cleanedPhone;
                                        break;
                                    }

                                    employees.Add(fullName, phone);
                                    Console.WriteLine("Данные сотрудника добавлены!");
                                }
                                float average = LAB6N15.CalcAvEmployees(employees);
                                Console.WriteLine($"\nСреднее число сотрудников в подразделении: {average:F2}");
                                
                                Console.WriteLine("\nВведенные данные:");
                                foreach (var employee in employees)
                                {
                                    string formattedPhone = $"{employee.Value.Substring(0, 3)}-{employee.Value.Substring(3, 2)}-{employee.Value.Substring(5, 2)}";
                                    Console.WriteLine($"{employee.Key}: {formattedPhone}");
                                }
                                break;
                            }
                        default: Console.WriteLine("Неверный номер задачи"); break;
                    }
                }
            }
        }
    }
}