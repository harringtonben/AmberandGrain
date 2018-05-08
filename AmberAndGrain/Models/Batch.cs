using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmberAndGrain.Models
{
    public class Batch
    {
        public virtual int Id { get; set; }
        public virtual int RecipeId { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime? DateBarrelled { get; set; }
        public virtual int? NumberOfBarrels { get; set; }
        public virtual DateTime? DateBottled { get; set; }
        public virtual int? NumberOfBottles { get; set; }
        public virtual string Cooker { get; set; }
        public virtual double? PricePerBottle { get; set; }
        public virtual int? NumberOfBottlesLeft { get; set; }
        public virtual BatchStatus Status { get; set; }
    }
}