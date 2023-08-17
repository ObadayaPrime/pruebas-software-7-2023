using backend.connection;
using backend.entidades;
using backend.servicios;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DetalleCarritoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string? connectionString;

    public DetalleCarritoController(IConfiguration configuration)
    {
        _configuration = configuration;
        connectionString = _configuration["SqlConnectionString:DefaultConnection"];
        BDManager.GetInstance.ConnectionString = connectionString;
    }

    [HttpGet]
    [Route("GetAllDetalleCarrito")]
    public IActionResult GetAllDetalleCarrito()
    {
        try
        {
            var result = DetalleCarritoServicios.ObtenerTodo<DetalleCarrito>();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpGet]
    [Route("GetDetalleCarritoById")]
    public IActionResult GetDetalleCarritoById([FromQuery] int id)
    {
        try
        {
            var result = DetalleCarritoServicios.ObtenerById<DetalleCarrito>(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    [Route("AddDetalleCarrito")]
    public IActionResult AddDetalleCarrito(DetalleCarrito detalleCarrito)
    {
        try
        {
            var result = DetalleCarritoServicios.InsertDetalleCarrito(detalleCarrito);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDetalleCarrito(DetalleCarrito detalleCarrito, int id)
    {
        try
        {
            var result = DetalleCarritoServicios.UdaptetDetalleCarrito(detalleCarrito,id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

     [HttpDelete("{id}")]
    public IActionResult DeleteDetalleCarrito(DetalleCarrito detalleCarrito, int id)
    {
        try
        {
            var result = DetalleCarritoServicios.DeleteDetalleCarrito(detalleCarrito,id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}