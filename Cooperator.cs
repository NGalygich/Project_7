namespace Project_7;

struct Worker{
    public int id;
    public DateTime date, birthDay;
    public string fullName;
    public byte age;
    public byte height;
    public string birthPlace;

    public Worker (int id, string fullName, byte age, byte height, DateTime birhtDay, DateTime date, string birthPlace){
        this.id = id;
        this.fullName = fullName;
        this.height = height;
        this.birthDay = birhtDay;
        this.birthPlace = birthPlace;
        this.age = age;
        this.date = date;
    }
   
}