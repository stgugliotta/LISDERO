using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

/// <summary>
/// Descripción breve de Correos
/// </summary>
public class Correos
{
	
        SmtpClient server = new SmtpClient("smtp.gmail.com", 587);
 
        public Correos()
        {
            /*
             * Autenticacion en el Servidor
             * Utilizaremos nuestra cuenta de correo
             *
             * Direccion de Correo (Gmail o Hotmail)
             * y Contrasena correspondiente
             */
            server.Credentials = new System.Net.NetworkCredential("nataliaecortez@gmail.com", "Desamparados");
            server.EnableSsl = true;
        }
 
        public void MandarCorreo(MailMessage mensaje)
        {
            server.Send(mensaje);
        }
	
}