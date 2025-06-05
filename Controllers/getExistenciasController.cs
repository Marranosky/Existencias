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

        if (!string.IsNullOrEmpty(encontrado.Material))
        {
            var response = new ConsultaExistenciaResponse
            {
                NumMaterial = encontrado.Material,
                Existencia = encontrado.Existencia,
                Mensaje = "Request recibido solicitando existencias SAP"
            };

            return Ok(response);
        }

        return NotFound(new ConsultaExistenciaResponse {
                NumMaterial = encontrado.Material,
                Existencia = 0,
                Mensaje = "Material no encontrado en el inventario." });
    }
}