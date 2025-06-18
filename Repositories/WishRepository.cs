using Microsoft.EntityFrameworkCore;
using WishListApi.Data;
using WishListApi.Models;
using WishListApi.Repositories.Interfaces;

class WishRepository(ApplicationDbContext dbContext) : IWishRepository
{
    public async Task<Wish> AddWish(Wish wish)
    {
        await dbContext.Wishes.AddAsync(wish);
        await dbContext.SaveChangesAsync();
        return wish;
    }

    public async Task<Wish?> GetWishById(Guid id)
    {
        return await dbContext.Wishes.FirstOrDefaultAsync(wish => wish.Id == id);
    }

    public async Task<IEnumerable<Wish>> GetWishesAsync()
    {
        return await dbContext.Wishes.ToListAsync();
    }

    public async Task<Wish> ToggleIsCompleted(Guid id)
    {
        var wish = await dbContext.Wishes.FirstOrDefaultAsync(wish => wish.Id == id) ?? throw new Exception("Wish not found");
        wish.IsCompleted = !wish.IsCompleted;
        await dbContext.SaveChangesAsync();

        return wish;
    }
}