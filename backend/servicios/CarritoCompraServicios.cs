using System.Data;
using backend.connection;
using backend.entidades;
using Dapper;

namespace backend.servicios
{
    public static class CarritoCompraServicios
    {
        public static IEnumerable<T> ObtenerTodo<T>()
        {
            const string sql = "EXEC SPCarrito";
            return BDManager.GetInstance.GetData<T>(sql);//Dapper
        }

        public static T ObtenerById<T>(int id)
        {
            const string sql = "EXEC SPObtenerIDCarrito @ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int64);

            var result = BDManager.GetInstance.GetDataWithParameters<T>(sql, parameters);

            return result.FirstOrDefault();
        }

        public static int InsertCarritoCompra(CarritoCompra carritoCompra)
        {
            const string sql = "INSERT INTO [dbo].[CARRITO_COMPRA]([FECHA], [ID_USUARIO]) VALUES (@fecha, @id_usuario) ";

            var parameters = new DynamicParameters();
            parameters.Add("fecha", carritoCompra.Fecha, DbType.Date);
            parameters.Add("id_usuario", carritoCompra.IdUsuario, DbType.Int64);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int UdapteCarritoCompra(CarritoCompra carritoCompra, int id)
        {
            const string sql = "EXEC SPModificarCarrito  @USUARIO_REGISTRO = @usuario_registro ,@FECHA_REGISTRO = @fecha_registro, @ESTADO_REGISTRO = @estado_registro, @ID = @id;";
            var parameters = new DynamicParameters();
        

            parameters.Add("usuario_registro", carritoCompra.UsuarioRegistro, DbType.String);
            parameters.Add("fecha_registro", carritoCompra.FechaRegistro, DbType.DateTime);
            parameters.Add("estado_registro", carritoCompra.EstadoRegistro, DbType.Int32);
            parameters.Add("id", id, DbType.Int32);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;
        }

        public static int DeleteCarritoCompra(CarritoCompra carritoCompra, int id)
        {
            const string sql = "delete from Carrito_Compra where ID = @id;";

            var parameters = new DynamicParameters();
            parameters.Add("id", id, DbType.Int32);

            var result = BDManager.GetInstance.SetData(sql, parameters);
            return result;

        }


    }
}
