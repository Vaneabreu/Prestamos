using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftLoans.Capas.Model
{
    public static class OpcionesNotificaciones
    {
        private static string borrar;
        public static string Borrar { get { return borrar; } }

        private static string cancelar;
        public static string Cancelar { get { return cancelar; } }

        static OpcionesNotificaciones() 
        {
            borrar = "Borrar";
            cancelar = "Cancelar";
        }

    }
}