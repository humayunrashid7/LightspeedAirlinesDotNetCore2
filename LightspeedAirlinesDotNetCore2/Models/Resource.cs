using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LightspeedAirlinesDotNetCore2.Models
{
    public abstract class Resource
    {
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
