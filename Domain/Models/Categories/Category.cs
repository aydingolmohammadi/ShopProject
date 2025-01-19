using Domain.Models.SubCategories;

namespace Domain.Models.Categories;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<SubCategory> SubCategories { get; set; }
}