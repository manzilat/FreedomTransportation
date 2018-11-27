using System;

namespace FreedomTransportation.Controllers
{
    internal class ResponseCacheAttribute : Attribute
    {
        public int Duration { get; set; }
        public bool NoStore { get; set; }
        public object Location { get; set; }
    }
}