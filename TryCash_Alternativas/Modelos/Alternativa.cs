using System;

namespace TryCash_Alternativas.Modelos
{
    public class Alternativa
    {
        // --- IDENTIFICADORES (Tablas Alternativas/Proyectos) ---
        public int Id { get; set; }
        public int IdProyecto { get; set; } // FK necesaria para el punto (f)
        public string Nombre { get; set; }
        public int RamosProducidos { get; set; }
        public decimal PrecioVentaUnitario { get; set; }
        public decimal CostoInsumos { get; set; } 
        public int NumeroOperarios { get; set; }
        public decimal InversionEquipos { get; set; } 
        public decimal ArrendamientoMensual { get; set; } 

        // Datos del ALTER TABLE
        public int DuracionMeses { get; set; } 
        public int AreaHectareas { get; set; } 
        public decimal ComisionVentasPct { get; set; }
        public decimal CostoEmbalajeUnitario { get; set; }
        public decimal TransporteFleteTotal { get; set; } 
        public decimal DevaluacionEsperada { get; set; } 

        // --- DATOS DE RESULTADOS (Tabla ResultadosSensibilidad) 
        public decimal UtilidadNeta { get; set; }
        public decimal RentabilidadPct { get; set; }

        // --- GSPs 
        public decimal GspPrecio { get; set; }
        public decimal GspRamos { get; set; }
        public decimal GspSalario { get; set; }
        public decimal GspArrendamiento { get; set; }
        public decimal GspInversion { get; set; }
    }
}