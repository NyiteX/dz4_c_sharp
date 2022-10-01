using System;

class Programm
{
    static void Main()
    {
        Journal J = new();
        Magazine M = new();
        ListofBooks books = new();
        char vvod;
        do
        {
            Console.Clear();
            Console.WriteLine("1.Part 1\n2.Part 2\n3.Part 3\n");
            vvod = Console.ReadKey().KeyChar;

            switch (vvod)
            {
                case '1':
                    {
                        try { 
                        Console.Clear();                    
                        Console.WriteLine("Кол-во сотрудников: "+J.getSotrudnik_kol());
                        Console.WriteLine("Сколько добавить сотрудников ?");
                        int v = int.Parse(Console.ReadLine());
                        J += v;
                        Console.WriteLine("кол-во сотрудников: " + J.getSotrudnik_kol());
                        Console.WriteLine("Сколько отнять сотрудников ?");
                        v = int.Parse(Console.ReadLine());
                        J -= v;
                        Journal tmp = new();
                        Console.Write(tmp.getSotrudnik_kol() + " == "+J.getSotrudnik_kol() + " is ");
                        Console.Write(tmp == J);
                        Console.Write("\n" +tmp.getSotrudnik_kol() + " < " + J.getSotrudnik_kol() + " is ");
                        Console.WriteLine(tmp < J);         
                        }
                        catch (Exception) { Console.WriteLine("Wrong input"); }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    }
                case '2':
                    {
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Площадь магазина: " + M.getPloshad());
                            Console.WriteLine("Сколько добавить площади ?");
                            double v = double.Parse(Console.ReadLine());
                            M += v;
                            Console.WriteLine("Площадь магазина: " + M.getPloshad());
                            Console.WriteLine("Сколько отнять площади ?");
                            v = double.Parse(Console.ReadLine());
                            M -= v;
                            Magazine tmp = new();
                            Console.Write(tmp.getPloshad() + " == " + M.getPloshad() + " is ");
                            Console.Write(tmp == M);
                            Console.Write("\n" + tmp.getPloshad() + " < " + M.getPloshad() + " is ");
                            Console.WriteLine(tmp < M);
                        }
                        catch (Exception) { Console.WriteLine("Wrong input"); }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    }
                case '3':
                    {                        
                        char vvod2;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("1.Add\n2.Search\n3.Delete\n4.PrintAll\n5.Edit(name)\n6.Edit(avtorname)\n7.Edit(year)\n");
                            vvod2 = Console.ReadKey().KeyChar;
                            switch(vvod2)
                            {
                                case '1':
                                    Console.Clear();
                                    books.AddBook();
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadKey();
                                    break;
                                case '2':
                                    Console.Clear();
                                    books.SearchByName();
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadKey();
                                    break;
                                case '3':
                                    Console.Clear();
                                    books.DeleteByName(books.SearchByName());
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadKey();
                                    break;
                                case '4':
                                    Console.Clear();
                                    books.PrintAll();
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadKey();
                                    break;
                                case '5':
                                    Console.Clear();
                                    books.Edit(1, books.SearchByName());
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadKey();
                                    break;
                                case '6':
                                    Console.Clear();
                                    books.Edit(2, books.SearchByName());
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadKey();
                                    break;
                                case '7':
                                    Console.Clear();
                                    books.Edit(3, books.SearchByName());
                                    Console.WriteLine("\nPress any key to continue.");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (vvod != 27);
   
                        break;
                    }
            }
        } while (vvod != 27);
    }
}


class Journal
{
    private string? name;
    private string? email;
    private string? phone, discription;
    private int year;
    private int kol_sotrudnikov;

