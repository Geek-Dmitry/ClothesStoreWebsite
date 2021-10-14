using AutoMapper;
using ClothesStoreWebsite.EfStuff.Repositories;
using ClothesStoreWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using СlothesStoreWebsite.EfStuff.Model;

namespace СlothesStoreWebsite.Controllers
{
    public class UserController : Controller
    {
        private UserRepository _userRepository;
        private ProductRepository _productRepository;
        private IMapper _mapper;

        public UserController(UserRepository userRepository, IMapper mapper, ProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            if (_userRepository
                .GetByEmail(loginViewModel.Email) == null)
            {
                ModelState.AddModelError(nameof(loginViewModel.Email),
                    "Please, check your email");

                return View(loginViewModel);
            }

            if (_userRepository.GetByEmail(loginViewModel.Email).Password != loginViewModel.Password)
            {
                ModelState.AddModelError(nameof(loginViewModel.Password),
                    "Please, check your password");

                return View(loginViewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Signup()
        {
            var signupViewModel = new SignupViewModel();
            return View(signupViewModel);
        }

        [HttpPost]
        public IActionResult Signup(SignupViewModel signupViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(signupViewModel);
            }

            if (_userRepository.GetByEmail(signupViewModel.Email) == null)
            {
                User user = _mapper.Map<User>(signupViewModel);
                _userRepository.Save(user);

                return RedirectToAction("Index", "Home");
            }

            return View(signupViewModel);
        }

        [HttpGet]
        public IActionResult UserAccount(long id)
        {
            User dbModel = _userRepository.Get(id);

            if (dbModel.DisplayName == null)
            {
                string email = dbModel.Email;
                string[] split = email.Split("@");
                dbModel.DisplayName = split[0];
            }

            if (dbModel.Image == null)
            {
                dbModel.Image = "/lib/image/icons/default-user.png";
            }

            UserAccountViewModel viewModel = _mapper.Map<UserAccountViewModel>(dbModel);

            return View(viewModel);
        }

        /*        [HttpPost]
                public IActionResult AccountSave(UserAccountViewModel userAccountViewModel) 
                {
                    if (!ModelState.IsValid) 
                    {
                        return RedirectToAction("MyAccount", "User", userAccountViewModel.Id);
                    }

                    User dbModel = _mapper.Map<User>(userAccountViewModel);
                    _userRepository.Save(dbModel);

                    return RedirectToAction("MyAccount", "User", userAccountViewModel.Id);
                }
        */

        public IActionResult UserWishListEmpty ()
        {
            return View();
        }

        public IActionResult UserWishList(long id) 
        {
            List<Product> WishList = _userRepository
                .Get(id)
                .WishProducts;

            if (WishList.Count == 0)
            {
                return RedirectToAction("UserWishListEmpty");
            }

            return View(WishList);
        }

        public JsonResult IsUserExist(string email) 
        {
            bool answer = _userRepository.GetByEmail(email) != null;
            return Json (answer);
        }
    }
}
