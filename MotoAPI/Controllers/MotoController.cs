using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoAPI.Models;
using MotoAPI.Services.Interface;

namespace MotoAPI.Controllers;

[Route("api/moto")]
[ApiController]
[Authorize]

public class MotoController : ControllerBase
{
    private readonly IMotoService _motoService;

    public MotoController(IMotoService motoService)
    {
        _motoService = motoService;
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin, Manager")]
    public ActionResult CreateMoto([FromBody] CreateMotoDto dto)
    {
        var userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value!);
        var id = _motoService.Create(dto);
        
        return Created($"/api/moto/{id}", null);
    }

    [HttpPut("{id}")]
    public ActionResult Update([FromBody] UpdateMotoDto dto, [FromRoute] int id)
    {
        _motoService.Update(id, dto);
        
        return Ok();
    }


    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        _motoService.Delete(id);
        
        return NoContent();
    }
    
    [HttpGet]
    [AllowAnonymous]
    public ActionResult<IEnumerable<MotoDto>> GetAll([FromQuery] MotoQuery query)
    {
        var motosDtos = _motoService.GetAll(query);

        return Ok(motosDtos);
    }
 
    [HttpGet("{id}")]
    [AllowAnonymous]
    public ActionResult<MotoDto> Get([FromRoute] int id)
    {
        var moto = _motoService.GetById(id);

        return Ok(moto);
    }
}