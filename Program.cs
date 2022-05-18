namespace Project_7;

class Program{
    static public void Main(){
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
        //Menu();
        /*
        Worker[] w = new Worker[4];
        for(int i=0;i<4;i++){
            w[i] = new Worker();
        }
        w[0].age = 22;
        */
       //Worker w = new Worker();
       //w.Print()
    }
    static public void Menu(){

    }

}