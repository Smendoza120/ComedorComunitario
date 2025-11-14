using System.Reflection;
using ComedorComunitario.Data.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace ComedorComunitario.Data.Services
{
    public class GoogleSheetsService
    {
        private const string SpreadsheetId = "1j18H5XYViqhX4FDnkWzw7Dk-r8DMuS3shug-WX7ZvhE";
        private const string Range = "Respuestas de formulario 1!A2:D"; 
        //private const string Range = "Respuestas de formulario 1"; 
        private const string CredentialsFileName = "proyectoexcel-477121-e1594d3156be.json";

        public async Task<List<PersonaInscrita>> ObtenerInscripcionesAsync()
        {
            GoogleCredential credential;

            string resourceName = $"ComedorComunitario.Configuration.{CredentialsFileName}";

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException($"No se encontró el recurso incrustado: {resourceName}. Revise el Build Action del archivo JSON.");
                }

                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(SheetsService.Scope.SpreadsheetsReadonly);
            }

            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Comedor Comunitario MAUI",
            });

            SpreadsheetsResource.ValuesResource.GetRequest request =
                        service.Spreadsheets.Values.Get(SpreadsheetId, Range);

            ValueRange response = await request.ExecuteAsync();
            IList<IList<object>> values = response.Values;

            var inscripciones = new List<PersonaInscrita>();

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    if (row.Count >= 5)
                    {
                        int edad = 0;
                        int.TryParse(row[3]?.ToString(), out edad);

                        inscripciones.Add(new PersonaInscrita
                        {
                            MarcaTemporal = DateTime.Parse(row[0].ToString()), 
                            Nombre = row[1].ToString(),                       
                            Apellido = row[2].ToString(),                     
                            Edad = edad,                                      
                            Identificacion = row[4].ToString(),               
                        });
                    }
                }
            }
            return inscripciones;
        }
    }
}
