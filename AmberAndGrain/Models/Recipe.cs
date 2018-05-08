using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmberAndGrain.Models
{
    public class Recipe
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal PercentWheat { get; set; }
        public virtual decimal PercentCorn { get; set; }
        public virtual int BarrelAge { get; set; }
        public virtual string BarrelMaterial { get; set; }
        public virtual string Creator { get; set; }
        public virtual ICollection<Batch> Batches { get; set; }
    }
}