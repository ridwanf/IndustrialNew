namespace Industrial.Data.Domain
{
    public class Bank : BaseClass<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}