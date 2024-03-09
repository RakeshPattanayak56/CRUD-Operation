namespace CrudUsingnetCore.Models
{
    public class response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Employee Employee { get; set; }
        public List<Employee> lstEmployee { get; set; }
    }
}
