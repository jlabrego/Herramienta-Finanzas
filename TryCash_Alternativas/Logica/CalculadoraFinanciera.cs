using System;

using TryCash_Alternativas.Modelos;
namespace TryCash_Alternativas.Logica

{
    public class CalculadoraFinanciera

    {
        public decimal CalcularUtilidad(Alternativa alt, decimal salarioMin, decimal segSocial, decimal liq, decimal tasaDolar, decimal tasaEuro, decimal area, decimal meses, decimal arriendoHec)
        {
            // 1. Selección de Tasa según el nombre
            string nombreAlt = (alt.Nombre ?? "").ToLower();
            decimal tasaBase = nombreAlt.Contains("francia") ? tasaEuro : tasaDolar;

            // 2. Ingresos
            decimal tasaConDev = tasaBase * (1 + alt.DevaluacionEsperada);
            decimal ramosTotales = alt.RamosProducidos * area;
            decimal ingresosPesos = ramosTotales * alt.PrecioVentaUnitario * tasaConDev;

            // 3. Valores Base Excel
            decimal fungicidaBase = 350000m;
            decimal abonoBase = 1500000m;
            decimal aguaBase = 90000m;
            decimal inversionFija = 80000000m;

            // 4. Ajustes
            if (nombreAlt.Contains("mejor calidad"))
            {
                fungicidaBase *= 1.25m;
                abonoBase *= 1.25m;
                aguaBase *= 1.25m;
            }
            else if (nombreAlt.Contains("francia"))
            {
                fungicidaBase *= 1.15m;
                abonoBase *= 1.30m;
            }

            // 5. Egresos

            decimal manoObraBase = (salarioMin * alt.NumeroOperarios * meses);
            decimal prestaciones = manoObraBase * (segSocial + liq);
            decimal manoObraTotal = manoObraBase + prestaciones;
            decimal gastoFungicidas = (fungicidaBase * meses * area);
            decimal gastoAbono = (abonoBase * area);
            decimal gastoAgua = (aguaBase * meses * area);
            decimal costoComercializacion = ingresosPesos * alt.ComisionVentasPct;
            decimal costoEmbalaje = ramosTotales * alt.CostoEmbalajeUnitario;
            decimal egresosTotales = manoObraTotal + gastoFungicidas + gastoAbono + gastoAgua + costoComercializacion + costoEmbalaje + (area * arriendoHec) + inversionFija;

            return ingresosPesos - egresosTotales;
        }
        // Métodos de sensibilidad
        public decimal CalcularSensibilidad(Alternativa alt, decimal porcentaje, decimal salario, decimal dolar, decimal area, decimal meses, decimal arriendoHec)
        {
            var copia = ClonarAlternativa(alt);
            copia.PrecioVentaUnitario = alt.PrecioVentaUnitario * (1 + porcentaje);
            return CalcularUtilidad(copia, salario, 0.18m, 0.22m, dolar, 4130m, area, meses, arriendoHec);
        }
        public decimal CalcularSensibilidadRamos(Alternativa alt, decimal porcentaje, decimal salario, decimal dolar, decimal area, decimal meses, decimal arriendoHec)
        {
            var copia = ClonarAlternativa(alt);
            copia.RamosProducidos = (int)(alt.RamosProducidos * (1 + porcentaje));
            return CalcularUtilidad(copia, salario, 0.18m, 0.22m, dolar, 4130m, area, meses, arriendoHec);
        }
        public decimal CalcularSensibilidadSalario(Alternativa alt, decimal porcentajeSalario, decimal salarioBase, decimal dolar, decimal area, decimal meses, decimal arriendoHec)
        {
            decimal nuevoSalario = salarioBase * (1 + porcentajeSalario);

            return CalcularUtilidad(alt, nuevoSalario, 0.18m, 0.22m, dolar, 4130m, area, meses, arriendoHec);

        }
        public decimal CalcularSensibilidadArriendo(Alternativa alt, decimal porcentaje, decimal salario, decimal dolar, decimal area, decimal meses, decimal arriendo)
        {
            decimal nuevoArriendo = arriendo * (1 + porcentaje);

            return CalcularUtilidad(alt, salario, 0.18m, 0.22m, dolar, 4130m, area, meses, nuevoArriendo);
        }

        public decimal CalcularSensibilidadDevaluacion(Alternativa alt, decimal porcentaje, decimal salario, decimal dolar, decimal area, decimal meses, decimal arriendo)
        {
            var copia = ClonarAlternativa(alt);

            copia.DevaluacionEsperada = alt.DevaluacionEsperada * (1 + porcentaje);

            return CalcularUtilidad(copia, salario, 0.18m, 0.22m, dolar, 4130m, area, meses, arriendo);
        }

        public decimal CalcularSensibilidadEmbalaje(Alternativa alt, decimal porcentaje, decimal salario, decimal dolar, decimal area, decimal meses, decimal arriendo)
        {
            var copia = ClonarAlternativa(alt);

            copia.CostoEmbalajeUnitario = alt.CostoEmbalajeUnitario * (1 + porcentaje);

            return CalcularUtilidad(copia, salario, 0.18m, 0.22m, dolar, 4130m, area, meses, arriendo);
        }

        public decimal CalcularSensibilidadInversion(Alternativa alt, decimal porcentaje, decimal salario, decimal dolar, decimal area, decimal meses, decimal arriendo)
        {
            var copia = ClonarAlternativa(alt);

            copia.InversionEquipos = alt.InversionEquipos * (1 + porcentaje);

            return CalcularUtilidad(copia, salario, 0.18m, 0.22m, dolar, 4130m, area, meses, arriendo);
        }
        private Alternativa ClonarAlternativa(Alternativa alt)
        {
            return new Alternativa
            {
                Nombre = alt.Nombre,
                RamosProducidos = alt.RamosProducidos,
                PrecioVentaUnitario = alt.PrecioVentaUnitario,
                NumeroOperarios = alt.NumeroOperarios,
                ComisionVentasPct = alt.ComisionVentasPct,
                CostoEmbalajeUnitario = alt.CostoEmbalajeUnitario,
                DevaluacionEsperada = alt.DevaluacionEsperada
            };
        }

    }

}