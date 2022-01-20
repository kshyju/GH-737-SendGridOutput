using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendGridHttpFunction
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Function1")]
        [SendGridOutput(ApiKey = "SgApikey")]
        public SendGridMessage Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
                    FunctionContext executionContext)
        {


            var message = new SendGridMessage();
            message.SetFrom(new EmailAddress("connectshyju@gmail.com", "SK"));
            message.SetGlobalSubject("Check SendGrid output");
            message.AddTo(new EmailAddress("shyju.mail@gmail.com", "My To Address"));
            message.AddCc(new EmailAddress("shyju@techiesweb.net", "My CC Address"));
            message.AddContent(MimeType.Text, "Mail to check SendGrid output from Azure Function with String return type");

            _logger.LogInformation($"Send message {message.Subject} to {message.Personalizations.First().Tos.First().Email}");

            return message;
        }
    }
}
