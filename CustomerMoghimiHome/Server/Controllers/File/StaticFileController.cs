using CustomerMoghimiHome.Shared.Basic.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace PolimerWebProj.Server.Controllers.File;
[ApiController]
//[Authorize(Roles = "Adminstrator")]
public class StaticFileController : ControllerBase
{

    [HttpPost(FileRoutes.StaticFile + CRUDRouts.Create)]
    public async Task<IActionResult> Upload()
    {
        try
        {
            var file = Request.Form.Files[0];
            var folderName = Path.Combine("StaticFiles", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"') ?? "file";
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Ok(dbPath);
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex}");
        }
    }
}