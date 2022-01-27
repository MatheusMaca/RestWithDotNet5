using RestWithDotNet5.Hypermedia;
using RestWithDotNet5.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestWithDotNet5.Data.VO
{
    public class PersonVO : ISupportsHyperMedia
    {
        //[JsonPropertyName("code")]
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        //[JsonIgnore()]
        public string Address { get; set; }

        public bool Enabled { get; set; }
        
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
