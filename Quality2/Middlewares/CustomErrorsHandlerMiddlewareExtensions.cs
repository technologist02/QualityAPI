namespace Quality2.Middlewares
{
    public static class CustomErrorsHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomErrorsHandler(this
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomErrorsHandlerMiddleware>();
        }
    }
}
