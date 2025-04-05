namespace PeopleService.Models
{
        public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public PersonRole? PersonRole { get; set; }
        public PersonType? PersonType { get; set; }
        public string? CpfCnpj { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }

    public enum PersonRole
    {
        Cliente = 0,
        Vendedor = 1,
        Fornecedor = 2
    }
    public enum PersonType
    {
        Fisica = 0,
        Juridica = 1
    }
}
