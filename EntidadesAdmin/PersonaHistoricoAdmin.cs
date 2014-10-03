using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using EntidadesDAL;

namespace EntidadesAdmin
{
    public class PersonaHistoricoAdmin
    {
        /// <summary>
        /// M?todo de lectura de objeto Persona 
        /// </summary>
        /// <param name="id"></param>		
        /// <returns></returns>
        public PersonaHistorico Load(int id)
        {
            PersonaHistorico oReturn = new PersonaHistorico();
            try
            {
                using (DALPersonaHistorico dalPersona = new DALPersonaHistorico())
                {
                    oReturn = dalPersona.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }

        /// <summary>
        /// M?todo para eliminar un objeto Persona
        /// </summary>
        /// <param name="oPersona"></param>
        public void Delete(PersonaHistorico oPersona)
        {
            try
            {
                using (DALPersonaHistorico dalPersona = new DALPersonaHistorico())
                {
                    dalPersona.Delete(oPersona);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo para Actualizar  un objeto Persona 
        /// </summary>
        /// <param name="oPersona"></param>
        public void Update(PersonaHistorico oPersona)
        {
            try
            {
                using (DALPersonaHistorico dalPersona = new DALPersonaHistorico())
                {
                    dalPersona.Update(oPersona);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// M?todo para Inserta un Objeto Persona 
        /// </summary>
        /// <param name="oPersona"></param>
        public void Insert(PersonaHistorico oPersona)
        {
            try
            {
                using (DALPersonaHistorico dalPersona = new DALPersonaHistorico())
                {
                    dalPersona.Insert(oPersona);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// M?todo de lectura de objeto PersonaHistorico 
        /// se deja por compatibilidad con Standares
        /// </summary>
        /// <param name="id"></param>               
        /// <returns></returns>
        public PersonaHistorico GetPersona(int id)
        {
            PersonaHistorico oReturn = new PersonaHistorico();
            try
            {
                using (DALPersonaHistorico dalPersona = new DALPersonaHistorico())
                {
                    oReturn = dalPersona.Load(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oReturn;
        }
     
    }
}