    public Journal(string? name = "Alo", string? email = "alo@gmail.com", string? phone = "+380923891823", int year = 1923, int kol = 1)
    {
        this.name = name;
        this.email = email;
        this.phone = phone;
        this.year = year;
        kol_sotrudnikov = kol;
    }
    public void setName(string? nam) { this.name = nam; }
    public void setEmail(string? email) { this.email = email; }
    public void setPhone(string? phone) { this.phone = phone; }
    public void setDiscription() { discription = Vvod(); }
    public void setYear() { VvodYear(); }
    public string getName() { return name; }
    public string getEmail() { return email; }
    public string getPhone() { return phone; }
    public string getDiscription() { return discription; }
    public int getYear() { return year; }
    public int getSotrudnik_kol() { return kol_sotrudnikov; }
    public void Print_All()
    {
        Console.WriteLine("Name: " + name + "\nEmail: " + email + "\nPhone: " + phone);
        Console.WriteLine("Year: " + year + "\nDiscription: " + discription);
    }
    public bool Prover(string? str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (!Char.IsDigit(str[i]))
                return false;
        }
        return true;
    }
    public string Vvod()
    {
        string? str;
        Console.WriteLine("Enter text here: ");
        str = Console.ReadLine();

        char[] str2 = str.ToCharArray();
        bool first = true;
        for (int i = 0; i < str2.Length; i++)
        {
            if (first && Char.IsLetter(str[i]))
            {
                str2[i] = Char.ToUpper(str2[i]);
                first = false;
            }
            if (i > 0)
            {
                if (str[i - 1] == '.' || str[i - 1] == '!' || str[i - 1] == '?')
                {
                    while (!Char.IsLetter(str[i]))
                    {
                        if (i + 1 < str2.Length)
                            i++;
                        else
                            break;
                    }
                    str2[i] = Char.ToUpper(str2[i]);
                }
            }
        }
        return new string(str2);
    }
    public void VvodYear()
    {
        string? str = "as";
        Console.WriteLine("Введите год основания " + "'" + name + "'");
        while (str.Length < 1 || !Prover(str) || int.Parse(str) > 2022 || int.Parse(str) < 1500)
        {
            str = Console.ReadLine();
            if (str.Length < 1 || !Prover(str) || int.Parse(str) > 2022 || int.Parse(str) < 1500)
                Console.WriteLine("Ошибка. Введите цифры от 1500 до 2022.");
        }
        year = int.Parse(str);
    }
    public static Journal operator +(Journal j1,int j2)
    {
        return new Journal { kol_sotrudnikov = j1.kol_sotrudnikov + j2 };
    }
    public static Journal operator -(Journal j1, int j2)
    {
        return new Journal { kol_sotrudnikov = j1.kol_sotrudnikov - j2 };
    }
    public static bool operator <(Journal j1, Journal j2)
    {
        return j1.kol_sotrudnikov < j2.kol_sotrudnikov;
    }
    public static bool operator >(Journal j1, Journal j2)
    {
        return j1.kol_sotrudnikov > j2.kol_sotrudnikov;
    }
    public static bool operator ==(Journal j1,Journal j2)
    {
        return j1.kol_sotrudnikov==j2.kol_sotrudnikov;
    }
    public static bool operator !=(Journal j1, Journal j2)
    {
        return j1.kol_sotrudnikov != j2.kol_sotrudnikov;
    }
}
class Magazine
{
    private string? name;
    private string? email;
    private string? phone, discription;
    double ploshad;

    public Magazine(string? name = "Alo", string? email = "alo@gmail.com", string? phone = "+380923891823", double ploshad = 11.5)
    {
        this.name = name;
        this.email = email;
        this.phone = phone;
        this.ploshad = ploshad;
    }
    public void setName(string? nam) { this.name = nam; }
    public void setEmail(string? email) { this.email = email; }
    public void setPhone(string? phone) { this.phone = phone; }
    public void setDiscription() { discription = Vvod(); }

    public string getName() { return name; }
    public string getEmail() { return email; }
    public string getPhone() { return phone; }
    public string getDiscription() { return discription; }
    public double getPloshad() { return ploshad; }

