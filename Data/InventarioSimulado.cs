using ApiExistenciasSimuladas.Models;

namespace ApiExistenciasSimuladas.Data;

public static class InventarioSimulado
{
    public static List<(string Material, string Centro, string Almacen, decimal Existencia)> Materiales =
        new List<(string, string, string, decimal)>
    {
        ("7501082203004", "65CL", "65CL", 14.000m),
        ("ER0009", "65CL", "65CL", 25.500m),
        ("XYZ1234567890", "99MX", "01MX", 0.000m)
    };
}