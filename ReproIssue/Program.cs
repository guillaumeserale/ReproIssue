using FastEndpoints;

namespace ReproIssue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

            builder.Services.AddFastEndpoints(options => options.SourceGeneratorDiscoveredTypes = DiscoveredTypes.All);

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseFastEndpoints(options => options.Errors.UseProblemDetails());

            app.Run();
        }
    }
}