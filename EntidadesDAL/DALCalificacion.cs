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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Calificacion
	/// </summary>
    public class DALCalificacion : AbstractMapper<Calificacion>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALCalificacion()
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
        /// M?todo que retorna solo un objeto  Calificacion
		/// </summary>
		/// <param name="id"></param>  
		/// <returns></returns>
		public Calificacion Load(int id)
		{
            try
            {
				Calificacion oReturn = null;
				CommandText = "PA_MG_FRONT_Calificacion_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Calificacion> calificacions = AbstractFindAll(oParameters);
				if (calificacions.Count > 0)
				{
					oReturn = calificacions[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCalificacion, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Calificacion
		/// </summary>
		/// <param name="oCalificacion"></param>
		/// <returns></returns>
		public void Delete(Calificacion oCalificacion)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Calificacion_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oCalificacion.Id));		
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCalificacion, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Calificacion
		/// </summary>
		/// <param name="oCalificacion"></param>
		/// <returns></returns>
		public void Update(Calificacion oCalificacion)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Calificacion_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oCalificacion.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oCalificacion.Descripcion));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCalificacion, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Calificacion
		/// </summary>
		/// <param name="oCalificacion"></param>
		/// <returns></returns>
		public void Insert(Calificacion oCalificacion)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Calificacion_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oCalificacion.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oCalificacion.Descripcion));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCalificacion, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Calificacion de la tabla dbo.TBL_Calificacion
		/// </summary>
		/// <param name="oCalificacion"></param>
		/// <returns></returns>
		public List<Calificacion> GetAllCalificacions()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Calificacion_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Calificacion> calificacions = AbstractFindAll(oParameters);
				
				return calificacions;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCalificacion, getCalificacions", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Calificacion de la tabla dbo.TBL_Calificacion
		/// </summary>
		/// <param name="oCalificacion"></param>
		/// <returns></returns>
		public override Calificacion DoLoad(IDataReader registros)
        {
            try
            {
				Calificacion calificacion = new Calificacion();
				calificacion.Id = registros.GetInt32(0);
				calificacion.Descripcion = registros.GetString(1);
			
				return calificacion;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALCalificacion, getCalificacions", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Calificacion DoLoad(IDataReader registros, Calificacion ent)
        {
            throw new NotImplementedException();
        }
    }
}
