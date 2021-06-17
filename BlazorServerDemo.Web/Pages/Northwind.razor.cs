using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServerDemo.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;

namespace BlazorServerDemo.Web.Pages
{
    public partial class Northwind
    {
        [Inject]
        public IConfiguration Configuration { get; set; }

        private List<Product> _products = new();
        private List<Category> _categories = new();

        protected override void OnInitialized()
        {
            var repo = new NorthwindRepository(Configuration.GetConnectionString("ConStr"));
            _categories = repo.GetCategories();
        }

        private void OnSelectChange(ChangeEventArgs e)
        {
            int categoryId = int.Parse(e.Value.ToString());
            var repo = new NorthwindRepository(Configuration.GetConnectionString("ConStr"));
            _products = repo.GetProductsForCategory(categoryId);
        }
    }
}
