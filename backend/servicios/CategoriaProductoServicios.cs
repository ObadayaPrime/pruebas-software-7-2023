using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class CategoriaProductoServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "EXEC SPObtenerCategoriaProducto";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "EXEC SPObtenerIDCategoria @ID =  @Id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int InsertCategoriaProducto(CategoriaProducto categoriaProducto)
        {
            const string sql = "INSERT INTO [CATEGORIA_PRODUCTO]([NOMBRE]) VALUES (@NOMBRE) ";

            var parameters = new DynamicParameters();
            parameters.Add("NOMBRE", categoriaProducto.Nombre, DbType.String);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

         public static int UdapteCategoriaProducto(CategoriaProducto categoriaProducto, int id)
        {
            const string sql = "EXEC SPModificarCategoria @NOMBRE = @nombre , @USUARIO_REGISTRO = @usuario_registro ,@FECHA_REGISTRO = @fecha_registro, @ESTADO_REGISTRO = @estado_registro, @ID = @id;";
            var parameters = new DynamicParameters();
        
             parameters.Add("nombre", categoriaProducto.Nombre, DbType.String);
            parameters.Add("usuario_registro", categoriaProducto.UsuarioRegistro, DbType.String);
            parameters.Add("fecha_registro", categoriaProducto.FechaRegistro, DbType.DateTime);
            parameters.Add("estado_registro", categoriaProducto.EstadoRegistro, DbType.Int32);
            parameters.Add("id", id, DbType.Int32);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int DeleteCategoriaProducto(CategoriaProducto categoriaProducto, int id)
        {
            const string sql = "delete from CATEGORIA_PRODUCTO where ID = @id;";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;

        }


    }
}
