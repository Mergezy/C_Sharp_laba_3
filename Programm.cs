static void Main(string[] args)
{
    Student[] student = new Student[3];

    for(int i = 0; i < student.Length; i++) 
    {
        student[i] = new Student
        {
            Name = "",
            Group = "",
            Source = new byte [student.Length]
        };
    }

    for(int i = 0; i < student.Length-1;i++) 
    { 
        for(int j = 0; j < student.Length-1-i; j++)
        {
            if (student[j].Average() > student[j+1].Average())
            {
                Student temp = student[j];
                student[j] = student[j+1];
                student[j+1] = temp;
            }
        }
    }

    for(int i = 0; i < student.Length; i++) 
    {
        student[i].ToString();
    }
}
struct Student
{
    private string name;
    private string group;
    private byte[] source;

    public string Name
    {
        get { return name; }
        set
        {
            Console.Write("Введите имя: ");
            string inputName = Console.ReadLine();
            if (nameIsMatch(inputName))
                name = inputName;
            else
            {
                Console.WriteLine("Некорректное имя.");
                while (nameIsMatch(inputName) != true)
                {
                    Console.Write("Введите имя: ");
                    inputName = Console.ReadLine();

                }
                name = inputName;
            }
        }
    }

    public string Group
    {
        get { return group; }
        set
        {
            Console.Write("Введите группу: ");
            string inputGroup = Console.ReadLine();
            if (groupIsMatch(inputGroup))
                group = inputGroup;
            else
            {
                Console.WriteLine("Некорректная группа.");
                while (groupIsMatch(inputGroup) != true)
                {
                    Console.Write("Введите группу: ");
                    inputGroup = Console.ReadLine();
                }
                group = inputGroup;
            }
        }
    }
    public byte[] Source
    {
        get { return source; }
        set
        {
            source = new byte[5];
            string temp;
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Введите {i + 1} оценку студента {Name}: ");
                try
                {
                    temp = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(temp)) // обработка пустого ввода
                        throw new Exception("Введена пустая строка");
                    source[i] = byte.Parse(temp);
                    if (source[i] > 5)
                        throw new Exception("Оценка должна быть от 1 до 5");
                }
                catch (Exception ex)
                {
                    i--;
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
    static bool groupIsMatch(string group)
    {
        string pattern = @"^(1[8-9]|2[0-4])(ИТ|ПТ)([1-6]([0-9])?)$";
        return Regex.IsMatch(group, pattern);
    }
    static bool nameIsMatch(string name)
    {
        string pattern = @"^[а-яА-Яa-zA-Z]{2,}$";
        return Regex.IsMatch(name, pattern);
    }
    public void ToString()
    {
        Console.WriteLine($"{Name} из группы {Group} имеет средний арифметический балл: {Average()}");
    }
    public double Average()
    {
        double avg = 0;
        foreach (byte b in Source) { avg += b; }
        return avg / 5;
    }
}
