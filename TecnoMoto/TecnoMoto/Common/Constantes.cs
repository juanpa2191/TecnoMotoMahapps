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

    }

    public enum TipoUsuario
    {
        USUARIO,
        CLIENTE,
        PROVEEDOR
    }
}
