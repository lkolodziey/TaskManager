using Microsoft.AspNetCore.Mvc;
using EclipeWorksTaskManager.Domain.Core.Models;
using EclipeWorksTaskManager.Services.Interfaces;

namespace EclipeWorksTaskManager.Controllers.v1;

[ApiController]
[Route("api/v1/users")]
public class UserController(IUserService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetListAsync()
    {
        try
        {
            var result = await service.GetListAsync();
            return result.Count > 0
                ? Ok(new { Success = true, Data = result })
                : NotFound(new { Success = false, Data = "Data Not Found" });
        }
        catch (Exception e)
        {
            return Problem(
                detail: $"{e.Message} {e.StackTrace}",
                title: "Error",
                instance: "",
                type: "problem");
        }
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        try
        {
            var result = await service.GetAsync(id);
            return result is not null
                ? Ok(new { Success = true, Data = result })
                : NotFound(new { Success = false, Data = "Data Not Found" });
        }
        catch (Exception e)
        {
            return Problem(
                detail: $"{e.Message} {e.StackTrace}",
                
                title: "Error",
                instance: "",
                type: "problem");
        }
    }
}