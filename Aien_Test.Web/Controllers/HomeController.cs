using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Aien_Test.Web.Models;
using Aien_Test.Application.Services.Interfaces;
using Aien_Test.Common.DTOs.Contract;

namespace Aien_Test.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IContractService _contractService;
    public HomeController(ILogger<HomeController> logger, IContractService contractService)
    {
        _logger = logger;
        _contractService = contractService;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        List<ContractList> contracts = await _contractService.GetContractList(cancellationToken);
        return View(contracts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

