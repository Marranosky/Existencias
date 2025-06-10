using Microsoft.AspNetCore.Mvc;
using ApiExistenciasSimuladas.Data;
using ApiExistenciasSimuladas.Models;

namespace ApiExistenciasSimuladas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GetProveedorController : ControllerBase
{
    [HttpGet("{cuenta}")]
    public IActionResult ConsultarProveedor(string cuenta)
    {
        var proveedor = ProveedoresSimulados.Lista.FirstOrDefault(p =>
            string.Equals(p.CuentaProveedor, cuenta, StringComparison.OrdinalIgnoreCase));

        if (proveedor != null)
        {
            return Ok(proveedor);
        }

        return NotFound(new ConsultaProveedorResponse
        {
            CuentaProveedor = cuenta,
            NumeroDocumento = "",
            Mensaje = "Los datos de cabecera del pedido todavía son erróneos"
        });
    }
}
