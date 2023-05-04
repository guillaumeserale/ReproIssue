using FastEndpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using ReproIssue;
using ReproIssue.Features;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace TestProject
{
    public class UnitTest
    {
        private ITestOutputHelper testOutputHelper { get; init; }

        public UnitTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async void Test1()
        {
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();

            var result = await client.GETAsync<SampleEndpoint, Request, Response>(new Request { Name = "John Doe" });

            testOutputHelper.WriteLine(await result.Response.Content.ReadAsStringAsync());

            Assert.True(result.Response.IsSuccessStatusCode);


        }
    }
}