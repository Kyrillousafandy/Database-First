using DatabaseFirst.Data;
using DatabaseFirst.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using NorthwindContext context = new NorthwindContext();
            #region select
            var category = context.Categories.FromSqlRaw("select * from Categories");

            foreach (var cat in category)
            {
                Console.WriteLine(cat.CategoryName);
            }
            #endregion

            #region Execute DML

            //context.Database.ExecuteSqlRaw("update Categories set CategoryName = 'hamada' where CategoryId = 2");
            #endregion

            #region call stored procedure using EF power Tool


            NorthwindContextProcedures procedure = new NorthwindContextProcedures(context);
           var products = procedure.SalesByCategoryAsync("Beverages", "1998");

            foreach (var product in products.Result)
            {
                Console.WriteLine($"{product.ProductName}::{product.TotalPurchase}");
            }
            #endregion
        }
    }

}
