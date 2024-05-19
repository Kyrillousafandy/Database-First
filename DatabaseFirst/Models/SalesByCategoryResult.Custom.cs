using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst.Models
{
   public partial class SalesByCategoryResult
    {
        override string ToString()
            => $"{this.ProductName}:: {this.TotalPurchase}"
    }
}
