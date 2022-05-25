using Manager.API.ViewModel;

namespace Manager.API.Utilities
{
    public static class Responses
    {
        public static ResultViewModel ApplicationErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "An internal error occurred in the application, please try again.",
                Success = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string msg)
        {
            return new ResultViewModel
            {
                Message = msg,
                Success = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string msg, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel
            {
                Message = msg,
                Success = false,
                Data = errors
            };
        }

        public static ResultViewModel UnathorizedErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "Login unathorized, please try again",
                Success = false,
                Data = null
            };
        }
    }
}
