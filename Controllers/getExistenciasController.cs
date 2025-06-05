using Microsoft.AspNetCore.Mvc;
using ApiExistenciasSimuladas.Models;
using ApiExistenciasSimuladas.Data;

namespace ApiExistenciasSimuladas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class getExistenciasController : ControllerBase
{
    [HttpPost("consultar")]
public IActionResult ConsultarExistencia([FromBody] ConsultaExistenciaRequest request)
{
    var encontrado = InventarioSimulado.Materiales.FirstOrDefault(m =>
        string.Equals(m.Material, request.Material, StringComparison.OrdinalIgnoreCase) &&
        string.Equals(m.Centro, request.Centro, StringComparison.OrdinalIgnoreCase) &&
        string.Equals(m.Almacen, request.Almacen, StringComparison.OrdinalIgnoreCase)
    );

    var response = new ConsultaExistenciaResponse
    {
        NumMaterial = encontrado.Material ?? request.Material,
        Existencia = encontrado != default ? encontrado.Existencia : 0,
        Mensaje = encontrado != default
            ? "Request recibido solicitando existencias SAP"
            : "Material no encontrado en el inventario."
    };

    return encontrado != default ? Ok(response) : NotFound(response);
}
}