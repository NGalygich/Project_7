namespace Project_7;

class Program{
    static public void Main(){
        int i = 0;
        string path = @"Information_Employees.txt";
        List<Worker> workers = new List<Worker>();
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
        Menu();
        using (StreamWriter sw = new StreamWriter(path, true)){
            i++;
            sw.Write($"{workers[i].Id}#");
            sw.Write($"{workers[i].Date.ToString("dd/MM/yyyy HH:mm")}#");
            sw.Write($"{workers[i].Fullname}#");
            sw.Write($"{workers[i].Age}#");
            sw.Write($"{workers[i].Height}#");
            sw.Write($"{workers[i].Birthday.ToString("dd/MM/yyyy")}#");
            sw.WriteLine($"{workers[i].Birthplace}");
        }
    }
    static public void Menu(){
        
    }

}