namespace TheRealDealGym.Core.Models.Class
{
    /// <summary>
    /// This ViewModel maps the SportCategory.
    /// </summary>
    public class SportCategoryModel
    {
        public Guid Id { get; set; }
        public string SportCategory { get; set; } = null!;
    }
}