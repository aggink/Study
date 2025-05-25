namespace Study.Lab3.Storage.Models.Shelter
{
    public class Adoption
    {

        public int Id { get; set; }

        public int Price { get; set; }

        public int CustomerId { get; set; }

        public int CatId { get; set; }

        public DateTime AdoptionDate { get; set; }

        public string Status { get; set; }
    }
}
