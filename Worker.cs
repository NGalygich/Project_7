namespace Project_7;

struct Worker{
    private int id;
    private DateTime date, birthDay;
    private string? fullName;
    private byte age;
    private byte height;
    private string? birthPlace;
    public int Id{ get{return id;} set{id = value;}}
    public DateTime Date{ get{return date;} set{date = value;}}
    public DateTime Birthday{ get{return birthDay;} set{birthDay = value;}}
    public string? Fullname{ get{return fullName;} set{fullName = value;}}
    public byte Age{ get{return age;} set{age = value;}}
    public byte Height{ get{return height;} set{height = value;}}
    public string? Birthplace{ get{return birthPlace;} set{birthPlace = value;}}

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