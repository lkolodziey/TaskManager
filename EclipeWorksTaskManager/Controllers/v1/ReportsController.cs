using EclipeWorksTaskManager.Services.DataObjects;
using EclipeWorksTaskManager.Services.Interfaces;
using EclipeWorksTaskManager.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace EclipeWorksTaskManager.Controllers.v1;

[ApiController]
[Route("api/v1/tasks")]
public class ReportsController(IUserService userService, ITaskService taskService) : ControllerBase
{
    [HttpGet("performance")]
    public async Task<IActionResult> GetPerformanceReportAsync([FromHeader(Name = "ManagerUsername")] string managerUsername)
    {
        var isValiManager = await userService.UserIsManager(managerUsername);
        if (!isValiManager)
        {
            return Unauthorized(new { message = "Unauthorized access. User is not a manager." });
        }

        var report = await taskService.GetPerformanceReportAsynnc();
        
       
        
        return Ok(report);
    }
}