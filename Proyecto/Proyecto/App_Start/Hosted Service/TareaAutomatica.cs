using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Web;

namespace Proyecto.App_Start.Hosted_Service
{
    public class TareaAutomatica
    {
        private static Timer _timer;

        public static void Iniciar()
        {
            _timer = new Timer();
            _timer.Interval = 10000; // 10 segundos
            _timer.Elapsed += Ejecutar;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private static void Ejecutar(object sender, ElapsedEventArgs e)
        {
            try
            {
                string appDataPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data");

                string origen = Path.Combine(appDataPath, "archivo.txt");
                string destino = Path.Combine(appDataPath, $"archivo_copia_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

                if (File.Exists(origen))
                {
                    File.Copy(origen, destino);
                }

                File.AppendAllText(Path.Combine(appDataPath, "correo_log.txt"),
                    $"[SIMULADO] Correo enviado a las {DateTime.Now}\n");
            }
            catch (Exception ex)
            {
                string errorLog = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/error_log.txt");
                File.AppendAllText(errorLog, $"[{DateTime.Now}] ERROR: {ex.Message}\n");
            }
        }

    }
}