using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class ProductoServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "EXEC SPObtenerProducto";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "EXEC SPObtenerIDProducto @ID = @Id;";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int InsertProducto(Producto producto)
        {
            const string sql = "INSERT INTO [dbo].[PRODUCTO]([NOMBRE], [ID_CATEGORIA]) VALUES (@nombre, @id_categoria)  ";

            var parameters = new DynamicParameters();
            parameters.Add("@nombre", producto.Nombre, DbType.String);
            parameters.Add("@id_categoria", producto.IdCategoria, DbType.Int64);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int UdapteProducto(Producto producto, int id)
        {
           const string sql = " EXEC SPModificarProducto @NOMBRE = @nombre, @USUARIO_REGISTRO = @usuario_registro ,@FECHA_REGISTRO = @fecha_registro, @ESTADO_REGISTRO= @estado_registro, @ID = @id;";
            var parameters = new DynamicParameters();
           
            parameters.Add("nombre", producto.Nombre, DbType.String);
            parameters.Add("usuario_registro", producto.UsuarioRegistro, DbType.String);
            parameters.Add("fecha_registro", producto.FechaRegistro, DbType.DateTime);
            parameters.Add("estado_registro", producto.EstadoRegistro, DbType.Int32);
            parameters.Add("id", producto.IdCategoria, DbType.Int64);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }
         public static int DeleteProducto(Producto producto, int id)
        {
            const string sql = "delete from PRODUCTO where ID = @id;";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;

        }

    }
}
