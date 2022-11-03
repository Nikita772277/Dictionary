var valuePairs = new Dictionary<string, string>()
{
    ["Ананас"] = "Pineappl",
    ["Переводчик"] = "Translator ",
    ["Зависимость"] = "Dependence",
};
Console.WriteLine($"Введите слово");
string word = Console.ReadLine();
bool check = valuePairs.ContainsKey(word);
if (check == true)
{
    Console.WriteLine($"Слово есть в словаре");
}
else if (check == false)
{

    Console.WriteLine($"Такого слова нет введите перевод");
    string translation = Console.ReadLine();
    Console.WriteLine($"Хотите ли вы записать в словарь это слово и его перевод (введите да или нет)");
    while (true)
    {
        string enter = Console.ReadLine();
        if (enter == "да" || enter == "Да")
        {
            valuePairs.Add(translation, word);
            break;
        }
        else if (enter == "нет" || enter == "Нет")
        {
            Console.WriteLine();
            break;
        }
        else
        {
            Console.WriteLine($"Вы ввели некоректый ответ");
        }
    }
}
void Menu()
{
    Console.WriteLine();
    Console.WriteLine($"1) Добавить слово и его перевод");
    Console.WriteLine($"2) Получить все данные словаря");
    Console.WriteLine($"3) Проверка наличия перевода слова");
    Console.WriteLine($"4) Удалить слово и его перевод");
    Console.WriteLine($"5) Изменить перевод конкретного слова");
    Console.WriteLine();
}
void UseMenu()
{
    while (true)
    {
        Menu();
        string enter = Console.ReadLine();
        bool check = int.TryParse(enter, out int chec);
        Console.WriteLine();
        if (chec == 1)
        {
            Add();
        }
        if (chec == 2)
        {
            GetDictionary();
        }
        else if (chec == 3)
        {
            CheckValue();
        }
        else if (chec == 4)
        {
            Remove();
        }
        else if (chec == 5)
        {
            Key();
        }
        else
        {
            Console.WriteLine($"Выберите пункт из меню");
        }
    }
}
void Add()
{
    Console.WriteLine($"Введите слово которое хотите добавть");
    string word = Console.ReadLine();
    Console.WriteLine($"Введите превод которое хотите добавть");
    string translation = Console.ReadLine();
    valuePairs.Add(word, translation);
}
void GetDictionary()
{
    foreach (KeyValuePair<string, string> pair in valuePairs)
    {
        Console.WriteLine(pair);
    }
}
void CheckValue()
{
    Console.WriteLine($"Введите перевод который хотите проверить");
    string value = Console.ReadLine();
    bool verifiedvalue = valuePairs.ContainsValue(value);
    if (verifiedvalue == true)
    {
        Console.WriteLine($"Такой перевод есть в словаре");
    }
    else
    {
        Console.WriteLine($"Такого перевода нет в словаре");
    }
}
void Remove()
{
    Console.WriteLine($"Введите слова которое хотите удалить");
    string enter = Console.ReadLine();
    bool verifiedvalue = valuePairs.ContainsKey(enter);
    if (verifiedvalue == true)
    {
        bool checkremove = valuePairs.Remove(enter);
        if (checkremove == true)
        {
            Console.WriteLine($"слово и перевод удалены");
        }
        else
        {
            Console.WriteLine($"Не удалось удалить слово");
        }
    }
    else
    {
        Console.WriteLine($"Нет такого слова");
    }
}
void Key()
{
    Console.WriteLine($"Введите слово перевод которого вы хотите поменять");
    string enter = Console.ReadLine();
    bool verifiedvalue = valuePairs.ContainsKey(enter);
    if (verifiedvalue == true)
    {
        Console.WriteLine($"На какой перевод вы хотите поменять");
        string a = Console.ReadLine();
        valuePairs[enter] = $"{a}";
    }
    else
    {
        Console.WriteLine($"Нет такого слова");
    }
}
UseMenu();