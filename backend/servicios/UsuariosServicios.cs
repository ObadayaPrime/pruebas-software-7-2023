using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class UsuariosServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "EXEC SPObtenerUsuario;";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            // const string sql = "select * from usuarios where ID = @Id and estado_registro = 1";
            const string sql = "EXEC SPObtenerIDUsuario @ID = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int InsertUsuario(Usuarios usuarios)
        {
            const string sql = "INSERT INTO [dbo].[USUARIOS]([USER_NAME], [NOMBRE_COMPLETO], [PASSWORD]) VALUES (@user_name, @nombre_completo, @password) ";

            var parameters = new DynamicParameters();
            parameters.Add("user_name", usuarios.UserName, DbType.String);
            parameters.Add("nombre_completo", usuarios.NombreCompleto, DbType.String);
            parameters.Add("password", usuarios.Password, DbType.String);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int UdaptetUsuario(Usuarios usuarios, int id)
        {
            const string sql = "EXEC SPModificarUsuario @USER_NAME = @user_name , @NOMBRE_COMPLETO = @nombre_completo ,@PASSWORD = @password , @USUARIO_REGISTRO = @usuario_registro ,@FECHA_REGISTRO = @fecha_registro, @ESTADO_REGISTRO = @estado_registro, @ID = @id;";
            var parameters = new DynamicParameters();
            parameters.Add("user_name", usuarios.UserName, DbType.String);
            parameters.Add("nombre_completo", usuarios.NombreCompleto, DbType.String);
            parameters.Add("password", usuarios.Password, DbType.String);
            parameters.Add("usuario_registro", usuarios.UsuarioRegistro, DbType.String);
            parameters.Add("fecha_registro", usuarios.FechaRegistro, DbType.DateTime);
            parameters.Add("estado_registro", usuarios.EstadoRegistro, DbType.Int32);
            parameters.Add("id", id, DbType.Int32);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int DeleteUsuario(Usuarios usuarios, int id)
        {
            const string sql = "delete from USUARIOS where ID = @id;";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;

        } 
    }
}
