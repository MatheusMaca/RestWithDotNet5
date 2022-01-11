using System.Collections.Generic;

namespace RestWithDotNet5.Hypermedia.Abstract
{
    public interface ISupportHyperMedia
    {
        public List<HyperMediaLink> Links { get; set; }
    }
}
