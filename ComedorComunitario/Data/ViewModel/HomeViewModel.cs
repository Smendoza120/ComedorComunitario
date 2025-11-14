using System.Collections.ObjectModel;
using System.Windows.Input;
using ComedorComunitario.Data.AdminCode;
using ComedorComunitario.Data.Base;
using ComedorComunitario.Data.Models;

namespace ComedorComunitario.Data.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        //private readonly HomeAdminCode HomeAC;

        //public ObservableCollection<PersonaInscrita> Inscripciones { get; } = new();

        //private bool _isLoading;
        //public bool IsLoading
        //{
        //    get => _isLoading;
        //    set => SetProperty(ref _isLoading, value); 
        //}

        //public ICommand LoadDataCommand { get; }

        //public HomeViewModel(HomeAdminCode adminCode) 
        //{
        //    HomeAC = adminCode;
        //    LoadDataCommand = new Command(async () => await ExecuteLoadInscripcionesCommand());
        //}

        ///// <summary>
        ///// Lógica de presentación: maneja el estado de la UI y llama a la capa de negocio.
        ///// </summary>
        //private async Task ExecuteLoadInscripcionesCommand()
        //{
        //    if (IsLoading)
        //        return;

        //    try
        //    {
        //        IsLoading = true;
        //        // Siempre limpiar la colección para evitar duplicados en cada consulta
        //        Inscripciones.Clear();

        //        var data = await HomeAC.ObtenerListaInscritosDesdeFormularioAsync();

        //        // Si data es null, salimos para evitar un fallo
        //        if (data == null)
        //            return;

        //        // CRÍTICO: Envuelve el bucle de adición en un try-catch para aislar fallos de conversión
        //        foreach (var persona in data)
        //        {
        //            try
        //            {
        //                // La línea que podría fallar si el objeto 'persona' es inválido o null,
        //                // aunque esto debería estar manejado en el GoogleSheetsService.
        //                Inscripciones.Add(persona);
        //            }
        //            catch (Exception exInner)
        //            {
        //                // Si falla al agregar una persona, simplemente la omitimos.
        //                // Podríamos registrar el error aquí si fuera necesario.
        //                System.Diagnostics.Debug.WriteLine($"Error al agregar persona: {exInner.Message}");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Este catch maneja errores de red, credenciales o del servicio (GoogleSheetsService)
        //        await Application.Current.MainPage.DisplayAlert("Error de Carga", "No se pudo consultar el registro. Revise credenciales y conexión.", "OK");
        //    }
        //    finally
        //    {
        //        IsLoading = false;
        //    }
        //}

        private readonly HomeAdminCode HomeAC;

        private ObservableCollection<PersonaInscrita> _inscripciones = new();
        public ObservableCollection<PersonaInscrita> Inscripciones
        {
            get => _inscripciones;
            set => SetProperty(ref _inscripciones, value);
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ICommand LoadDataCommand { get; }

        public HomeViewModel(HomeAdminCode adminCode)
        {
            HomeAC = adminCode;

            LoadDataCommand = new Command(async () => await HomeAC.LoadData(this));
        }
    }
}
