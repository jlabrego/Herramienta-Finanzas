using System;

namespace TryCash_Alternativas.Modelos
{
    public class Alternativa
    {
        // Identificadores
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Datos de Entrada
        public int RamosProducidos { get; set; }
        public decimal PrecioVentaUnitario { get; set; }
        public int NumeroOperarios { get; set; }
        public decimal ComisionVentasPct { get; set; }
        public decimal CostoEmbalajeUnitario { get; set; }
        public decimal DevaluacionEsperada { get; set; }

        // Datos de Resultados
        public decimal UtilidadNeta { get; set; }
        public decimal RentabilidadPct { get; set; }

        // GSPs (Análisis de Sensibilidad)
        public decimal GspPrecio { get; set; }
        public decimal GspRamos { get; set; }
    }
}