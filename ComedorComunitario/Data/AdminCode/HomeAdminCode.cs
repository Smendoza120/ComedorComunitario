using ComedorComunitario.Data.Models;
using ComedorComunitario.Data.Services;

namespace ComedorComunitario.Data.AdminCode
{
    public class HomeAdminCode
    {
        private readonly GoogleSheetsService _sheetsService;

        public HomeAdminCode(GoogleSheetsService sheetsService)
        {
            _sheetsService = sheetsService;
        }

        public async Task<List<PersonaInscrita>> ObtenerListaInscritosDesdeFormularioAsync()
        {
            var dataFromSheets = await _sheetsService.ObtenerInscripcionesAsync();

            return dataFromSheets;
        }
    }
}
