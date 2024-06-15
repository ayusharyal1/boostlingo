using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostlingoApp.Domain.Entities
{
    public class UserEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Bio { get; set; }
        public decimal Version { get; set; }
    }
}
