namespace AppStore.Models
{
    public class AppCategoryModel
    {
        public int Id { get; set; }
        
        public AppModel App { get; set; }
        public int AppId { get; set; }
        
        public CategoryModel Category { get; set; }
        public int CategoryId { get; set; }
    }
}