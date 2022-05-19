namespace Project_7;

class Program{
    static public void Main(){
        bool s = false;
        string path = @"Information_Employees.txt";
        List<Worker> workers = new List<Worker>();
        if((File.Exists(path)) && (File.ReadAllLines(path).Length != 0)){
            using (StreamReader readFile = new StreamReader(path))
            {
                string? stringFromFile;
                while ((stringFromFile = readFile.ReadLine()) != null){
                    string[] line  = stringFromFile.Split('#');
                    Worker worker = new Worker();
                    worker.Id = Convert.ToInt32(line[0]);
                    worker.Date = Convert.ToDateTime(line[1]);
                    worker.Fullname = line[2];
                    worker.Age = Convert.ToByte(line[3]);
                    worker.Height = Convert.ToByte(line[4]);
                    worker.Birthday = Convert.ToDateTime(line[5]);
                    worker.Birthplace = line[6];
                    workers.Add(worker);
                }
            }
        }
        while(!s){
            Console.WriteLine("view - View information about worker;");
            Console.WriteLine("add - Add a new entry to the end of the file;");
            Console.WriteLine("delite - Delite worker of the file;");
            Console.WriteLine("redact - Redact worker of the file;");
            Console.WriteLine("date_range - Date range entry workers of the file;");
            Console.WriteLine("sort_asc - Sort ascending date entry workers of the file;");
            Console.WriteLine("sort_des  - Sort descending date entry workers of the file;");
            Console.WriteLine("exit - Close program.");
            Console.Write("Select comand: ");
            string? comand = Console.ReadLine();
            bool sw = false;
            int id, i = 0;
            switch (comand){
                case "view":
                    Console.Clear();
                    ViewWorker(workers);
                    break;
                case "add":
                    Console.Clear();
                    workers.Add(AddWoker()); // Добавление элемента (объекта класса работник) в коллекцию
                    WriteToFile(workers, true, File.ReadAllLines(path).Length); // Запись новой записи в файл
                    break;
                case "delite":
                    Console.Clear();
                    Console.Write("Id woker: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    foreach(Worker el in DeliteWorker(workers, id)){ // Проходим по всем элементам коллекции с целью перезаписи файла
                        WriteToFile(workers, sw, i); // Перезапись файла
                        sw = true; // меняем флажок после первой записи, для того чтобы последующие записи добавлялись в файл, а не перезаписывались
                        i++;
                    }  
                    break;
                case "redact":
                    Console.Clear();
                    Console.Write("Id worker: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    foreach(Worker el in RedactWorker(workers, id)){ // Проходим по всем элементам коллекции с целью перезаписи файла
                        WriteToFile(workers, sw, i); // Перезапись файла
                        sw = true; // меняем флажок после первой записи, для того чтобы последующие записи добавлялись в файл, а не перезаписывались
                        i++;
                    }  
                    break;
                case "date_range":
                    Console.Clear();
                    DateRange(workers);
                    break;
                case "sort_asc":
                    Console.Clear();
                    SortAsc(workers);
                    break;
                case "sort_des":
                    Console.Clear();
                    SortDes(workers);
                    break;
                case "exit":
                    Console.Clear();
                    s = true;
                    break;
                default:
                    Console.WriteLine("Comand not found!");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }      
        }
        
    }
    ///<summary>
    /// Метод записи в консоль
    ///</summary>
    static public void Writer(List<Worker> workers, int id){
        Console.Write($"{workers[id].Id} ");
        Console.Write($"{workers[id].Date.ToString("dd/MM/yyyy HH:mm")} ");
        Console.Write($"{workers[id].Fullname} ");
        Console.Write($"{workers[id].Height} ");
        Console.Write($"{workers[id].Birthday.ToString("dd/MM/yyyy")} ");
        Console.WriteLine($"{workers[id].Birthplace}");
    }
    ///<summary>
    ///Метод записи в файл
    ///</summary>
    static public void WriteToFile(List<Worker> workers, bool sostWrite, int i){
        string path = @"Information_Employees.txt";
        int id = i + 1; // устанавливаем id записи в файле в зависимости от метода
        using (StreamWriter sw = new StreamWriter(path, sostWrite)){
            sw.Write($"{id}#");
            sw.Write($"{workers[i].Date.ToString("dd/MM/yyyy HH:mm")}#");
            sw.Write($"{workers[i].Fullname}#");
            sw.Write($"{workers[i].Age}#");
            sw.Write($"{workers[i].Height}#");
            sw.Write($"{workers[i].Birthday.ToString("dd/MM/yyyy")}#");
            sw.WriteLine($"{workers[i].Birthplace}");
        }
    }
    ///<summary>
    ///Метод добавления записи (считывание данных с консоли)
    ///</summary>
    static public Worker AddWoker(){
        string path = @"Information_Employees.txt";
        Worker worker = new Worker();
        worker.Id = File.ReadAllLines(path).Length + 1;
        worker.Date = DateTime.Now;
        Console.Write("Full name: ");
        worker.Fullname = Console.ReadLine();
        Console.Write("Height: ");
        worker.Height = Convert.ToByte(Console.ReadLine());
        Console.Write("Birth day (Year.Month.Day): ");
        worker.Birthday = Convert.ToDateTime(Console.ReadLine());
        Console.Write("Birth place: ");
        worker.Birthplace = Console.ReadLine();
        worker.Age = Convert.ToByte(worker.Date.Year - worker.Birthday.Year);
        return worker;
    }
    ///<summary>
    ///Метод вывода информации выбранного работника
    ///</summary>
    static public void ViewWorker(List<Worker> workers){
        Console.Write("Id woker: ");
        int id = Convert.ToInt32(Console.ReadLine());
        if (id >= workers.Count)
            Console.WriteLine("Woker not found.");
        else{
            Writer(workers, id - 1);
            Console.ReadLine();
            Console.Clear();
        } 
    }
    ///<summary>
    ///Метод удаления элемента из коллекции объектов структуры работники
    ///</summary>
    static public List<Worker> DeliteWorker (List<Worker> workers, int id){
        if (id > workers.Count)
            Console.WriteLine("Woker not found.");
        else {
            workers.RemoveAt(id-1);
        }
        return workers;
    }
    ///<summary>
    ///Метод редактирования (замены) элемента в коллекции объектов структуры работники
    ///</summary>
     static public List<Worker> RedactWorker (List<Worker> workers, int id) {
        if (id > workers.Count)
            Console.WriteLine("Woker not found.");
        else {
            Worker redactWorker = new Worker();
            redactWorker = AddWoker();
            redactWorker.Id = id;
            workers[id-1] = redactWorker;
        }
        return workers;
    }
    ///<summary>
    ///Загрузка записей в выбранном диапазоне дат
    ///</summary>
    static public void DateRange (List<Worker> workers) {
        Console.Write("Date start (Year.Month.Day): ");
        DateTime dateStart = Convert.ToDateTime(Console.ReadLine());
        Console.Write("Date end (Year.Month.Day): ");
        DateTime dateEnd = Convert.ToDateTime(Console.ReadLine());
        int i = 0;
        foreach(Worker el in workers){
            if((el.Date > dateStart) && (el.Date < dateEnd))
            Writer(workers, i);
            i++;
        }
        Console.ReadLine();
        Console.Clear();
    }
    ///<summary>
    ///Сортировка по возрастанию даты
    ///</summary>
    static public void SortAsc (List<Worker> workers) {
        Worker temp = new Worker();
        for (int i = 0; i < workers.Count; i++)
        {
            for (int j = i + 1; j < workers.Count; j++)
            {
                if (workers[i].Date > workers[j].Date)
                {
                    temp = workers[i];
                    workers[i] = workers[j];
                    workers[j] = temp;
                }                   
            }
            Writer(workers, i);              
        }
        Console.ReadLine();
        Console.Clear(); 
    }
    ///<summary>
    ///Сортировка по убыванию даты
    ///</summary>
    static public void SortDes (List<Worker> workers) {
        Worker temp = new Worker();
        for (int i = 0; i < workers.Count; i++)
        {
            for (int j = i + 1; j < workers.Count; j++)
            {
                if (workers[i].Date < workers[j].Date)
                {
                    temp = workers[i];
                    workers[i] = workers[j];
                    workers[j] = temp;
                }                   
            }
            Writer(workers, i);           
        }
        Console.ReadLine();
        Console.Clear(); 
    }
}