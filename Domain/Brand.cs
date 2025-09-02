using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Brand : BaseEntity
    {
        [Required] public string Name { get; private set; }


        public Brand() { }

        public Brand(string name)
        {
            Name= name;
        }
    }
}
