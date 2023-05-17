using Microsoft.AspNetCore.Mvc;
using MotoAPI.Models;
using MotoAPI.Services.Interface;

namespace MotoAPI.Controllers;

[Route("api/moto/{motoId}/car")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService service)
    {
        _carService = service;
    }
    
    [HttpPost]
    public ActionResult Post([FromRoute] int motoId, [FromBody]CreateCarDto dto)
    {
      var newCarId =  _carService.Create(motoId, dto);

      return Created($"api/moto/{motoId}/car/{newCarId}", null);
    }

    [HttpGet("{carId}")]
    public ActionResult<CarDto> Get([FromRoute] int motoId, [FromRoute] int carId)
    {
        CarDto car = _carService.GetById(motoId, carId);
        return Ok(car);
    }
    
    [HttpGet]
    public ActionResult<List<CarDto>> Get([FromRoute] int motoId)
    {
      var result = _carService.GetAll(motoId);
        return Ok(result);
    }

    [HttpDelete]
    public ActionResult Delete([FromRoute] int motoId)
    {
        _carService.RemoveAll(motoId);

        return NoContent();
    }
}