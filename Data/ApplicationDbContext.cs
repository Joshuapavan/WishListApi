namespace WishListApi.Data;

using Microsoft.EntityFrameworkCore;
using WishListApi.Models;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Wish> Wishes { get; set; }
}