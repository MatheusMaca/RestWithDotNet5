using System.Collections.Generic;

namespace RestWithDotNet5.Hypermedia.Abstract
{
    public interface ISupportsHyperMedia
    {
        public List<HyperMediaLink> Links { get; set; }
    }
}
