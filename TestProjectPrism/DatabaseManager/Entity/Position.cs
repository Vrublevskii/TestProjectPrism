using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProjectPrism.DatabaseManager.Entity
{
    public partial class Position
    {
        public int Id { get; set; }

        public string NamePosition { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}