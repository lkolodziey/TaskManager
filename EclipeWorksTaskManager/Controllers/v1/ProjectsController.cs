using EclipeWorksTaskManager.Services.DataObjects;
using EclipeWorksTaskManager.Services.DataObjects.Requests;
using EclipeWorksTaskManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EclipeWorksTaskManager.Controllers.v1;

[ApiController]
[Route("api/v1/projects")]
public class ProjectsController(IProjectService service) : ControllerBase
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

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] ProjectRequest model)
    {
        try
        {
            var result = await service.PostAsync(model);
            return result ? Ok(new { Success = true, Data = result }) : BadRequest(new { Success = false });
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

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromQuery] int id, [FromBody] ProjectRequest model)
    {
        try
        {
            var result = await service.PutAsync(id, model);
            return result ? Ok(new { Success = true, Data = result }) : BadRequest(new { Success = false });
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        try
        {
            var result = await service.DeleteAsync(id);
            return result.Item1
                ? Ok(new { Success = result.Item1, Data = result.Item2 })
                : BadRequest(new { Success = result.Item1, Data = result.Item2 });
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