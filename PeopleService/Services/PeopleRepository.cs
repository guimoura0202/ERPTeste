using Google.Cloud.Firestore;
using PeopleService.Models;

namespace PeopleService.Services
{
    public class PeopleRepository
    {
        private readonly FirestoreDb _db;
        private readonly CollectionReference _peopleCollection;

        public PeopleRepository(FirestoreDb db)
        {
            _db = db;
            _peopleCollection = _db.Collection("people");
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            QuerySnapshot snapshot = await _peopleCollection.GetSnapshotAsync();
            return snapshot.Documents.Select(doc => doc.ConvertTo<Person>());
        }

        public async Task<Person?> GetByIdAsync(string id)
        {
            DocumentReference docRef = _peopleCollection.Document(id);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                return snapshot.ConvertTo<Person>();
            }
            return null;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            DocumentReference addedDoc = await _peopleCollection.AddAsync(person);
            person.Id = addedDoc.Id;
            return person;
        }

        public async Task UpdateAsync(string id, Person person)
        {
            DocumentReference docRef = _peopleCollection.Document(id);
            await docRef.SetAsync(person, SetOptions.Overwrite);
        }

        public async Task DeleteAsync(string id)
        {
            DocumentReference docRef = _peopleCollection.Document(id);
            await docRef.DeleteAsync();
        }
    }
}
