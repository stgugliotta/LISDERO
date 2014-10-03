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
    public class DALPersonaHistorico: AbstractMapper<PersonaHistorico>
    {
        /// <summary>
        /// Constructor Standard
		/// </summary>
		public DALPersonaHistorico()
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
        /// M?todo que retorna solo un objeto  Persona
		/// </summary>
		/// <param name="id"></param>               
		/// <returns></returns>
		public PersonaHistorico Load(int id)
		{
            try
            {
                PersonaHistorico oReturn = null;
				CommandText = "PA_MG_FRONT_PersonaHistorico_SELECT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, id));

                List<PersonaHistorico> personas = AbstractFindAll(oParameters);
				if (personas.Count > 0)
				{
					oReturn = personas[0];
				}
				
				return oReturn;
			}
		    catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersonaHistorico, Load", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}        

		
		/// <summary>
        /// M?todo que realiza elimana un registro enla tabla dbo.TBL_Persona
		/// </summary>
		/// <param name="oPersona"></param>
		/// <returns></returns>
        public void Delete(PersonaHistorico oPersona)
		{
            try
            {
                CommandText = "PA_MG_FRONT_PersonaHistorico_DELETE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oPersona.Id));															
				
				ExecuteNonQuery(oParameters);
            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersonaHistorico, Delete", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
		/// <summary>
        /// M?todo que realiza Actualizacion en la tabla dbo.TBL_Persona
		/// </summary>
		/// <param name="oPersona"></param>
		/// <returns></returns>
        public void Update(PersonaHistorico oPersona)
		{
            try
            {
                CommandText = "PA_MG_FRONT_PersonaHistorico_UPDATE";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				
				oParameters.Add(new DBParametro("@id", DbType.Int32, oPersona.Id));
                oParameters.Add(new DBParametro("@fecha_codigo", DbType.DateTime, oPersona.Fecha_Codigo));
                oParameters.Add(new DBParametro("@fecha_nombre", DbType.DateTime, oPersona.Fecha_Nombre));
                oParameters.Add(new DBParametro("@fecha_contacto", DbType.DateTime, oPersona.Fecha_Contacto));
                oParameters.Add(new DBParametro("@fecha_idtipocalificacion", DbType.DateTime, oPersona.Fecha_TipoCalificacion));
                oParameters.Add(new DBParametro("@fecha_idsector", DbType.DateTime, oPersona.Fecha_Sector));
                oParameters.Add(new DBParametro("@fecha_idsubsector", DbType.DateTime, oPersona.Fecha_SubSector));
                oParameters.Add(new DBParametro("@fecha_vinculo", DbType.DateTime, oPersona.Fecha_Vinculo));
                oParameters.Add(new DBParametro("@fecha_origencontacto", DbType.DateTime, oPersona.Fecha_OrigenContacto));
                oParameters.Add(new DBParametro("@fecha_idtratamiento", DbType.DateTime, oPersona.Fecha_Tratamiento));
                oParameters.Add(new DBParametro("@fecha_documento", DbType.DateTime, oPersona.Fecha_Documento));
                oParameters.Add(new DBParametro("@fecha_idtipodocumento", DbType.DateTime, oPersona.Fecha_TipoDocumento));
                oParameters.Add(new DBParametro("@fecha_cuit", DbType.DateTime, oPersona.Fecha_Cuit));
                oParameters.Add(new DBParametro("@fecha_idprofesion", DbType.DateTime, oPersona.Fecha_Profesion));
                oParameters.Add(new DBParametro("@fecha_idcargo", DbType.DateTime, oPersona.Fecha_Cargo));
                oParameters.Add(new DBParametro("@fecha_notas", DbType.DateTime, oPersona.Fecha_Notas));
                oParameters.Add(new DBParametro("@fecha_domicilio", DbType.DateTime, oPersona.Fecha_Domicilios));
                oParameters.Add(new DBParametro("@fecha_emails", DbType.DateTime, oPersona.Fecha_Emails));
                oParameters.Add(new DBParametro("@fecha_telefono", DbType.DateTime, oPersona.Fecha_Telefonos));

				
				ExecuteNonQuery(oParameters);


            }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersonaHistorico, Update", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
        }
		
	    /// <summary>
        /// M?todo que realiza Inserta un registro en la tabla dbo.TBL_Persona
		/// </summary>
		/// <param name="oPersona"></param>
		/// <returns></returns>
        public void Insert(PersonaHistorico oPersona)
		{
			 try
            {   

                CommandText = "PA_MG_FRONT_PersonaHistorico_INSERT";
				CommandType = CommandType.StoredProcedure;
				ArrayList oParameters = new ArrayList();
				oParameters.Add(new DBParametro("@id", DbType.Int32, oPersona.Id));
                oParameters.Add(new DBParametro("@fecha_codigo", DbType.DateTime, oPersona.Fecha_Codigo));
				oParameters.Add(new DBParametro("@fecha_nombre", DbType.DateTime, oPersona.Fecha_Nombre));
				oParameters.Add(new DBParametro("@fecha_contacto", DbType.DateTime, oPersona.Fecha_Contacto));
				oParameters.Add(new DBParametro("@fecha_idtipocalificacion", DbType.DateTime, oPersona.Fecha_TipoCalificacion));
                oParameters.Add(new DBParametro("@fecha_idsector", DbType.DateTime, oPersona.Fecha_Sector));
                oParameters.Add(new DBParametro("@fecha_idsubsector", DbType.DateTime, oPersona.Fecha_SubSector));
                oParameters.Add(new DBParametro("@fecha_vinculo", DbType.DateTime, oPersona.Fecha_Vinculo));
                oParameters.Add(new DBParametro("@fecha_origencontacto", DbType.DateTime, oPersona.Fecha_OrigenContacto));
                oParameters.Add(new DBParametro("@fecha_idtratamiento", DbType.DateTime, oPersona.Fecha_Tratamiento));
                oParameters.Add(new DBParametro("@fecha_documento", DbType.DateTime, oPersona.Fecha_Documento));
                oParameters.Add(new DBParametro("@fecha_idtipodocumento", DbType.DateTime, oPersona.Fecha_TipoDocumento));
                oParameters.Add(new DBParametro("@fecha_cuit", DbType.DateTime, oPersona.Fecha_Cuit));
                oParameters.Add(new DBParametro("@fecha_idprofesion", DbType.DateTime, oPersona.Fecha_Profesion));
                oParameters.Add(new DBParametro("@fecha_idcargo", DbType.DateTime, oPersona.Fecha_Cargo));
                oParameters.Add(new DBParametro("@fecha_idNotas", DbType.DateTime, oPersona.Fecha_Notas));
                oParameters.Add(new DBParametro("@fecha_domicilio", DbType.DateTime, oPersona.Fecha_Domicilios));
                oParameters.Add(new DBParametro("@fecha_emails", DbType.DateTime, oPersona.Fecha_Emails));
                oParameters.Add(new DBParametro("@fecha_telefono", DbType.DateTime, oPersona.Fecha_Telefonos));
                
                object idPersona=ExecuteScalar(oParameters);                            
                
             }
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersonaHistorico, Insert", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}
	 
			/// <summary>
        /// M?todo que crea un objeto Persona de la tabla dbo.TBL_Persona
		/// </summary>
		/// <param name="oPersona"></param>
		/// <returns></returns>
        public override PersonaHistorico DoLoad(IDataReader registros)
        {
            try
            {
                PersonaHistorico persona = new PersonaHistorico();
				persona.Id = registros.GetInt32(0);
				persona.Fecha_Codigo = registros.GetDateTime(1);
				persona.Fecha_Nombre = registros.GetDateTime(2);
                persona.Fecha_Contacto = registros.GetDateTime(3);               
                persona.Fecha_TipoCalificacion = registros.GetDateTime(4);               
                persona.Fecha_Sector = registros.GetDateTime(5);
                persona.Fecha_SubSector = registros.GetDateTime(6);				
                persona.Fecha_Vinculo = registros.GetDateTime(7);
                persona.Fecha_OrigenContacto = registros.GetDateTime(8);            
                persona.Fecha_Tratamiento = registros.GetDateTime(9);
                persona.Fecha_Documento = registros.GetDateTime(10);
                persona.Fecha_TipoDocumento = registros.GetDateTime(11);                    
                persona.Fecha_Cuit = registros.GetDateTime(12);
                persona.Fecha_Profesion = registros.GetDateTime(13);
                persona.Fecha_Cargo = registros.GetDateTime(14);
                persona.Fecha_Notas = registros.GetDateTime(15);
                persona.Fecha_Domicilios= registros.GetDateTime(16);
                persona.Fecha_Emails = registros.GetDateTime(17);
                persona.Fecha_Telefonos = registros.GetDateTime(18);
                return persona;
				}
            catch (Exception ex)
            {
                Gobbi.CoreServices.Logging.Logger.WriteError("Clase: DALPersonaHistorico, getPersonas", ex.Message);

                throw new GobbiTechnicalException(
                    string.Format("An exception of type {0} was encountered {1}", ex.GetType(), ex.StackTrace), ex);
            }
		}


        public override PersonaHistorico DoLoad(IDataReader registros, PersonaHistorico ent)
        {
            throw new NotImplementedException();
        }

    }
}
