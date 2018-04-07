using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmberAndGrain.Models
{
    public class Batch
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateBarrelled { get; set; }
        public int? NumberOfBarrels { get; set; }
        public DateTime? DateBottled { get; set; }
        public int? NumberOfBottles { get; set; }
        public string Cooker { get; set; }
        public double? PricePerBottle { get; set; }
        public int? NumberOfBottlesLeft { get; set; }
        public BatchStatus Status { get; set; }
    }
}