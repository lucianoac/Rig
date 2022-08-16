namespace Rig.Application
{
    public class CommandExecutionResult
    {
        public const string DEFAULT_SUCCESS_MESSAGE = "Success";
        public const string DEFAULT_FAIL_MESSAGE = "Fail";
        public bool Succeeded { get; }
        public bool Failed => !Succeeded;

        public string UserMessage { get; }
        public string DebugMessage { get; }

        private CommandExecutionResult(bool succeeded, string userMessage, Exception? ex = null)
        {
            Succeeded = succeeded;
            UserMessage = userMessage;
            DebugMessage = ex != null ? ex.ToString() : string.Empty;
        }

        public static CommandExecutionResult Sucess(string mensagemAmigavel = DEFAULT_SUCCESS_MESSAGE)
        {
            return new CommandExecutionResult(true, mensagemAmigavel);
        }

        public static CommandExecutionResult Fail(string mensagemAmigavel = DEFAULT_FAIL_MESSAGE)
        {
            return new CommandExecutionResult(false, mensagemAmigavel);
        }

        public static CommandExecutionResult Exception(Exception ex)
        {
            return new CommandExecutionResult(false, DEFAULT_FAIL_MESSAGE, ex);
        }
    }
}