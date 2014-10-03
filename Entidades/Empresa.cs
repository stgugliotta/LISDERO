using System;
using System.Collections.Generic;
using System.Text;
using Common.DataContracts;
using Entidades.Mapping;

namespace Entidades
{
	/// <summary>
	///  Clase Entidad de la tabla dbo.TBL_Empresa
	/// </summary>
	public class Empresa : Entity <Empresa, EmpresaDataContracts>
	{
		#region C O N S T R U C T O R S 
		/// <summary>
    	/// Constructor Standard de  Empresa
		/// </summary>
		public  Empresa()
		{
		}
		#endregion
		
		#region A T T R I B U T E S
		private int id;
		private int codigo;
		private string nombre;
		private string contacto;
		private int idTipoCalificacion;
		private int idSector;
		private int idSubSector;
		private string vinculo;
		private string origenContacto;
		private int idTratamiento;
		private string cuit;
		private int idCargo;
		private int idIIBB;
		private string numeroInscripcion;
		private bool activo;
		private int idIVA;
		private string web;
		private string horario;
		private string notas;
        private List<Domicilio> domicilios;
        private List<Telefono> telefonos;
        private List<Email> emails;
		#endregion
		
		#region P U B L I C    P R O P E R T I E S
			public int Id
				{
					get { return this.id; }
					set { this.id = value; }
				}
		
			public int Codigo
				{
					get { return this.codigo; }
					set { this.codigo = value; }
				}
		
			public string Nombre
				{
					get { return this.nombre; }
					set { this.nombre = value; }
				}
		
			public string Contacto
				{
					get { return this.contacto; }
					set { this.contacto = value; }
				}

            public List<Domicilio> Domicilios
            {
                get { return this.domicilios; }
                set { this.domicilios = value; }
            }

            public List<Telefono> Telefonos
            {
                get { return this.telefonos; }
                set { this.telefonos = value; }
            }

            public List<Email> Emails
            {
                get { return this.emails; }
                set { this.emails = value; }
            }

			public int IdTipoCalificacion
				{
					get { return this.idTipoCalificacion; }
					set { this.idTipoCalificacion = value; }
				}
		
			public int IdSector
				{
					get { return this.idSector; }
					set { this.idSector = value; }
				}
		
			public int IdSubSector
				{
					get { return this.idSubSector; }
					set { this.idSubSector = value; }
				}
		
			public string Vinculo
				{
					get { return this.vinculo; }
					set { this.vinculo = value; }
				}
		
			public string OrigenContacto
				{
					get { return this.origenContacto; }
					set { this.origenContacto = value; }
				}
		
			public int IdTratamiento
				{
					get { return this.idTratamiento; }
					set { this.idTratamiento = value; }
				}
		
			public string Cuit
				{
					get { return this.cuit; }
					set { this.cuit = value; }
				}
		
			public int IdCargo
				{
					get { return this.idCargo; }
					set { this.idCargo = value; }
				}
		
			public int IdIIBB
				{
					get { return this.idIIBB; }
					set { this.idIIBB = value; }
				}
		
			public string NumeroInscripcion
				{
					get { return this.numeroInscripcion; }
					set { this.numeroInscripcion = value; }
				}
		
			public bool Activo
				{
					get { return this.activo; }
					set { this.activo = value; }
				}
		
			public int IdIVA
				{
					get { return this.idIVA; }
					set { this.idIVA = value; }
				}
		
			public string Web
				{
					get { return this.web; }
					set { this.web = value; }
				}
		
			public string Horario
				{
					get { return this.horario; }
					set { this.horario = value; }
				}
		
			public string Notas
				{
					get { return this.notas; }
					set { this.notas = value; }
				}
		
		
		#endregion
	}
}
