using Advantive.Common.Models;
using Advantive.Services.Services;
using Bounteous.Core;
using Microsoft.Azure.WebJobs;

namespace Advantive.Functions;

public class ExportProjectFunction
{
    private readonly IExportService exportService;

    public ExportProjectFunction() : this (IoC.Resolve<IExportService>())
    {
        
    }
    
    public ExportProjectFunction(IExportService exportService)
    {
        this.exportService = exportService;
    }

    [FunctionName("ExportProjectFunction")]
    public async Task Run(
        [QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")]
        string projectId)
    {
        await exportService.ExportProjectAsync(new ExportProjectRequest());
    }
}