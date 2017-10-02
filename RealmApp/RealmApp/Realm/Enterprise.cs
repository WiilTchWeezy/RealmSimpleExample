using Realms;

namespace RealmApp.Realm
{
    public class Enterprise : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
