public class Product
{
    string code;
    string name;
    string agency;
    string price;
    string desc;

    public Product()
    {

    }

    public Product(string code, string name, string agency, string price, string desc)
    {
        this.code = code;
        this.name = name;
        this.agency = agency;
        this.price = price;
        this.desc = desc;
    }

    public string Code { get => code; set => code = value; }
    public string Name { get => name; set => name = value; }
    public string Agency { get => agency; set => agency = value; }
    public string Price { get => price; set => price = value; }
    public string Desc { get => desc; set => desc = value; }

    public override string? ToString()
    {
        return $"{this.code}, {this.name}, {this.agency}, {this.price}, {this.desc}";
    }
}