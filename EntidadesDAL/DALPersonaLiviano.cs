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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_PersonaLiviano
	/// </summary>
    public class DALPersonaLiviano : AbstractMapper<PersonaLiviano>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALPersonaLiviano()
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
        /// M?todo que retorna solo un objeto  PersonaLiviano
		/// </summary>
		/// <param name="id"></param>   
		/// <returns></returns>
		public PersonaLiviano Load(int id)
		{
            try
            {
				PersonaLiviano oReturn = null;
				CommandText = "PA_MG_FRONT_PersonaLiviano_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<PersonaLiviano> personalivianos = AbstractFindAll(oParameters);
				if (personalivianos.Count > 0)
				{
					oReturn = personalivianos[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersonaLiviano, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_PersonaLiviano
		/// </summary>
		/// <param name="oPersonaLiviano"></param>
		/// <returns></returns>
		public void Delete(PersonaLiviano oPersonaLiviano)
		{
            try
            {
                CommandText = "PA_MG_FRONT_PersonaLiviano_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oPersonaLiviano.Id));			
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersonaLiviano, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_PersonaLiviano
		/// </summary>
		/// <param name="oPersonaLiviano"></param>
		/// <returns></returns>
		public void Update(PersonaLiviano oPersonaLiviano)
		{
            try
            {
                CommandText = "PA_MG_FRONT_PersonaLiviano_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oPersonaLiviano.Id));
				oParameters.Add(new DBParametro("@codigo", DbType.String, oPersonaLiviano.Codigo));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oPersonaLiviano.Nombre));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersonaLiviano, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_PersonaLiviano
		/// </summary>
		/// <param name="oPersonaLiviano"></param>
		/// <returns></returns>
		public void Insert(PersonaLiviano oPersonaLiviano)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_PersonaLiviano_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oPersonaLiviano.Id));
				oParameters.Add(new DBParametro("@codigo", DbType.String, oPersonaLiviano.Codigo));
				oParameters.Add(new DBParametro("@nombre", DbType.String, oPersonaLiviano.Nombre));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersonaLiviano, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// PersonaLiviano de la tabla dbo.TBL_PersonaLiviano
		/// </summary>
		/// <param name="oPersonaLiviano"></param>
		/// <returns></returns>
		public List<PersonaLiviano> GetAllPersonaLivianos()
		{
            try
            {
				CommandText = "PA_MG_FRONT_PersonaLiviano_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<PersonaLiviano> personalivianos = AbstractFindAll(oParameters);
				
				return personalivianos;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersonaLiviano, getPersonaLivianos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto PersonaLiviano de la tabla dbo.TBL_PersonaLiviano
		/// </summary>
		/// <param name="oPersonaLiviano"></param>
		/// <returns></returns>
		public override PersonaLiviano DoLoad(IDataReader registros)
        {
            try
            {
				PersonaLiviano personaliviano = new PersonaLiviano();
				personaliviano.Id = registros.GetInt32(0);
                personaliviano.Codigo = registros.GetInt32(1).ToString();
				personaliviano.Nombre = registros.GetString(2);
			
				return personaliviano;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersonaLiviano, getPersonaLivianos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override PersonaLiviano DoLoad(IDataReader registros, PersonaLiviano ent)
        {
            throw new NotImplementedException();
        }
    }
}
