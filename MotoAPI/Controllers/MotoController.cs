using Microsoft.AspNetCore.Mvc;
using MotoAPI.Models;
using MotoAPI.Services;
using MotoAPI.Services.Interface;

namespace MotoAPI.Controllers;

[Route("api/moto")]
[ApiController]
public class MotoController : ControllerBase
{
    private readonly IMotoService _motoService;

    public MotoController(IMotoService motoService)
    {
        _motoService = motoService;
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


    [HttpPost]
    public ActionResult CreateMoto([FromBody] CreateMotoDto dto)
    {
        var id = _motoService.Create(dto);

        return Created($"/api/moto/{id}", null);
    }

    [HttpGet]
    public ActionResult<MotoDto> GetAll()
    {
        var motosDtos = _motoService.GetAll();

        return Ok(motosDtos);
    }

    [HttpGet("{id}")]
    public ActionResult<MotoDto> Get([FromRoute] int id)
    {
        var moto = _motoService.GetById(id);

        return Ok(moto);
    }
}