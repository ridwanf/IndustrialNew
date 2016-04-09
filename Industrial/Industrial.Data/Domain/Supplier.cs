using System;
using System.Reflection.Emit;

namespace Industrial.Data.Domain
{
    public class Supplier:BaseClass<int>
    {
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime ContractDate { get; set; }
        public string PicName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string FaxNumber { get; set; }
        public string FaxNumber2 { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
    }
}