using FastEndpoints;
using FluentValidation;
using System.Text.Json.Serialization;

namespace ReproIssue.Features
{
    public class Request { public string? Name { get; set; } }
    public class Response { public string? Name { get; set; } }

    
    [JsonSerializable(typeof(Request))]
    [JsonSerializable(typeof(Response))]
    [JsonSerializable(typeof(ProblemDetails))]
    internal partial class SourceGenerationContext : JsonSerializerContext
    {
    }

    public class SampleEndpoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Get("/Test");            
            AllowAnonymous();
            SerializerContext(SourceGenerationContext.Default);
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            await SendOkAsync(new Response { Name = req.Name });
        }
    }


    public class RequestValidator : Validator<Request> 
    {
        public RequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
