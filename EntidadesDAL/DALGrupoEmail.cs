using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entidades;
using Herramientas;
using Gobbi.CoreServices.Data;
using Gobbi.CoreServices.ExceptionHandling;


namespace EntidadesDAL
{
	/// <summary>
    /// Clase que maneja la persistencia de la tabla dbo.TBL_GrupoEmail
	/// </summary>
    public class DALGrupoEmail : AbstractMapper<GrupoEmail>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALGrupoEmail()
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
        ~DALGrupoEmail()
        {
            ObjConnection.Dispose();
        }
        
		/// <summary>
        /// M?todo que retorna solo un objeto  GrupoEmail
		/// </summary>
		/// <param name="id"></param>  
		/// <returns></returns>
        public GrupoEmail Load(int id)
		{
            try
            {
                GrupoEmail oReturn = null;
                CommandText = "PA_MG_FRONT_GrupoEmail_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<GrupoEmail> gruposEmails = AbstractFindAll(oParameters);
				if (gruposEmails.Count > 0)
				{
					oReturn = gruposEmails[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmail, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_GrupoEmail
		/// </summary>
        /// <param name="oGrupoEmail"></param>
		/// <returns></returns>
        public void Delete(GrupoEmail oGrupoEmail)
		{
            try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oGrupoEmail.Id));		
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmail, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_GrupoEmail
		/// </summary>
        /// <param name="oGrupoEmail"></param>
		/// <returns></returns>
        public void Update(GrupoEmail oGrupoEmail)
		{
            try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oGrupoEmail.Id));
                oParameters.Add(new DBParametro("@descripcion", DbType.String, oGrupoEmail.Descripcion));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmail, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_GrupoEmail
		/// </summary>
        /// <param name="oGrupoEmail"></param>
		/// <returns></returns>
        public void Insert(GrupoEmail oGrupoEmail)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@id", DbType.Int32, oGrupoEmail.Id));
                oParameters.Add(new DBParametro("@descripcion", DbType.String, oGrupoEmail.Descripcion));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmail, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
        /// GrupoEmail de la tabla dbo.TBL_GrupoEmail
		/// </summary>
        /// <param name="oGrupoEmail"></param>
		/// <returns></returns>
        public List<GrupoEmail> GetAllGrupoEmails()
		{
            try
            {
                CommandText = "PA_MG_FRONT_GrupoEmail_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();

                List<GrupoEmail> gruposEmails = AbstractFindAll(oParameters);
				
				return gruposEmails;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmail, getGrupoEmails", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que crea un objeto GrupoEmail de la tabla dbo.TBL_GrupoEmail
		/// </summary>
        /// <param name="oGrupoEmail"></param>
		/// <returns></returns>
        public override GrupoEmail DoLoad(IDataReader registros)
        {
            try
            {
                GrupoEmail grupoEmail = new GrupoEmail();
				grupoEmail.Id = registros.GetInt32(0);
				grupoEmail.Descripcion = registros.GetString(1);
			
				return grupoEmail;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALGrupoEmail, getGrupoEmails", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override GrupoEmail DoLoad(IDataReader registros, GrupoEmail ent)
        {
            throw new NotImplementedException();
        }
    }
}
