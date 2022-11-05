
using System.Text.RegularExpressions;
using System;
using System.Xml.Linq;

var translation1 = new List<string>() { "Pineapple","fgas" };
var translation2 = new List<string>() { "Translator" };
var translation3 = new List<string>() { "Dependence" };
var valuePairs = new Dictionary<string, List<string>>()
{
    ["a"]=new List<string>() {"gas","uyh" },
    ["Ананас"] = translation1,
    ["Переводчик"] = translation2,
    ["Зависимость"] = translation3,
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
            valuePairs.Add(translation, new List<string>() { word });
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
    Console.WriteLine($"1) Добавить слово и его перевод");//Работает
    Console.WriteLine($"2) Получить все данные словаря");//Не работает
    Console.WriteLine($"3) Проверка наличия перевода слова");//Работает
    Console.WriteLine($"4) Удалить слово и его переводы");//Работает
    Console.WriteLine($"5) Заменить перевод конкретного слова");//не работает (необходимо удастовериться)
    Console.WriteLine($"6) Удалить конкретный перевод");//Работает (необходимо удастовериться)
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
        else if (chec == 6)
        {
            DeleteATranslation();
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
    valuePairs.Add(word, new List<string>() { translation });
}
void GetDictionary()
{
    foreach (var pair in valuePairs)
    {
       
        Console.WriteLine(pair);
    }
}
void CheckValue()
{
    Console.WriteLine($"Введите слово перевод которого хотите проверить");
    string checkkey = Console.ReadLine();
    bool verifiedkey = valuePairs.ContainsKey(checkkey);
    if (verifiedkey == true)
    {
        valuePairs.TryGetValue(checkkey, out var foundelement);
        Console.WriteLine($"Введите перевод который хотите проверить");
        string value = Console.ReadLine();
        var verifiedvalue = foundelement.Contains(value);
        //bool verifiedvalue = valuePairs.ContainsValue(value);
        if (verifiedvalue == true)
        {
            Console.WriteLine($"Такой перевод есть в словаре");
        }
        else
        {
            Console.WriteLine($"Такого перевода нет в словаре");
        }
    }
    else
    {
        Console.WriteLine($"Такого слова нет");
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
    Console.WriteLine($"Введите слово перевод которого вы хотите заменить");
    string enter = Console.ReadLine();
    valuePairs.TryGetValue(enter, out var foundelement);
    bool verifiedvalue = valuePairs.ContainsKey(enter);
    if (verifiedvalue == true)
    {
        Console.WriteLine($"Какой перевод вы хотите заменить");
        string which = Console.ReadLine();
        bool checkvalue= foundelement.Contains(which);
        if(checkvalue == true)
        {
            Console.WriteLine($"На какой перевод вы хотите заменть");
            string onwhich = Console.ReadLine();
            foundelement.Remove(which);
            foundelement.Add(onwhich);
        }
        else
        {
            Console.WriteLine($"Нет такого перевода");
        }
    }
    else
    {
        Console.WriteLine($"Нет такого слова");
    }
}
void DeleteATranslation()
{
    Console.WriteLine($"Введите слово перевод которого вы хотите удалить");
    string enter = Console.ReadLine();
    valuePairs.TryGetValue(enter, out var foundelement);
    bool verifiedvalue = valuePairs.ContainsKey(enter);
    if (verifiedvalue == true)
    {
        Console.WriteLine($"Введите перевод который хотите удалить");
        string word = Console.ReadLine();
        bool checkvalue = foundelement.Contains(word);
        if (checkvalue == true)
        {

            if (foundelement.Count>1)  
            {
               bool a= foundelement.Remove(word);
                if(a == true)
                {
                    Console.WriteLine($"Превод удалён");
                }
                else
                {
                    Console.WriteLine($"Перевод не удалён");
                }
            }
            else
            {
                Console.WriteLine("Перевод всего один удаление невозможно");
            }
        }
            
        
    }
    else
    {
        Console.WriteLine($"Нет такого слова");
    }
}
UseMenu();