# ComedorComunitario

## ⚙️ Requisitos Previos

Para poder compilar y ejecutar el proyecto **ComedorComunitario**, es necesario tener instalado lo siguiente:

* **Visual Studio:** Versión 2022 (o superior). Se recomienda instalar la edición Community, Professional o Enterprise.
* **Carga de Trabajo de .NET MAUI:** Al instalar Visual Studio, asegúrate de seleccionar e instalar la carga de trabajo de desarrollo de interfaz de usuario de aplicaciones multiplataforma de .NET.
* **.NET SDK:** La versión necesaria para este proyecto es el **.NET 8 SDK** (o la versión que estés utilizando, ej. .NET 7).
* **Plataformas Específicas (Opcional):**
    * **Android:** Necesitarás el SDK de Android instalado y configurado en Visual Studio.
    * **iOS/macOS:** Para desarrollar y depurar para iOS, necesitarás una Mac y tener instalado Xcode, además de configurar el emparejamiento con Mac en Visual Studio.

## 🚀 Primeros Pasos

Sigue estos pasos para obtener una copia local de este proyecto y ejecutarlo:

1.  **Clonar el Repositorio:**
    Abre tu terminal o Git Bash y clona el proyecto:
    ```bash
    git clone [https://github.com/](https://github.com/)[TU_USUARIO]/ComedorComunitario.git
    cd ComedorComunitario
    ```

2.  **Restaurar Dependencias de NuGet:**
    Los proyectos de .NET usan NuGet para manejar dependencias externas. Es necesario restaurar los paquetes antes de compilar.
    Puedes hacer esto desde la línea de comandos (en la carpeta raíz que contiene el archivo `.sln`):
    ```bash
    dotnet restore ComedorComunitario.sln
    ```
    *Alternativamente, Visual Studio suele realizar esta restauración automáticamente al abrir la solución.*

3.  **Abrir y Ejecutar la Solución:**
    * Abre el archivo **`ComedorComunitario.sln`** con Visual Studio 2022.
    * Una vez abierta, selecciona la plataforma de destino (ej. "Windows Machine", "Android Emulator", etc.) en el menú desplegable.
    * Presiona **F5** o el botón "Iniciar" en Visual Studio para compilar y ejecutar el proyecto.

## 🛠️ Solución de Problemas Comunes

Si encuentras problemas al compilar:

* **Error de Carga de Trabajo Faltante:** Verifica que la carga de trabajo de **.NET MAUI** esté instalada a través del Instalador de Visual Studio.
* **Error de Compilación de Android:** Asegúrate de que tienes un emulador de Android configurado y corriendo, y que las licencias del SDK de Android han sido aceptadas.
* **Limpiar la Solución:** A veces, los archivos temporales causan problemas. En Visual Studio, ve a **Build > Clean Solution**, y luego **Build > Rebuild Solution**.