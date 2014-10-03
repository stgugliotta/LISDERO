using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;
using Entidades;


namespace EntidadesDAL
{
	/// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Relacion
	/// </summary>
    public class DALRelacion : AbstractMapper<Relacion>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
        public DALRelacion()
        {
            DBConnection oDbConnection  = DBConnection.Instancia;
            Db = oDbConnection.Db;
			ObjConnection = oDbConnection.ObjConnection;
            ObjCommand = oDbConnection.ObjCommand;
            ObjCommand.Connection = ObjConnection; 
        }
		
		/// <summary>
        /// Destructor Standard
		/// </summary>
		
        
		/// <summary>
        /// M?todo que retorna solo un objeto  Relacion
		/// </summary>
		/// <param name="id"></param>  
		/// <returns></returns>
        public Relacion Load(int codigo1, int codigo2)
		{
            try
            {
                Relacion oReturn = null;
                CommandText = "PA_MG_FRONT_Relacion_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@codigo1", DbType.Int32, codigo1));
                oParameters.Add(new DBParametro("@codigo2", DbType.Int32, codigo2));

                List<Relacion> relaciones = AbstractFindAll(oParameters);
				if (relaciones.Count > 0)
				{
					oReturn = relaciones[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRelacion, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Relacion
		/// </summary>
        /// <param name="oRelacion"></param>
		/// <returns></returns>
        public void Delete(Relacion oRelacion)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Relacion_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@codigo1", DbType.Int32, oRelacion.Codigo1));
                oParameters.Add(new DBParametro("@codigo2", DbType.Int32, oRelacion.Codigo2));

				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRelacion, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Relacion
		/// </summary>
        /// <param name="oRelacion"></param>
		/// <returns></returns>
        public void Update(Relacion oRelacion)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Relacion_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();

                
                oParameters.Add(new DBParametro("@codigo1", DbType.Int32, oRelacion.Codigo1));
                oParameters.Add(new DBParametro("@codigo2", DbType.Int32, oRelacion.Codigo2));
                oParameters.Add(new DBParametro("@idCargo", DbType.String, oRelacion.IdCargo));
                oParameters.Add(new DBParametro("@idTipoRelacion", DbType.String, oRelacion.IdTipoRelacion));
                oParameters.Add(new DBParametro("@relacion", DbType.String, oRelacion.TextoRelacion));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRelacion, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Relacion
		/// </summary>
        /// <param name="oRelacion"></param>
		/// <returns></returns>
        public void Insert(Relacion oRelacion)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Relacion_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
      
                oParameters.Add(new DBParametro("@codigo1", DbType.Int32, oRelacion.Codigo1));
                oParameters.Add(new DBParametro("@codigo2", DbType.Int32, oRelacion.Codigo2));
                oParameters.Add(new DBParametro("@idCargo", DbType.String, oRelacion.IdCargo));
                oParameters.Add(new DBParametro("@idTipoRelacion", DbType.String, oRelacion.IdTipoRelacion));
                oParameters.Add(new DBParametro("@relacion", DbType.String, oRelacion.TextoRelacion));
								
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRelacion, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// Relacion de la tabla dbo.TBL_Relacion
		/// </summary>
        /// <param name="oRelacion"></param>
		/// <returns></returns>
        public List<Relacion> GetAllRelaciones()
		{
            try
            {
                CommandText = "PA_MG_FRONT_Relacion_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();

                List<Relacion> relaciones = AbstractFindAll(oParameters);
				
				return relaciones;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRelacion, getRelaciones", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Relacion de la tabla dbo.TBL_Relacion
		/// </summary>
        /// <param name="oRelacion"></param>
		/// <returns></returns>
        public override Relacion DoLoad(IDataReader registros)
        {
            try
            {
                Relacion relacion= new Relacion();
				relacion.Codigo1 = registros.GetInt32(0);
                relacion.Codigo2 = registros.GetInt32(1);
                relacion.IdTipoRelacion = registros.IsDBNull(2) != true ? registros.GetInt32(2) : Int32.MinValue; ;
                relacion.IdCargo = registros.IsDBNull(3) != true ? registros.GetInt32(3) : Int32.MinValue; ;//registros.GetInt32(3);
                relacion.TextoRelacion = registros.IsDBNull(4) != true ? registros.GetString(4) : ""; //registros.GetString(4);

                return relacion;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALRelacion, getRelacions", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Relacion DoLoad(IDataReader registros, Relacion ent)
        {
            throw new NotImplementedException();
        }
    }
}
