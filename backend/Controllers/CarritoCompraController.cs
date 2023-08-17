using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarritoCompraController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;

    public CarritoCompraController(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration["SqlConnectionString:DefaultConnection"];
        BDManager.GetInstance.ConnectionString = connectionString;
    }

    [HttpGet]
    [Route("GetAllCarritoCompra")]
    public IActionResult GetAllCarritoCompra()
    {
        try
        {
            var result = CarritoCompraServicios.ObtenerTodo<CarritoCompra>();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpGet]
    [Route("GetCarritoCompraById")]
    public IActionResult GetCarritoCompraById([FromQuery] int id)
    {
        try
        {
            var result = CarritoCompraServicios.ObtenerById<CarritoCompra>(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("AddCarritoCompra")]
    public IActionResult AddCarritoCompra(CarritoCompra carritoCompra)
    {
        try
        {
            var result = CarritoCompraServicios.InsertCarritoCompra(carritoCompra);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCarritoCompra(CarritoCompra carritoCompra, int id)
    {
        try
        {
            var result = CarritoCompraServicios.UdapteCarritoCompra(carritoCompra,id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

     [HttpDelete("{id}")]
    public IActionResult DeleteCarritoCompra(CarritoCompra carritoCompra, int id)
    {
        try
        {
            var result = CarritoCompraServicios.DeleteCarritoCompra(carritoCompra,id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}