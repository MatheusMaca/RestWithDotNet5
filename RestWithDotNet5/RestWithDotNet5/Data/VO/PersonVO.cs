namespace RestWithDotNet5.Data.VO
{
    public class PersonVO
    {
        //[JsonPropertyName("code")]
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        //[JsonIgnore()]
        public string Address { get; set; }
    }
}
