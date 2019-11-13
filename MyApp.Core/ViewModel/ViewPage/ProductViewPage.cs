using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Core.ViewModel.ViewPage
{
    public partial class ProductCreateViewPage
    {
        public string ProductName { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public bool? IsNew { get; set; }
        public int? Sale { get; set; }
        public decimal? Rating { get; set; }
        public string UrlImage { get; set; }
        public string Description { get; set; }
        public string MadeIn { get; set; }
        public string TradeMark { get; set; }
        public string ProvidedBy { get; set; }
        public string WarrantyPeriod { get; set; }
        public string Material { get; set; }
        public string CategoryId { get; set; }
    }
    public partial class ProductViewPage
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public bool? IsNew { get; set; }
        public int? Sale { get; set; }
        public decimal? Rating { get; set; }
        public string UrlImage { get; set; }
        public string Description { get; set; }
        public string MadeIn { get; set; }
        public string TradeMark { get; set; }
        public string ProvidedBy { get; set; }
        public string WarrantyPeriod { get; set; }
        public string Material { get; set; }
    }

    public partial class ProductDetailViewPage
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public bool? IsNew { get; set; }
        public int? Sale { get; set; }
        public decimal? Rating { get; set; }
        public string UrlImage { get; set; }
        public string Description { get; set; }
        public string MadeIn { get; set; }
        public string TradeMark { get; set; }
        public string ProvidedBy { get; set; }
        public string WarrantyPeriod { get; set; }
        public string Material { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
