namespace Project_7;

struct Cooperator{
    public int id;
    public DateTime date, birthDay;
    public string? fullName;
    public byte age;
    public byte height;
    public string? birthPlace;

    static public void InputInFile(){
        string path = @"Information_Employees.txt";
        int id = 0;
        if(File.Exists(path)) 
            id = File.ReadAllLines(path).Length;
        DateTime date, birthDay = new DateTime();
        date = DateTime.Now;
        Console.Write("Full name: ");
        string? fullName = Console.ReadLine();
        Console.Write("Height: ");
        byte height = Convert.ToByte(Console.ReadLine());
        Console.Write("Birth day (Year.Month.Day): ");
        birthDay = Convert.ToDateTime(Console.ReadLine());
        Console.Write("Birth place: ");
        string? birthPlace = Console.ReadLine();
        byte age = Convert.ToByte(date.Year - birthDay.Year);
        using (StreamWriter sw = new StreamWriter(path, true)){
            id++;
            sw.WriteLine(id + "#" + date.ToString("dd/MM/yyyy HH:mm") + "#" + fullName + "#" + age + "#" + height + "#" + birthDay.ToString("dd/MM/yyyy") + "#" + birthPlace);
        }
        Console.Clear();
    }

    static public void OutputFromFile(){
        string path = @"Information_Employees.txt";
        using (StreamReader readFile = new StreamReader(path))
        {
            string? stringFromFile;
            while ((stringFromFile = readFile.ReadLine()) != null){
                string[] consoleWrite  = stringFromFile.Split('#');
                foreach (var el in consoleWrite){
                    Console.Write($"{el} ");
                }
                Console.WriteLine();
            }
        }
        Console.ReadLine();
        Console.Clear();
    }
    static public void OutputFromFile(int id){
        string path = @"Information_Employees.txt";
        StreamReader sr = new StreamReader(path);
        Console.WriteLine(File.ReadAllLines(path)[id]);
        sr.Close();
        Console.ReadLine();
        Console.Clear();
        }
/*
    static public void DeliteInFile(int id){
        string path = @"Information_Employees.txt";
        StreamReader sr = new StreamReader(path);
        var line = File.ReadAllLines(path).Where(id => !id.Contains($"{id}#"));
        File.WriteAllLines(path, line);
        sr.Close();
        Console.ReadLine();
        Console.Clear();
    }
    */
    /*
    static public void RedactInFile(int id){
        string path = @"Information_Employees.txt";
        using (StreamReader readFile = new StreamReader(path))
        {
            string? stringFromFile;
            while ((stringFromFile = readFile.ReadLine()) != null){
                if ( id == stringFromFile[0]){
                    
                }
                foreach (var el in consoleWrite){
                    Console.Write($"{el} ");
                }
                Console.WriteLine();
            }
        }
        Console.ReadLine();
        Console.Clear();
    }
    */
}