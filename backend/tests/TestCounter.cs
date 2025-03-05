using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;

// Alias for the Counter and GetResumeCounter types to avoid conflicts
using CounterType = Company.Function.Counter;
using GetResumeCounterType = Company.Function.GetResumeCounter;

namespace tests
{
    public class TestCounter
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public void Http_trigger_should_return_known_string()
        {
            var counter = new CounterType();
            counter.Id = "1";
            counter.Count = 2;
            var request = TestFactory.CreateHttpRequest();
            var response = (HttpResponseMessage) GetResumeCounterType.Run(request, counter, out counter, logger);
            Assert.Equal(3, counter.Count);
        }
    }
}