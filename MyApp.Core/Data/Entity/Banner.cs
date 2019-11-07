namespace MyApp.Core.Data.Entity
{
    public partial class Banner: BaseEntity
    {
        public bool? IsDelete { get; set; }
        public string BannerName { get; set; }
        public string UrlImage { get; set; }
    }
}
