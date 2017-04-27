namespace CustomJsonDeserializer
{
  public abstract class BaseClass
  {
    public string classType => this.GetType().FullName;
  }

  public abstract class Person : BaseClass
  {
    public string firstName { get; set; }
    public string lastName { get; set; }
  }

  public class Employee : Person
  {
    public double salary { get; set; }
  }

  public class President : Person
  {
    public int votes { get; set; }
  }
}
