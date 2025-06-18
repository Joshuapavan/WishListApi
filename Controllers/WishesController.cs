using Microsoft.AspNetCore.Mvc;

namespace WishListApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WishesController : ControllerBase
{
    [HttpGet]
    [Route("healthcheck")]
    public ActionResult<String> HealthCheck()
    {
        return Ok("The Server is Up and Running");
    }


    

}