using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category : BaseEntity
    {
        [Required] public string Name { get; private set; }
        public string Description { get; private set; }
        private Category() { }
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public void UpdateDescription(string description)
        {
            Description = description;
            Touch();
        }
    }
}
