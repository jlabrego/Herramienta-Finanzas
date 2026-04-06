using System;
using System.Data.SqlClient;
using TryCash_Alternativas.Modelos;
using System.Data;
namespace TryCash_Alternativas.Datos
{
    public class MetodosDatos
    {
        private string cadenaConexion = "Server=localhost;Database=TryCashDB;Trusted_Connection=True;";


        public void GuardarEscenario(Alternativa alt)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();

                // Usamos una transacción para asegurarnos de que se guarden ambas tablas o ninguna
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string sqlAlt = @"INSERT INTO Alternativas 
                        (nombre_alternativa, ramos_producidos, precio_venta_unitario, costo_insumos, 
                         numero_operarios, inversion_equipos, arrendamiento_mensual, duracion_cultivo_meses, 
                         area_lote_hectareas, comision_ventas_pct, costo_embalaje_unitario, 
                         transporte_flete_total, devaluacion_moneda_pct) 
                        VALUES 
                        (@nom, @ram, @pre, @ins, @ope, @inv, @arr, @dur, @are, @com, @emb, @tra, @dev);
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdAlt = new SqlCommand(sqlAlt, conn, trans);
                    cmdAlt.Parameters.AddWithValue("@nom", alt.Nombre);
                    cmdAlt.Parameters.AddWithValue("@ram", alt.RamosProducidos);
                    cmdAlt.Parameters.AddWithValue("@pre", alt.PrecioVentaUnitario);
                    cmdAlt.Parameters.AddWithValue("@ins", alt.CostoInsumos);
                    cmdAlt.Parameters.AddWithValue("@ope", alt.NumeroOperarios);
                    cmdAlt.Parameters.AddWithValue("@inv", alt.InversionEquipos);
                    cmdAlt.Parameters.AddWithValue("@arr", alt.ArrendamientoMensual);
                    cmdAlt.Parameters.AddWithValue("@dur", alt.DuracionMeses);
                    cmdAlt.Parameters.AddWithValue("@are", alt.AreaHectareas);
                    cmdAlt.Parameters.AddWithValue("@com", alt.ComisionVentasPct);
                    cmdAlt.Parameters.AddWithValue("@emb", alt.CostoEmbalajeUnitario);
                    cmdAlt.Parameters.AddWithValue("@tra", alt.TransporteFleteTotal);
                    cmdAlt.Parameters.AddWithValue("@dev", alt.DevaluacionEsperada);

                    int idGenerado = Convert.ToInt32(cmdAlt.ExecuteScalar());

                    // 2. Insertar en ResultadosSensibilidad
                    string sqlRes = @"INSERT INTO ResultadosSensibilidad 
                        (id_alternativa, utilidad_neta, rentabilidad_pct, gsp_ramos, gsp_precio, gsp_salario) 
                        VALUES 
                        (@id, @util, @rent, @gram, @gpre, @gsal)";

                    SqlCommand cmdRes = new SqlCommand(sqlRes, conn, trans);
                    cmdRes.Parameters.AddWithValue("@id", idGenerado);
                    cmdRes.Parameters.AddWithValue("@util", alt.UtilidadNeta);
                    cmdRes.Parameters.AddWithValue("@rent", alt.RentabilidadPct);
                    cmdRes.Parameters.AddWithValue("@gram", alt.GspRamos);
                    cmdRes.Parameters.AddWithValue("@gpre", alt.GspPrecio);
                    cmdRes.Parameters.AddWithValue("@gsal", alt.GspSalario);

                    cmdRes.ExecuteNonQuery();

                    trans.Commit(); 
                }
                catch (Exception)
                {
                    trans.Rollback(); 
                    throw;
                }
            }
        }
        public System.Data.DataTable ConsultarHistorial()
        {
            System.Data.DataTable tabla = new System.Data.DataTable();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                string sql = @"SELECT A.id_alternativa AS ID, 
                              A.nombre_alternativa AS Escenario, 
                              A.ramos_producidos AS Ramos, 
                              R.utilidad_neta AS [Utilidad Neta], 
                              R.rentabilidad_pct AS [% Rentabilidad], 
                              R.gsp_precio AS [GSP Precio], 
                              R.gsp_ramos AS [GSP Ramos], 
                              R.gsp_salario AS [GSP Salario] 
                       FROM Alternativas A
                       INNER JOIN ResultadosSensibilidad R ON A.id_alternativa = R.id_alternativa
                       ORDER BY A.id_alternativa DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(tabla);
            }
            return tabla;
        }
        public void LimpiarHistorial()
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlTransaction trans = conexion.BeginTransaction();
                try
                {
                    string query = @"
                DELETE FROM ResultadosSensibilidad;
                DELETE FROM Alternativas;
                DBCC CHECKIDENT ('ResultadosSensibilidad', RESEED, 0);
                DBCC CHECKIDENT ('Alternativas', RESEED, 0);";

                    SqlCommand cmd = new SqlCommand(query, conexion, trans);
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Error crítico al limpiar la base de datos: " + ex.Message);
                }
            }
        }
        public void EliminarEscenario(int id)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();

                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    SqlCommand cmd1 = new SqlCommand(
                        "DELETE FROM ResultadosSensibilidad WHERE id_alternativa = @id",
                        conn, trans);

                    cmd1.Parameters.AddWithValue("@id", id);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(
                        "DELETE FROM Alternativas WHERE id_alternativa = @id",
                        conn, trans);

                    cmd2.Parameters.AddWithValue("@id", id);
                    cmd2.ExecuteNonQuery();

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
        public DataTable ObtenerNombresEscenarios()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Rows.Add("Básica");
            dt.Rows.Add("Mejor calidad");
            dt.Rows.Add("Exportar a Francia");
            return dt;
        }

        public DataTable ObtenerTodosLosEscenarios()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("GspRamos", typeof(decimal));
            dt.Columns.Add("GspPrecio", typeof(decimal));
            dt.Columns.Add("GspDevaluacion", typeof(decimal));
            dt.Columns.Add("GspEmbalaje", typeof(decimal));
            dt.Rows.Add("Básica", 6.74m, 8.01m, -0.12m, -1.24m);
            dt.Rows.Add("Mejor calidad", 7.33m, 8.51m, -0.13m, -1.15m);
            dt.Rows.Add("Exportar a Francia", 10.15m, 10.15m, 0.30m, -1.43m);

            return dt;
        }
    }
}