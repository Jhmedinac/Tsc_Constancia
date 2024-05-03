using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsc_Constancia.Util;
using System.Data.SqlClient;

namespace Tsc_Constancia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Descripción del servicio.
        /// </summary>
        /// <remarks>
        /// Estructura JSON esperada
        ///
        ///     {
        ///         "codigo": int,
        ///     }
        /// 
        /// Definición de parámetros:
        /// <para>codigo: Descripción del parámetro.</para>
        ///     
        /// Retorna una estructura JSON con siguiente estructura:
        /// 
        ///     {
        ///         "typeResult": int,
        ///         "codeResult": int,
        ///         "result": string,
        ///         "message": string
        ///     }
        ///
        /// <para>En la etiqueta typeResult, se retorna el estado de la ejecución del servicio [0: Exitoso | 1: Error Controlado | 2: Error no controlado]</para>
        /// <para>En la etiqueta codeResult, se retorna un detalle del TypeResult</para>
        /// <para>En la etiqueta result, se retorna las respuestas esperadas del servicio. Para este servicio se retornará el código de usuario creado.</para>
        /// <para>En la etiqueta message, se retorna un mensaje de tipo informativo, error o éxito.</para>
        ///
        /// </remarks>
        /// <returns>
        /// </returns>
        /// <response code="200">OK. Servicio ejecutado correctamente.</response>
        /// <response code="400">BadRequest. Ocurrió un error en la ejecución del servicio.</response>
        /// <response code="401">Unauthorized. Token inválido.</response>


        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get(string constring, int uploadId)
        {
            CustomJsonResult Rslt = new CustomJsonResult();
            String methodName = "BitacoraErrores" + "Service";
            try
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(ReferenciasBD.SP_TRACKING_BITACORA_ERRORES, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pnCodigoUsuario", SqlDbType.Int).Value = model.codigo_usuario;
                    cmd.Parameters.Add("@pcComponente", SqlDbType.VarChar).Value = model.componente;
                    cmd.Parameters.Add("@pcDescripcion", SqlDbType.VarChar).Value = model.descripcion;

                    // parámetros de salida
                    SqlParameter pcTypeResultparam = new SqlParameter();
                    pcTypeResultparam.ParameterName = "@pnTypeResult";
                    pcTypeResultparam.SqlDbType = SqlDbType.VarChar;
                    pcTypeResultparam.Size = int.MaxValue;
                    pcTypeResultparam.Direction = ParameterDirection.Output;

                    SqlParameter pcCodeResultparam = new SqlParameter();
                    pcCodeResultparam.ParameterName = "@pnCodeResult";
                    pcCodeResultparam.SqlDbType = SqlDbType.VarChar;
                    pcCodeResultparam.Size = int.MaxValue;
                    pcCodeResultparam.Direction = ParameterDirection.Output;

                    SqlParameter pcResultparam = new SqlParameter();
                    pcResultparam.ParameterName = "@pcResult";
                    pcResultparam.SqlDbType = SqlDbType.VarChar;
                    pcResultparam.Size = int.MaxValue;
                    pcResultparam.Direction = ParameterDirection.Output;

                    SqlParameter pcMessageparam = new SqlParameter();
                    pcMessageparam.ParameterName = "@pcMessage";
                    pcMessageparam.SqlDbType = SqlDbType.VarChar;
                    pcMessageparam.Size = int.MaxValue;
                    pcMessageparam.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(pcTypeResultparam);
                    cmd.Parameters.Add(pcCodeResultparam);
                    cmd.Parameters.Add(pcResultparam);
                    cmd.Parameters.Add(pcMessageparam);

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Close();

                    String pcTypeResult = (cmd.Parameters["@pnTypeResult"].Value.ToString() == "null") ? null : cmd.Parameters["@pnTypeResult"].Value.ToString();
                    String pcCodeResult = (cmd.Parameters["@pnCodeResult"].Value.ToString() == "null") ? null : cmd.Parameters["@pnCodeResult"].Value.ToString();
                    String pcResult = (cmd.Parameters["@pcResult"].Value.ToString() == "null") ? null : cmd.Parameters["@pcResult"].Value.ToString();
                    String pcMessage = (cmd.Parameters["@pcMessage"].Value.ToString() == "null") ? null : cmd.Parameters["@pcMessage"].Value.ToString();

                    conn.Close();

                    Rslt.TypeResult = Convert.ToInt32(pcTypeResult);
                    Rslt.CodeResult = Convert.ToInt32(pcCodeResult);
                    Rslt.Result = pcResult;
                    Rslt.Message = pcMessage;
                }

                return Rslt;

            }
            catch (Exception e)
            {
                String msjError = "Error en el método: " + methodName + ". " + e;
                Rslt.Message = msjError;
                return Rslt;
            }
        }

    }
}