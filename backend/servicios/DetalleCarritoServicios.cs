using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class DetalleCarritoServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "EXEC SPObtenerDetalleCarrito";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "EXEC SPObtenerIDDetalleCarrito @ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int InsertDetalleCarrito(DetalleCarrito detalleCarrito)
        {
            const string sql = "INSERT INTO [dbo].[DETALLE_CARRITO]([CANTIDAD], [ID_PRODUCTO], [ID_CARRITO_COMPRA]) VALUES (@cantidad, @id_producto, @id_carrito_compra)";

            var parameters = new DynamicParameters();
            parameters.Add("cantidad", detalleCarrito.Cantidad, DbType.Int64);
            parameters.Add("id_producto", detalleCarrito.IdProducto, DbType.Int64);
            parameters.Add("id_carrito_compra", detalleCarrito.IdCarritoCompra, DbType.Int64);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int UdaptetDetalleCarrito(DetalleCarrito detalleCarrito, int id)
        {
            const string sql = "EXEC SPModificarDeatlleCarrito @USUARIO_REGISTRO = @usuario_registro ,@FECHA_REGISTRO = @fecha_registro, @ESTADO_REGISTRO = @estado_registro, @ID = @id;";
            var parameters = new DynamicParameters();
        
            parameters.Add("usuario_registro", detalleCarrito.UsuarioRegistro, DbType.String);
            parameters.Add("fecha_registro", detalleCarrito.FechaRegistro, DbType.DateTime);
            parameters.Add("estado_registro", detalleCarrito.EstadoRegistro, DbType.Int32);
            parameters.Add("id", id, DbType.Int32);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

         public static int DeleteDetalleCarrito(DetalleCarrito detalleCarrito, int id)
        {
            const string sql = "delete from DETALLE_CARRITO where ID = @id;";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;

        }
        

    }
}
