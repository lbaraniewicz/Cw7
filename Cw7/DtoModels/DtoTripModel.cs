namespace Cw7.DtoModels
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Country
    {
        public string Name { get; set; }
    }

    public class DtoTripModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }
        public List<Country> Countries { get; set; }
        public List<Client> Clients { get; set; }
    }
}
