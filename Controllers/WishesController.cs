using Microsoft.AspNetCore.Mvc;
using WishListApi.Models;
using WishListApi.Repositories;

namespace WishListApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WishesController(WishRepository wishRepository) : ControllerBase
{
    [HttpGet]
    [Route("healthcheck")]
    public ActionResult<String> HealthCheck()
    {
        return Ok("The Server is Up and Running");
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Wish>>> GetAllWishes()
    {
        return Ok(await wishRepository.GetWishesAsync());
    }

    [HttpGet]
    [Route("id:Guid")]
    public async Task<ActionResult<Wish>> GetWishById(Guid id)
    {
        var wish = await wishRepository.GetWishById(id);

        if (wish == null) return NotFound();
        return Ok(wish);
    }

    [HttpPost]
    public async Task<ActionResult<Wish>> CreateWish(Wish wish)
    {
        var createdWish = await wishRepository.AddWish(wish);

        if (createdWish == null) return NotFound();
        return Created($"api/wishes/{createdWish.Id}", createdWish);
    }

    [HttpPatch]
    [Route("id:Guid")]
    public async Task<ActionResult<Wish>> ToggleWish(Guid id)
    {
        var updatedWish = await wishRepository.ToggleIsCompleted(id);

        if (updatedWish == null) return NotFound();
        return Ok(updatedWish);
    }




}