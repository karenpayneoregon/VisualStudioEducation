namespace EntityEffortExample
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return ID.ToString();
        }
    }
}