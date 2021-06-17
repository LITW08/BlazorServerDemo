using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace BlazorServerDemo.Data
{
    public class NorthwindRepository
    {
        private readonly string _connectionString;

        public NorthwindRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Category> GetCategories()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Category>("SELECT CategoryId as Id, CategoryName as Name FROM Categories").ToList();
        }

        public List<Product> GetProductsForCategory(int categoryId)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Product>(
                "SELECT ProductId as Id, ProductName as Name, QuantityPerUnit, UnitsInStock, UnitPrice " +
                "FROM Products WHERE CategoryId = @categoryId", new
                {
                    categoryId = categoryId
                }).ToList();
        }
    }
    
    //Write a function that takes in a list of integers, and returns a list of integers as well.
    //The returned list should have only the DUPLICATES found in the original list.
    
    //e.g if the original list was [1,2,3,4,4,1] - the result should be [1,4]
    //If a number is there more than twice, it should also only appear once in the result:
    //e.g. [1,1,1,2,3,3] - [1,3]
    //If no duplicated are found, then return an empty list
    //Console.ReadKey(true);
}