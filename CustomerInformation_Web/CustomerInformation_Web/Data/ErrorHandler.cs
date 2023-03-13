namespace CustomerInformation_Web.Data
{
    public static class ErrorHandler
    {
        /// <summary>
        /// Il metodo generico si occupa della gestione degli errori 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static ErrorDescription Errors(string message, string description)
        {
            ErrorDescription err = new ErrorDescription()
            {
                description = description,
                message = message,
            };
            return err;
        }
    }
}
