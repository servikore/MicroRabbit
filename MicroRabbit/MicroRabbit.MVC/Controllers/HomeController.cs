using MicroRabbit.MVC.Models;
using MicroRabbit.MVC.Models.DTO;
using MicroRabbit.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MicroRabbit.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransferService transferService;

        public HomeController(ILogger<HomeController> logger, ITransferService transferService)
        {
            _logger = logger;
            this.transferService = transferService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferViewModel transferViewModel)
        {
            var transferDto = new TransferDto
            {
                FromAccount = transferViewModel.FromAccount,
                ToAccount = transferViewModel.ToAccount,
                TransferAmount = transferViewModel.TransferAmount
            };
            await transferService.Transfer(transferDto);
            
            return View("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
