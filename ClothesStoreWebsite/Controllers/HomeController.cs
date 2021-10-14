using AutoMapper;
using ClothesStoreWebsite.EfStuff.Repositories;
using ClothesStoreWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using СlothesStoreWebsite.EfStuff.Model;

namespace СlothesStoreWebsite.Controllers
{
    public class HomeController : Controller
    {
        private ProductRepository _productRepository;
        public IMapper _mapper;

        public HomeController(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<ProductViewModel> viewModel = _productRepository
                .GetAll()
                .Select(dbModel => _mapper.Map<ProductViewModel>(dbModel)
                )
                .ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Product(long id)
        {
            Product dbModel = _productRepository
               .Get(id);
            ProductViewModel viewModel = _mapper.Map<ProductViewModel>(dbModel);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Popup(long id)
        {
            Product dbModel = _productRepository
                .Get(id);
            ProductViewModel viewModel = _mapper.Map<ProductViewModel>(dbModel);

            return View(viewModel);
        }
    }
}