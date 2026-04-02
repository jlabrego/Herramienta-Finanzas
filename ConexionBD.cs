using System;
using System.Data.SqlClient;
using System.Configuration;


public class TryCash_Alternativas.Datos
{

    public ConexionDB()
{

            private string cadenaConexion = "Server=.; DataBase=TryCashDB;Integrated Security = true;";
public SqlConnection = LeerConexion();
{
    return new SqlConnection(cadenaConexion);
}
	    }
}
