using Google.Cloud.Firestore;

namespace PeopleService.Models
{
    [FirestoreData]
    public class Person
    {
        [FirestoreDocumentId]
        public string? Id { get; set; }
        [FirestoreProperty]
        public string? Name { get; set; }
        [FirestoreProperty]
        public string? Email { get; set; }
        [FirestoreProperty]
        public PersonRole? PersonRole { get; set; }
        [FirestoreProperty]
        public PersonType? PersonType { get; set; }
        [FirestoreProperty]
        public string? CpfCnpj { get; set; }
        [FirestoreProperty]
        public string? Phone { get; set; }
        [FirestoreProperty]
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
