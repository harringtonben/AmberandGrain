using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmberAndGrain.Models
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual int BatchId { get; set; }
        public virtual int NumberOfBottles { get; set; }
        public virtual DateTime DateOfOrder { get; set; }
        public virtual int CustomerId { get; set; }
    }
}