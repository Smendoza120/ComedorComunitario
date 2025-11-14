using System.Diagnostics;
using ComedorComunitario.Data.Models;
using ComedorComunitario.Data.Services;
using ComedorComunitario.Data.ViewModel;

namespace ComedorComunitario.Data.AdminCode
{
    public class HomeAdminCode
    {
        //private readonly GoogleSheetsService _sheetsService;

        //public HomeAdminCode(GoogleSheetsService sheetsService)
        //{
        //    _sheetsService = sheetsService;
        //}

        //public async Task<List<PersonaInscrita>> ObtenerListaInscritosDesdeFormularioAsync()
        //{
        //    var dataFromSheets = await _sheetsService.ObtenerInscripcionesAsync();

        //    return dataFromSheets;
        //}

        private readonly GoogleSheetsService _sheetsService;

        public HomeAdminCode(GoogleSheetsService sheetsService)
        {
            _sheetsService = sheetsService;
        }

        // 1. FUNCIÓN DE CONEXIÓN LLAMADA DESDE EL VIEWMODEL
        // Toma el ViewModel como argumento para manipular sus propiedades (IsLoading, Inscripciones).
        public async Task LoadData(HomeViewModel viewModel)
        {
            if (viewModel.IsLoading)
                return;

            try
            {
                viewModel.IsLoading = true;

                var dataList = await ObtenerListaInscritosDesdeFormularioAsync();

                viewModel.Inscripciones.Clear();

                foreach (var item in dataList)
                {
                    viewModel.Inscripciones.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error de carga en AdminCode: {ex.Message}");
                Application.Current.MainPage.DisplayAlert("Error de Carga", "No se pudo consultar el registro. Revise credenciales y conexión.", "OK");
            }
            finally
            {
                viewModel.IsLoading = false;
            }
        }

        public async Task<List<PersonaInscrita>> ObtenerListaInscritosDesdeFormularioAsync()
        {
            var rawData = await _sheetsService.ObtenerValoresCrudosAsync();

            var inscripciones = new List<PersonaInscrita>();

            if (rawData == null || rawData.Count == 0)
            {
                return inscripciones;
            }

            foreach (var row in rawData)
            {
                if (row.Count >= 5)
                {
                    int edad = 0;
                    if (row[3] != null) int.TryParse(row[3].ToString(), out edad);

                    DateTime marcaTemporal;
                    DateTime.TryParse(row[0]?.ToString(), out marcaTemporal);

                    inscripciones.Add(new PersonaInscrita
                    {
                        MarcaTemporal = marcaTemporal,
                        Nombre = row[1]?.ToString(),
                        Apellido = row[2]?.ToString(),
                        Edad = edad,
                        Identificacion = row[4]?.ToString(),
                    });
                }
            }
            return inscripciones;
        }
    }
}
