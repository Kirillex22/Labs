

class Anytypes<T>
{
    private List<T> mas;
    public Anytypes()
    {
        mas = new List<T>();
    }
    public void Add(T element)
    {
        mas.Add(element);
    }
    public void Remove(T element)
    {
        mas.Remove(element);
    }
    public T Get(int index)
    {
        return mas[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Anytypes<object> mas = new Anytypes<object>();

        mas.Add("U");
        mas.Add(2323232323);
        mas.Add(true);
        mas.Remove("U");
        mas.Get(0);
        
    }
}
