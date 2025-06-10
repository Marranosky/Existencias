using ApiExistenciasSimuladas.Models;

namespace ApiExistenciasSimuladas.Data;

public static class ProveedoresSimulados
{
    public static List<ConsultaProveedorResponse> Lista = new()
    {
        new ConsultaProveedorResponse
        {
            CuentaProveedor = "0030000079",
            NumeroDocumento = "4500012345",
            Mensaje = "Proveedor encontrado correctamente"
        },
        new ConsultaProveedorResponse
        {
            CuentaProveedor = "0030000080",
            NumeroDocumento = "4500012346",
            Mensaje = "Proveedor encontrado correctamente"
        }
    };
}
