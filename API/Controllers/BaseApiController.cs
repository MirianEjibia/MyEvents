using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Core;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BaseApiController: ControllerBase
{
    public ActionResult<T> ToActionResult<T>(Result<T> res)
    {
      if(!res.IsSuccess && res.ErrorCode == 404) return NotFound();
      if(res.IsSuccess && res.Value != null) return Ok(res.Value);
      return BadRequest(res.Error);    
    }
}