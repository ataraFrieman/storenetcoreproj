using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Api.Resources
{
    public class EntityBaseResource
    {
       public int Id { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public DateTime TimeUpdated { get; set; }
        public int? LastUpdateUserId { get; set; }
        public int CreatedUserId { get; set; }
        public bool IsDeleted { get; set; }  
    }
}