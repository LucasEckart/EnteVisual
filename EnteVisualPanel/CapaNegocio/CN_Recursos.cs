﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;
using System.Net;
using System.IO;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;

namespace CapaNegocio
{
    public class CN_Recursos
    {

        private MailMessage email;
        private SmtpClient server;

        public static string generarClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0, 8);
            return clave;
        }


        public static string ConvertirSha256(string texto)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }


        public static bool enviarCorreo(string correo, string asunto, string mensaje)
        {
            bool resultado = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("ltupacxe@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;

                //rjisfiqjmfvlaanz
                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("ltupacxe@gmail.com", "rjisfiqjmfvlaanz"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                };

                smtp.Send(mail);
                resultado = true;

            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }



    }
}
