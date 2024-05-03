using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HIS_API.Util
{
    public class ReferenciasBD
    {
        //Configuración de connection string de la base de datos
        #region obtención de connection string
        private static IConfiguration _config;

        public ReferenciasBD(IConfiguration configuration)
        {
            _config = configuration;
        }

        public SqlConnection OpenConnection(string connectionString = null) 
        {
            if (connectionString == null) 
            {
                connectionString = _config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            }

            SqlConnection con = new SqlConnection(connectionString);

            return con;
        }
        #endregion

        public static string constring = "";// _config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

        //Referencias a Store Procedures
        #region tracking
        public static string SP_TRACKING_BITACORA_ERRORES = "gral.sp_tracking_bitacora_errores";
        #endregion
        public static string SP_SOLICITAR_CORREO = "dbo.P_SOLICITAR_CORREO";
        public static string SP_GESTIONAR_DETALLE_CORREO = "dbo.SP_GESTIONAR_DETALLE_CORREO";
        #region seguridad
        public static string SP_SEGURIDAD_GESTIONAR_SOLICITUD_ENROLAMIENTO_CABECERA = "seg.sp_seguridad_gestionar_solicitud_enrolamiento_cabecera";
        public static string SP_SEGURIDAD_GESTIONAR_SOLICITUD_ENROLAMIENTO_DETALLE = "seg.sp_seguridad_gestionar_solicitud_enrolamiento_detalle";
        public static string SP_SEGURIDAD_GESTIONAR_SOLICITUD_ENROLAMIENTO_ESTADO = "seg.sp_seguridad_gestionar_solicitud_enrolamiento_estado";
        public static string SP_SEGURIDAD_GENERAR_INFORMACION_CORREO_SOLICITUD_ENROLAMIENTO = "seg.sp_seguridad_generar_informacion_correo_solicitud_enrolamiento";
        public static string SP_SEGURIDAD_GESTIONAR_SEGURIDAD_USUARIO = "seg.sp_seguridad_gestionar_seguridad_usuario";
        #endregion
        #region utilitarios
        public static string SP_UTILITARIO_OBTENER_DATOS_MENSAJE = "util.sp_utilitario_obtener_datos_mensaje";
        #endregion
        #region dashboard
        public static string SP_PRTLT_INDICADOR_INFORMES_AUDITORIA_NOTIFICADOS = "gral.sp_prtlt_indicador_informes_auditoria_notificados";
        public static string SP_PRTLT_INDICADOR_INFORMES_AUDITORIA_POR_VERIFICAR = "gral.sp_prtlt_indicador_informes_auditoria_por_verificar";
        public static string SP_PRTLT_INDICADOR_INFORMES_SEGUIMIENTO_APROBADOS = "gral.sp_prtlt_indicador_informes_seguimiento_aprobados";
        public static string SP_PRTLT_INDICADOR_INFORMES_SEGUIMIENTO_ASIGNADOS_APROBADOS = "gral.sp_prtlt_indicador_informes_seguimiento_asignados_aprobados";
        public static string SP_PRTLT_INDICADOR_INFORMES_SEGUIMIENTO_PENDIENTES = "gral.sp_prtlt_indicador_informes_seguimiento_pendientes";
        public static string SP_PRTLT_INDICADOR_PLANES_ACCION_SOLICITADOS = "gral.sp_prtlt_indicador_planes_accion_solicitados";
        public static string SP_PRTLT_TABLA_INFORMES_AUDITORIA_ABIERTOS = "gral.sp_prtlt_tabla_informes_auditoria_abiertos";
        public static string SP_PRTLT_TABLA_INFORMES_AUDITORIA_POR_VERIFICAR = "gral.sp_prtlt_tabla_informes_auditoria_por_verificar";
        public static string SP_PRTLT_TABLA_INFORMES_SEGUIMIENTO_PENDIENTES = "gral.sp_prtlt_tabla_informes_seguimiento_pendientes";
        public static string SP_PRTLT_TABLA_INFORMES_SEGUIMIENTO_RECHAZADOS = "gral.sp_prtlt_tabla_informes_seguimiento_rechazados";
        public static string SP_PRTLT_TABLA_PLANES_ACCION_PENDIENTES = "gral.sp_prtlt_tabla_planes_accion_pendientes";
        public static string SP_PRTLT_GRAFICA_INFORMES_AUDITORIA_NOTIFICADOS = "gral.sp_prtlt_grafica_informes_auditoria_notificados";
        public static string SP_PRTLT_GRAFICA_INFORMES_SEGUIMIENTO_ASIGNADOS = "gral.sp_prtlt_grafica_informes_seguimiento_asignados";
        public static string SP_PRTLT_GRAFICA_PLANES_ACCION_SOLICITADOS = "gral.sp_prtlt_grafica_planes_accion_solicitados";
        #endregion 

        //Referencias a Funciones
        #region utilitarios
        public static string fn_utilitario_obtener_valor_parametro = "gral.fn_utilitario_obtener_valor_parametro";
        #endregion



        //Referencias a métodos reutilizables para el llamado de procedimientos almacenados
        #region procedimientos_almacenados

        public static SqlConnection Sql_Connection(string connection)
        {
            SqlConnection con = new SqlConnection(connection);
            return con;
        }
        public static SqlCommand SqlSpCmd(string StoredProcedure, SqlConnection connectionString)
        {
            SqlCommand cmd = new SqlCommand(StoredProcedure, connectionString);
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }

        public static void SqlDtRd(SqlCommand cmd)
        {
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
        }
        #nullable enable
        public static SqlParameter InVarcharP(SqlCommand cmd, string parameterName, string? parameterValue, bool IsNullable)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = int.MaxValue;
            param.Direction = ParameterDirection.Input;
            param.IsNullable = IsNullable;
            param.Value = parameterValue;

            return cmd.Parameters.Add(param);
        }

        public static SqlParameter InIntP(SqlCommand cmd, string parameterName, int? parameterValue, bool IsNullable)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.SqlDbType = SqlDbType.Int;
            param.Size = int.MaxValue;
            param.Direction = ParameterDirection.Input;
            param.IsNullable = IsNullable;
            param.Value = parameterValue;

            return cmd.Parameters.Add(param);
        }

        public static SqlParameter InTextP(SqlCommand cmd, string parameterName, string? parameterValue, bool IsNullable)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.SqlDbType = SqlDbType.Text;
            param.Size = int.MaxValue;
            param.Direction = ParameterDirection.Input;
            param.IsNullable = IsNullable;
            param.Value = parameterValue;

            return cmd.Parameters.Add(param);
        }



        public static SqlParameter InCharP(SqlCommand cmd, string parameterName, string? parameterValue, bool IsNullable)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.SqlDbType = SqlDbType.Char;
            param.Size = int.MaxValue;
            param.Direction = ParameterDirection.Input;
            param.IsNullable = IsNullable;
            param.Value = parameterValue;

            return cmd.Parameters.Add(param);
        }

        public static SqlParameter InDecimalP(SqlCommand cmd, string parameterName, decimal? parameterValue, bool IsNullable)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.SqlDbType = SqlDbType.Decimal;
            param.Size = int.MaxValue;
            param.Direction = ParameterDirection.Input;
            param.IsNullable = IsNullable;
            param.Value = parameterValue;

            return cmd.Parameters.Add(param);
        }

        public static SqlParameter InTinyIntP(SqlCommand cmd, string parameterName, int? parameterValue, bool IsNullable)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.SqlDbType = SqlDbType.TinyInt;
            param.Size = int.MaxValue;
            param.Direction = ParameterDirection.Input;
            param.IsNullable = IsNullable;
            param.Value = parameterValue;

            return cmd.Parameters.Add(param);
        }

        public static SqlParameter InNvarcharP(SqlCommand cmd, string parameterName, string? parameterValue, bool IsNullable)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.SqlDbType = SqlDbType.NVarChar;
            param.Size = int.MaxValue;
            param.Direction = ParameterDirection.Input;
            param.IsNullable = IsNullable;
            param.Value = parameterValue;

            return cmd.Parameters.Add(param);
        }

        public static SqlParameter InDateTimeP(SqlCommand cmd, string parameterName, DateTime? parameterValue, bool IsNullable)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.SqlDbType = SqlDbType.DateTime;
            param.Size = int.MaxValue;
            param.Direction = ParameterDirection.Input;
            param.IsNullable = IsNullable;
            param.Value = parameterValue;

            return cmd.Parameters.Add(param);
        }

        public static SqlParameter InBitP(SqlCommand cmd, string parameterName, bool? parameterValue, bool IsNullable)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.SqlDbType = SqlDbType.Bit;
            param.Size = int.MaxValue;
            param.Direction = ParameterDirection.Input;
            param.IsNullable = IsNullable;
            param.Value = parameterValue;

            return cmd.Parameters.Add(param);
        }

        public static SqlParameter OutVarcharP(SqlCommand cmd, string parameterName, bool IsNullable)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.SqlDbType = SqlDbType.VarChar;
            param.Size = int.MaxValue;
            param.Direction = ParameterDirection.Output;
            param.IsNullable = IsNullable;

            return cmd.Parameters.Add(param);
        }

        public static SqlParameter OutIntP(SqlCommand cmd, string parameterName, bool IsNullable)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = parameterName;
            param.SqlDbType = SqlDbType.Int;
            param.Size = int.MaxValue;
            param.Direction = ParameterDirection.Output;

            return cmd.Parameters.Add(param);
        }
        #nullable disable
        public static void DefaultOutParams(SqlCommand cmd)
        {
            SqlParameter pnTypeResultParam = new SqlParameter();
            pnTypeResultParam.ParameterName = "@pnTypeResult";
            pnTypeResultParam.SqlDbType = SqlDbType.VarChar;
            pnTypeResultParam.Size = int.MaxValue;
            pnTypeResultParam.Direction = ParameterDirection.Output;

            SqlParameter pnCodeResultParam = new SqlParameter();
            pnCodeResultParam.ParameterName = "@pnCodeResult";
            pnCodeResultParam.SqlDbType = SqlDbType.VarChar;
            pnCodeResultParam.Size = int.MaxValue;
            pnCodeResultParam.Direction = ParameterDirection.Output;

            SqlParameter pcResultParam = new SqlParameter();
            pcResultParam.ParameterName = "@pcResult";
            pcResultParam.SqlDbType = SqlDbType.VarChar;
            pcResultParam.Size = int.MaxValue;
            pcResultParam.Direction = ParameterDirection.Output;

            SqlParameter pcMessageParam = new SqlParameter();
            pcMessageParam.ParameterName = "@pcMessage";
            pcMessageParam.SqlDbType = SqlDbType.VarChar;
            pcMessageParam.Size = int.MaxValue;
            pcMessageParam.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(pnTypeResultParam);
            cmd.Parameters.Add(pnCodeResultParam);
            cmd.Parameters.Add(pcResultParam);
            cmd.Parameters.Add(pcMessageParam);
        }

        public static CustomJsonResult DefaultOutParamsValue(SqlCommand cmd)
        {
            CustomJsonResult OutParams = new CustomJsonResult();
            string pnTypeResult = (cmd.Parameters["@pnTypeResult"].Value.ToString() == "null") ? null : cmd.Parameters["@pnTypeResult"].Value.ToString();
            string pnCodeResult = (cmd.Parameters["@pnCodeResult"].Value.ToString() == "null") ? null : cmd.Parameters["@pnCodeResult"].Value.ToString();

            OutParams.TypeResult = Convert.ToInt32(pnTypeResult);
            OutParams.CodeResult = Convert.ToInt32(pnCodeResult);
            OutParams.Result = (cmd.Parameters["@pcResult"].Value.ToString() == "null") ? null : cmd.Parameters["@pcResult"].Value.ToString();
            OutParams.Message = (cmd.Parameters["@pcMessage"].Value.ToString() == "null") ? null : cmd.Parameters["@pcMessage"].Value.ToString();

            return OutParams;
        }

        #endregion
    }
}
