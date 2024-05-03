using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIS_API.Util
{
    public class Util
    {
        public static string semilla = "/2F{Me}/wiVo[a5q_LoU";
        public static string descripcion_claim_1 = "codigo_usuario";

        public static int operacion_crear = 1;
        public static int operacion_modificar = 2;
        public static int operacion_eliminar = 3;
        public static int operacion_obtener = 4;
        public static int indice_parametro_token_codigo_usuario = 0;

        #region constantes utilizadas en los SPs según escenarios específicos
        //[gral].[sp_prtlt_indicador_informes_auditoria_notificados]
        public static int EscenarioGestorNotificaciones = 1; 
        public static int EscenarioJefeSeguimiento = 2;
        public static int EscenarioMagistrado = 3;

        //[gral].[sp_prtlt_indicador_informes_seguimiento_aprobados] | [gral].[sp_prtlt_indicador_planes_accion_solicitados] | [gral].[sp_prtlt_indicador_informes_seguimiento_pendientes]
        public static int EscenarioJefeSeguimientoIISAPAS = 1;
        public static int EscenarioMagistradoIISAPAS = 2;

        //[gral].[sp_prtlt_indicador_informes_seguimiento_asignados_aprobados]
        public static int EscenarioAsignados = 1;
        public static int EscenarioAsignadosAprobados = 2;

        #endregion
    }
}
