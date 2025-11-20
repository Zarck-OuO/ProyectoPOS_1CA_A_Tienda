using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPOS_1CA_A.CapaEntidades
{
    public class Validaciones
    {

        public static bool EsEntero(string s)
        {
            int numero;
            return int.TryParse(s, out numero);

        }
        // validacion de dato que sea decimal
        public static bool EsDecimal(string s)
        {
            int numero;
            return int.TryParse(s, out numero);
        }

        //valida direccion de correo electronico
        public static bool EsCorreoValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            //Expresiones regular para validar correo
            var patron = @"^[^@\s]+.[^@\s]+$";
            return Regex.IsMatch(email, patron);
        }


        //Validaciones para clientes
        //valida que dato sea entero
        public static bool EsEnteroc(string s)
        {
            int Telefono;
            return int.TryParse(s, out Telefono);

        }
        //valida que dato sea entero
        public static bool EsEnteroId(string s)
        {
            int Id;
            return int.TryParse(s, out Id);
        }

        //valida direccion de correo electronico
        public static bool EsCorreoValidoc(string Correo)
        {
            if (string.IsNullOrWhiteSpace(Correo))
                return false;
            //Expresiones regular para validar correo
            var patron = @"^[^@\s]+.[^@\s]+$";
            return Regex.IsMatch(Correo, patron);

        }

    }
}

