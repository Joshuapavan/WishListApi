using WishListApi.Models;

namespace WishListApi.Repositories.Interfaces;

public interface IWishRepository
{
    Task<IEnumerable<Wish>> GetWishesAsync();
    Task<Wish?> GetWishById(Guid id);
    Task<Wish> AddWish(Wish wish);
    Task<Wish> ToggleIsCompleted(Guid id);
}