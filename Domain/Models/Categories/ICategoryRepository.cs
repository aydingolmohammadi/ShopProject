namespace Domain.Models.Categories;

public interface ICategoryRepository
{
    Task<Category?> GetById(int id);
    Task<IEnumerable<Category>> GetAll();
    Task Add(Category? category);
    void Update(Category? category);
    void Delete(Category? category);
}