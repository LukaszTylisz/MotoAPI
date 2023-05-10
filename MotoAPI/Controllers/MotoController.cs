using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoAPI.Entitites;
using MotoAPI.Models;
using MotoAPI.Services;

namespace MotoAPI.Controllers;

[Route("api/moto")]
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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var isUpdated = _motoService.Update(id, dto);
        if (!isUpdated)
        {
            return NotFound();
        }

        return Ok();
    }
    

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var isDeleted = _motoService.Delete(id);

        if (isDeleted)
        {
            return NoContent();
        }

        return NotFound();
    }
    
    
    [HttpPost]
    public ActionResult CreateMoto([FromBody] CreateMotoDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        } 
        
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
        if (moto is null)
        {
            return NotFound();
        }
        return Ok(moto);
    }
}