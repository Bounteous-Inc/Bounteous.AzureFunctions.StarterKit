using Advantive.Services.Services;
using Microsoft.Azure.WebJobs;

namespace Advantive.Functions;

public class ExportProjectFunction
{
    private readonly IHelloService helloService;
    
    public ExportProjectFunction(IHelloService helloService)
    {
        this.helloService = helloService;
    }

    [FunctionName("ExportProjectFunction")]
    public static void Run(
        [QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")]
        string projectId)
    {

    }
}