using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoMoto.Common
{
    public class Constantes
    {
        public const string INSERCCION_EXITOSA = "Insercción exitosa";
        public const string EXITO = "Exito";
        public const string ERROR = "Error !";
        public const string VERIFICAR_DATOS = "Verifica tus datos";
        public const string CAMPOS_VACIOS = "Campos vacios";
        public const string DATOS_CORRECTOS = "Tus datos son correctos";

        public class TipoUsuario
        {
            public const long USUARIO = 1;
            public const long CLIENTE = 2;
            public const long PROVEEDOR = 3;
        }

    }

    //public enum TipoUsuario
    //{
    //    USUARIO = 1,
    //    CLIENTE,
    //    PROVEEDOR
    //}

    
}