    public void Print_All()
    {
        Console.WriteLine("Name: " + name + "\nEmail: " + email + "\nPhone: " + phone);
        Console.WriteLine("Discription: " + discription);
    }
    public string Vvod()
    {
        string? str;
        Console.WriteLine("Enter text here: ");
        str = Console.ReadLine();

        char[] str2 = str.ToCharArray();
        bool first = true;
        for (int i = 0; i < str2.Length; i++)
        {
            if (first && Char.IsLetter(str[i]))
            {
                str2[i] = Char.ToUpper(str2[i]);
                first = false;
            }
            if (i > 0)
            {
                if (str[i - 1] == '.' || str[i - 1] == '!' || str[i - 1] == '?')
                {
                    while (!Char.IsLetter(str[i]))
                    {
                        if (i + 1 < str2.Length)
                            i++;
                        else
                            break;
                    }
                    str2[i] = Char.ToUpper(str2[i]);
                }
            }
        }
        return new string(str2);
    }
    public static Magazine operator +(Magazine j1, double j2)
    {
        return new Magazine { ploshad = j1.ploshad + j2 };
    }
    public static Magazine operator -(Magazine j1, double j2)
    {
        return new Magazine { ploshad = j1.ploshad - j2 };
    }
    public static bool operator <(Magazine j1, Magazine j2)
    {
        return j1.ploshad < j2.ploshad;
    }
    public static bool operator >(Magazine j1, Magazine j2)
    {
        return j1.ploshad > j2.ploshad;
    }
    public static bool operator ==(Magazine j1, Magazine j2)
    {
        return j1.ploshad == j2.ploshad;
    }
    public static bool operator !=(Magazine j1, Magazine j2)
    {
        return j1.ploshad != j2.ploshad;
    }
}
class Book
{
    string? name ="";
    string? avtorname = "";
    int year;
    public string? Name
    {
        get { return name; }
        set { name = value; }
    }
    public string? Avtorname
    {
        get { return avtorname; }
        set { avtorname = value; }
    }
    public int Year
    {
        get { return year; }
        set { year = value; }
    }
    public void Print()
    {
        Console.WriteLine("Название: " + name);
        Console.WriteLine("Автор: " + avtorname);
        Console.WriteLine("Год издания: " + year + '\n');
    }
}
class ListofBooks
{
    Book[] books;
    public ListofBooks()
    {
        books = new Book[1];
        books[0] = new Book();
    }
    public bool Prover(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (!Char.IsDigit(str[i]))
                return false;
        }
        return true;
    }
    public void AddBook()
    {
        if (books[0].Name.Length > 1)
        {
            Array.Resize(ref books, books.Length + 1);
            books[books.Length - 1] = new Book();
        }
        Console.WriteLine("Добавление книг.\n\nВведите имя книги: ");
        books[books.Length - 1].Name = Console.ReadLine();
        Console.WriteLine("Введите имя автора: ");
        books[books.Length - 1].Avtorname = Console.ReadLine();        
        string? year = "asd";
        while(!Prover(year) || int.Parse(year) > 2022)
        {
            Console.WriteLine("Введите год издания: ");
            year = Console.ReadLine();
            if(!Prover(year) || int.Parse(year) > 2022)
                Console.WriteLine("Ошибка ввода.");
        }
        books[books.Length - 1].Year = int.Parse(year);        
    }
    public void PrintAll()
    {
        if(books[0].Name.Length > 1)
        for (int i = 0; i < books.Length; i++)
        {
            Console.WriteLine((i + 1) +": ");
            books[i].Print();
        }
        else
            Console.WriteLine("Список пуст.");
    }
    public int SearchByName()
    {
        if (books[0].Name.Length > 1)
        {
            Console.WriteLine("Имя искомой книги: ");
            string? str = Console.ReadLine();
            int id = Array.FindIndex(books, x => x.Name == str);
            if (id == -1)
                Console.WriteLine("Ненайдено.\n");
            else
            {
                Console.WriteLine("Найдено.\n");
                books[id].Print();
            }
            return id;
        }
        else 
        {
            Console.WriteLine("Список пуст.");
            return -1;
        }
    }
    public void DeleteByName(int id)
    {
        if (id != -1)
        {
            for (int i = id; i < books.Length - 1; i++)
            {
                books[i] = books[i + 1];
            }
            Array.Resize(ref books, books.Length - 1);
        }
    }
    public void Edit(int f, int id)
    {
        if (books[0].Name.Length > 1)
        {
            if (f == 1)
            {
                Console.Write("Введите имя: ");
                books[id].Name = Console.ReadLine();
            }
            if (f == 2)
            {
                Console.Write("Введите имя автора: ");
                books[id].Avtorname = Console.ReadLine();
            }
            if (f == 3)
            {
                string? str = "asd";
                Console.Write("Введите год: ");
                while (!Prover(str))
                {
                    str = Console.ReadLine();
                    if (!Prover(str)) Console.WriteLine("Ошибка.\nВведите год.");
                }
                books[id].Year = int.Parse(str);
            }
        }
    }
}