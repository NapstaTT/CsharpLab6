# Лабораторная работа по C# №6

Этот проект содержит решения 5 задач по работе с различными типами коллекций в C#: List, LinkedList, HashSet и Dictionary.

## Содержание

- [Задача 1: Удаление элементов из List](#задача-1)
- [Задача 2: Обратный порядок в LinkedList](#задача-2)
- [Задача 3: Анализ просмотров фильмов](#задача-3)
- [Задача 4: Звонкие согласные в тексте](#задача-4)
- [Задача 5: Анализ сотрудников по телефонам](#задача-5)

## Задача 1

### Удаление элементов с указанным значением из List

**Алгоритм решения:**
- Проходим по списку с конца к началу
- При нахождении элемента с заданным значением удаляем его
- Используем обратный обход для корректного удаления без нарушения индексов

```csharp
public static void DelFL(List<int> L, int x)
{
    for (int i = L.Count - 1; i >= 0; i--)
    {
        if (L[i] == x)
            L.RemoveAt(i);
    }
}
```

**Пример работы:**

---

## Задача 2

### Перестановка элементов между вхождениями в LinkedList

**Алгоритм решения:**
- Находим первое и последнее вхождение элемента E
- Собираем узлы между этими вхождениями
- Разворачиваем значения собранных узлов

```csharp
public static void SwapBetweenE(LinkedList<int> L, int E)
{
    // Поиск первого и последнего вхождения
    LinkedListNode<int> first = null, last = null;
    var current = L.First;
    while (current != null)
    {
        if (current.Value == E)
        {
            first ??= current;
            last = current;
        }
        current = current.Next;
    }
    
    // Сбор и разворот узлов между first и last
    // ... (основная логика)
}
```

**Пример работы:**

---

## Задача 3

### Анализ просмотров фильмов с использованием HashSet

**Алгоритм решения:**
- Используем операции над множествами:
  - **Пересечение** - фильмы, которые посмотрели все
  - **Разность** - фильмы, которые посмотрели некоторые/никто

```csharp
public static (HashSet<string> allWatched, HashSet<string> someWatched, HashSet<string> noneWatched)
    AnalyzeMovies(HashSet<string> allMovies, List<HashSet<string>> viewers)
{
    // Все посмотрели = пересечение множеств всех зрителей
    HashSet<string> allWatched = new HashSet<string>(viewers[0]);
    for (int i = 1; i < viewers.Count; i++)
    {
        allWatched.IntersectWith(viewers[i]);
    }
    
    // Остальная логика...
}
```

**Пример работы:**


---

## Задача 4

### Поиск звонких согласных в тексте

**Алгоритм решения:**
- Читаем текст из файла и приводим к нижнему регистру
- Разбиваем на слова, игнорируя пунктуацию
- Для каждого слова находим уникальные звонкие согласные
- Подсчитываем в скольких словах встречается каждая согласная

```csharp
public static void PrintCons(string filePath)
{
    HashSet<char> voicedConsonants = new HashSet<char> 
    { 
        'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'л', 'м', 'н', 'р' 
    };
    
    // Обработка текста и подсчет согласных
    // ...
}
```

**Пример работы:**

---

## Задача 5

### Анализ сотрудников по номерам телефонов

**Алгоритм решения:**
- Группируем сотрудников по подразделениям (первые 5 цифр телефона)
- Вычисляем среднее количество сотрудников на подразделение
- Используем Dictionary для эффективного группирования

```csharp
public static float CalcAvEmployees(Dictionary<string, string> employees)
{
    Dictionary<string, int> departmentCounts = new Dictionary<string, int>();
    
    foreach (var employee in employees)
    {
        string phone = employee.Value;
        string departmentKey = phone.Substring(0, 5); // Первые 5 цифр
        
        departmentCounts[departmentKey] = 
            departmentCounts.GetValueOrDefault(departmentKey, 0) + 1;
    }
    
    return (float)employees.Count / departmentCounts.Count;
}
```

**Пример работы:**

---

## Примечания

- Все методы реализованы как статические
- Включена обработка ошибок ввода
- Код следует принципам чистого кода
- Каждая задача независима и может тестироваться отдельно
