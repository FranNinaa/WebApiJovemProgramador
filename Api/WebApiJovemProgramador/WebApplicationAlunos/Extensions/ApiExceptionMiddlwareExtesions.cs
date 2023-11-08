using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using WebApplicationAlunos.Models;

namespace WebApplicationAlunos.Extensions
{
    public static class ApiExceptionMiddlwareExtesions
    {
        //metodo estatico aonde define o tratamento de erro
        //recebe a instancia IApplicationBuilder chamada app
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            //aqui define o codigo que faz o tratamento de erro
            app.UseExceptionHandler(appError => 
            {
                appError.Run(async context =>
                {
                    //ta obtendo um status code
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    //definindo o tipo de retorno = json
                    context.Response.ContentType = "application/json";

                    //aqui obtén informações e detalhes do erro
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        //quando escrever a resposta retorna 
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            //o codigo do status 
                            StatusCode = context.Response.StatusCode,
                            //a mensagem do erro
                            Message = contextFeature.Error.Message,
                            //e a pilha de erros
                            Trace = contextFeature.Error.StackTrace
                        }.ToString());
                    }
                });
            
            });
        }
    }
}
