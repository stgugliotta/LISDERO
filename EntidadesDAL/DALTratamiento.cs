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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Tratamiento
	/// </summary>
    public class DALTratamiento : AbstractMapper<Tratamiento>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALTratamiento()
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
		~DALTratamiento()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  Tratamiento
		/// </summary>
		/// <param name="id"></param>  
		/// <returns></returns>
		public Tratamiento Load(int id)
		{
            try
            {
				Tratamiento oReturn = null;
				CommandText = "PA_MG_FRONT_Tratamiento_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Tratamiento> tratamientos = AbstractFindAll(oParameters);
				if (tratamientos.Count > 0)
				{
					oReturn = tratamientos[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTratamiento, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Tratamiento
		/// </summary>
		/// <param name="oTratamiento"></param>
		/// <returns></returns>
		public void Delete(Tratamiento oTratamiento)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Tratamiento_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oTratamiento.Id));		
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTratamiento, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Tratamiento
		/// </summary>
		/// <param name="oTratamiento"></param>
		/// <returns></returns>
		public void Update(Tratamiento oTratamiento)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Tratamiento_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oTratamiento.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oTratamiento.Descripcion));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTratamiento, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Tratamiento
		/// </summary>
		/// <param name="oTratamiento"></param>
		/// <returns></returns>
		public void Insert(Tratamiento oTratamiento)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Tratamiento_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oTratamiento.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oTratamiento.Descripcion));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTratamiento, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Tratamiento de la tabla dbo.TBL_Tratamiento
		/// </summary>
		/// <param name="oTratamiento"></param>
		/// <returns></returns>
		public List<Tratamiento> GetAllTratamientos()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Tratamiento_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Tratamiento> tratamientos = AbstractFindAll(oParameters);
				
				return tratamientos;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTratamiento, getTratamientos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Tratamiento de la tabla dbo.TBL_Tratamiento
		/// </summary>
		/// <param name="oTratamiento"></param>
		/// <returns></returns>
		public override Tratamiento DoLoad(IDataReader registros)
        {
            try
            {
				Tratamiento tratamiento = new Tratamiento();
				tratamiento.Id = registros.GetInt32(0);
				tratamiento.Descripcion = registros.GetString(1);
			
				return tratamiento;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALTratamiento, getTratamientos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Tratamiento DoLoad(IDataReader registros, Tratamiento ent)
        {
            throw new NotImplementedException();
        }
    }
}
