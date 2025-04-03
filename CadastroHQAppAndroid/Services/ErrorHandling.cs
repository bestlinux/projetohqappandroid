namespace CadastroHQAppAndroid.Services;

public class ErrorHandling
{
    public static void InitializeGlobalExceptionHandler()
    {
        AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
        {
            Exception exception = e.ExceptionObject as Exception;
            HandleException(exception);
        };

        TaskScheduler.UnobservedTaskException += (sender, e) =>
        {
            Exception exception = e.Exception;
            HandleException(exception);
        };

        // Configurar outros manipuladores de exceção, se necessário
    }

    private static string HandleException(Exception exception)
    {
        // Lide com a exceção de acordo com a necessidade
        return $"Exceção não tratada: {exception.Message}";
        // Registre a exceção em um log ou notifique o usuário sobre o erro
    }
}
