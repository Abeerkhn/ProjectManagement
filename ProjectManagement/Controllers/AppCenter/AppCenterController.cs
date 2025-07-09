using Microsoft.AspNetCore.Mvc;

namespace Softwash.Controllers.AppCenter
{
    [Route("api/appCenter")]
    [ApiController]
    [AllowAnonymous]
    public class AppCenterController : ControllerBase
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "appCenter.json");

        [HttpGet]
        public IActionResult GetConfig()
        {
            try
            {
                if (!System.IO.File.Exists(_filePath))
                {
                    return Ok(Output.Handler<object>((int)ResponseType.NOT_EXIST, false, "App Center File"));
                }

                var json = System.IO.File.ReadAllText(_filePath);
                var jsonObject = JsonDocument.Parse(json).RootElement;

                return Ok(Output.Handler<object>((int)ResponseType.GET, jsonObject, "App Center", 0));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error reading file: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult UpdateConfig([FromBody] JsonElement newConfig)
        {
            try
            {
                if (newConfig.ValueKind != JsonValueKind.Object)
                {
                    return BadRequest("Invalid JSON data.");
                }

                var json = System.Text.Json.JsonSerializer.Serialize(newConfig, new JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText(_filePath, json);

                return Ok(Output.Handler<object>((int)ResponseType.UPDATE, true, "App Center", 0));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error writing file: {ex.Message}");
            }
        }
    }
}

