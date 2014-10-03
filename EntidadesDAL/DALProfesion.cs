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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Profesion
	/// </summary>
    public class DALProfesion : AbstractMapper<Profesion>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALProfesion()
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
        /// M?todo que retorna solo un objeto  Profesion
		/// </summary>
		/// <param name="id"></param>  
		/// <returns></returns>
		public Profesion Load(int id)
		{
            try
            {
				Profesion oReturn = null;
				CommandText = "PA_MG_FRONT_Profesion_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Profesion> profesions = AbstractFindAll(oParameters);
				if (profesions.Count > 0)
				{
					oReturn = profesions[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProfesion, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Profesion
		/// </summary>
		/// <param name="oProfesion"></param>
		/// <returns></returns>
		public void Delete(Profesion oProfesion)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Profesion_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oProfesion.Id));		
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProfesion, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Profesion
		/// </summary>
		/// <param name="oProfesion"></param>
		/// <returns></returns>
		public void Update(Profesion oProfesion)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Profesion_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oProfesion.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oProfesion.Descripcion));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProfesion, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Profesion
		/// </summary>
		/// <param name="oProfesion"></param>
		/// <returns></returns>
		public void Insert(Profesion oProfesion)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Profesion_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oProfesion.Id));
				oParameters.Add(new DBParametro("@descripcion", DbType.String, oProfesion.Descripcion));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProfesion, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Profesion de la tabla dbo.TBL_Profesion
		/// </summary>
		/// <param name="oProfesion"></param>
		/// <returns></returns>
		public List<Profesion> GetAllProfesions()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Profesion_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Profesion> profesions = AbstractFindAll(oParameters);
				
				return profesions;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProfesion, getProfesions", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto Profesion de la tabla dbo.TBL_Profesion
		/// </summary>
		/// <param name="oProfesion"></param>
		/// <returns></returns>
		public override Profesion DoLoad(IDataReader registros)
        {
            try
            {
				Profesion profesion = new Profesion();
				profesion.Id = registros.GetInt32(0);
				profesion.Descripcion = registros.GetString(1);
			
				return profesion;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALProfesion, getProfesions", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Profesion DoLoad(IDataReader registros, Profesion ent)
        {
            throw new NotImplementedException();
        }
    }
}
