namespace Project_7;

class Program{
    static public void Main(){
        bool s = false;
        int id;
        while(!s){
            Console.WriteLine("view by id - Display information about employees by id;");
            Console.WriteLine("add - Add a new entry to the end of the file;");
            Console.WriteLine("exit - Close program.");
            Console.Write("Select comand: ");
            string? comand = Console.ReadLine();
            switch (comand){
                case "view by id":
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Cooperator.OutputFromFile(id);
                    break;
                case "add":
                    Console.Clear();
                    Cooperator.InputInFile();
                    break;
                case "delite":
                    Console.Clear();
                    id = Convert.ToInt32(Console.ReadLine());
                    //Cooperator.DeliteInFile(id);
                    break;
                case "redact":
                    Console.Clear();
                    id = Convert.ToInt32(Console.ReadLine());
                    //Cooperator.DeliteInFile(id);
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
}