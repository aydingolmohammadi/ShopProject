using Domain.Models.Categories;

namespace Infrastructure.repositories;

public class CategoryRepository(DataBaseContext dbContext):ICategoryRepository
{

    public async Task<Category> GetById(int id)
    {
        return await dbContext.Categories
            .Include(c => c.SubCategories)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        return await dbContext.Categories
            .Include(c => c.SubCategories)
            .ToListAsync();
    }

    public async Task Add(Category category)
    {
        await dbContext.Categories.AddAsync(category);
    }

    public void Update(Category category)
    {
        dbContext.Categories.Update(category);
    }

    public void Delete(Category category)
    {
        dbContext.Categories.Remove(category);
    }
}