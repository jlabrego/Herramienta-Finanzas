using System;
using TryCash_Alternativas.Modelos;

namespace TryCash_Alternativas.Logica
{
    public class CalculadoraFinanciera
    {
        public decimal CalcularUtilidad(Alternativa alt, decimal salarioMin, decimal segSocial, decimal liq, decimal dolar, decimal area, decimal meses, decimal arriendoHec)
        {
            // 1. INGRESOS (Precio * Ramos * Tasa con Devaluación)
            decimal tasaConDev = dolar * (1 + alt.DevaluacionEsperada);
            decimal ingresosPesos = alt.RamosProducidos * alt.PrecioVentaUnitario * tasaConDev;

            // 2. EGRESOS
            // Nómina: (Salario + SegSocial + Liq) * NumOperarios * Meses
            decimal costoNomina = (salarioMin * (1 + segSocial + liq)) * alt.NumeroOperarios * meses;

            // Arrendamiento: Area * Arriendo por Hectarea * Meses
            decimal costoArriendo = area * arriendoHec * meses;

            // Comisiones: Ingresos * % Comisión
            decimal costoComision = ingresosPesos * alt.ComisionVentasPct;

            // Otros: Embalaje (Ramos * CostoUnitario)
            decimal costoEmbalaje = alt.RamosProducidos * alt.CostoEmbalajeUnitario;

            decimal egresosTotales = costoNomina + costoArriendo + costoComision + costoEmbalaje;

            // 3. RESULTADO
            return ingresosPesos - egresosTotales;
        }

        // Esta función calcula el GSP (Grado de Sensibilidad Puntual)
        public decimal CalcularGSP(decimal variacionResultado, decimal variacionParametro)
        {
            if (variacionParametro == 0) return 0;
            return Math.Abs(variacionResultado / variacionParametro);
        }
    }
}
