using AccountingPro.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AccountingPro.Web.Services;

/// <summary>
/// Service for rendering invoice templates based on company preferences
/// </summary>
public interface IInvoiceTemplateService
{
    /// <summary>
    /// Renders an invoice to HTML using a specific template
    /// </summary>
    Task<string> RenderInvoiceHtmlAsync(InvoicePrintDto invoice, string templateName);
    
    /// <summary>
    /// Gets all available template names
    /// </summary>
    List<string> GetAvailableTemplates();
}

public class InvoiceTemplateService : IInvoiceTemplateService
{
    private readonly IRazorViewEngine _razorViewEngine;
    private readonly ITempDataProvider _tempDataProvider;
    private readonly IServiceProvider _serviceProvider;

    public InvoiceTemplateService(
        IRazorViewEngine razorViewEngine,
        ITempDataProvider tempDataProvider,
        IServiceProvider serviceProvider)
    {
        _razorViewEngine = razorViewEngine;
        _tempDataProvider = tempDataProvider;
        _serviceProvider = serviceProvider;
    }

    public async Task<string> RenderInvoiceHtmlAsync(InvoicePrintDto invoice, string templateName)
    {
        var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };
        var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

        using var sw = new StringWriter();
        
        var viewPath = $"~/Templates/Invoices/{templateName}.cshtml";
        var viewResult = _razorViewEngine.GetView(null, viewPath, false);

        if (!viewResult.Success)
        {
            throw new InvalidOperationException(
                $"Template '{templateName}' not found. Searched locations: " +
                $"{string.Join(", ", viewResult.SearchedLocations ?? Array.Empty<string>())}");
        }

        var viewDictionary = new ViewDataDictionary(
            new EmptyModelMetadataProvider(),
            new ModelStateDictionary())
        {
            Model = invoice
        };

        var viewContext = new ViewContext(
            actionContext,
            viewResult.View,
            viewDictionary,
            new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
            sw,
            new HtmlHelperOptions()
        );

        await viewResult.View.RenderAsync(viewContext);
        return sw.ToString();
    }

    public List<string> GetAvailableTemplates()
    {
        return new List<string>
        {
            "ModernTemplate",
            "ClassicTemplate"
        };
    }
}
