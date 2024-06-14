using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostlingoApp.Domain.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Bio { get; set; }
        public float Version { get; set; }
    }
}
