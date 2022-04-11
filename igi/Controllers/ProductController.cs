using igi.Data;
using igi.Entities;
using igi.Extention;
using igi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace igi.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        private int _pageSize;
        private ILogger _logger;

        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger )
        {
            _pageSize = 3;
            _context = context;
            _logger = logger;
        }

       
        [Route("Product")]
        [Route("Product/Page_{pageNo}")]
        public IActionResult Index(int? group,int pageNo = 1)
        {
            var groupName = group.HasValue
                ? _context.Categories.Find(group.Value)?.Name
                : "all groups";
            _logger.LogInformation($"info: group={group}, page={pageNo}");
            var productFiltred = _context.Products.Where(p => !group.HasValue || p.CategoryId == group.Value);
            ViewData["Groups"] = _context.Categories;
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Product>.GetModel(productFiltred, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
    }
}
