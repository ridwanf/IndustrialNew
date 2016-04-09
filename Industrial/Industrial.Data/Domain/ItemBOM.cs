namespace Industrial.Data.Domain
{
    public class ItemBOM:BaseClass<int>
    {
        public string Name { get; set; }
        public string BaseUOM { get; set; }
    }
}