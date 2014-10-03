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
    /// Clase que maneja la persistencia de la tabla dbo.TBL_Email
	/// </summary>
    public class DALEmail : AbstractMapper<Email>
    {
		/// <summary>
        /// Constructor Standard
		/// </summary>
		public DALEmail()
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
        /// M?todo que retorna solo un objeto  Email
		/// </summary>
		/// <param name="id"></param>    
		/// <returns></returns>
		public Email Load(int id)
		{
            try
            {
				Email oReturn = null;
				CommandText = "PA_MG_FRONT_Email_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));
				
				List<Email> emails = AbstractFindAll(oParameters);
				if (emails.Count > 0)
				{
					oReturn = emails[0];
					}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmail, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Email
		/// </summary>
		/// <param name="oEmail"></param>
		/// <returns></returns>
		public void Delete(Email oEmail)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Email_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oEmail.Id));				
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmail, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


        public void DeletePorCodigo(int codigo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Email_Delete_PorCodigo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();

                oParameters.Add(new DBParametro("@codigo", DbType.Int32, codigo));

                ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmail, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Email
		/// </summary>
		/// <param name="oEmail"></param>
		/// <returns></returns>
		public void Update(Email oEmail)
		{
            try
            {
                CommandText = "PA_MG_FRONT_Email_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oEmail.Id));
				oParameters.Add(new DBParametro("@email", DbType.String, oEmail.Emaill));
				oParameters.Add(new DBParametro("@idgrupomail", DbType.Int32, oEmail.IdGrupoMail));
				oParameters.Add(new DBParametro("@idrelacion", DbType.Int32, oEmail.IdRelacion));
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmail, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Email
		/// </summary>
		/// <param name="oEmail"></param>
		/// <returns></returns>
		public void Insert(Email oEmail)
		{
			 try
            {
                CommandText = "PA_MG_FRONT_Email_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oEmail.Id));
				oParameters.Add(new DBParametro("@email", DbType.String, oEmail.Emaill));
				oParameters.Add(new DBParametro("@idgrupomail", DbType.Int32, oEmail.IdGrupoMail));
				oParameters.Add(new DBParametro("@idrelacion", DbType.Int32, oEmail.IdRelacion));
				
				ExecuteNonQuery(oParameters);
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmail, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
		/// <summary>
        /// M?todo que retorna  todos los registro convertido e nuna lista de Objetos
		/// Email de la tabla dbo.TBL_Email
		/// </summary>
		/// <param name="oEmail"></param>
		/// <returns></returns>
		public List<Email> GetAllEmails()
		{
            try
            {
				CommandText = "PA_MG_FRONT_Email_SELECTALL";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				List<Email> emails = AbstractFindAll(oParameters);
				
				return emails;
			}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmail, getEmails", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }

        public List<Email> GetAllEmailsPersonasPorCodigo(int codigo)
        {
            try
            {
                CommandText = "PA_MG_FRONT_Email_SELECTALL_PersonasPorCodigo";
                CommandType = CommandType.StoredProcedure;
                ArrayList oParameters = new ArrayList();
                oParameters.Add(new DBParametro("@codigo", DbType.Int32, codigo));
                List<Email> emails = AbstractFindAll(oParameters);

                return emails;
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmail, getTelefonos", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }


		/// <summary>
        /// M?todo que crea un objeto Email de la tabla dbo.TBL_Email
		/// </summary>
		/// <param name="oEmail"></param>
		/// <returns></returns>
		public override Email DoLoad(IDataReader registros)
        {
            try
            {
				Email email = new Email();
				email.Id = registros.GetInt32(0);
				email.Emaill = registros.GetString(1);
				email.IdGrupoMail = registros.GetInt32(2);
				email.IdRelacion = registros.GetInt32(3);
			
				return email;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALEmail, getEmails", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override Email DoLoad(IDataReader registros, Email ent)
        {
            throw new NotImplementedException();
        }
    }
}
