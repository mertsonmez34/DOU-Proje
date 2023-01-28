using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Entity;
using E_Commerce.Identity;
using E_Commerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.DataProtection;
//using Microsoft.AspNet.Identity.Owin;

namespace E_Commerce.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            _userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            _roleManager = new RoleManager<ApplicationRole>(roleStore);

        }

        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders
                .Where(i => i.Username == username)
                .Select(i => new UserOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    Total = i.Total
                }).OrderByDescending(i => i.OrderDate).ToList();

            return View(orders);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AddressName = i.AddressName,
                    Address = i.Address,
                    City = i.City,
                    District = i.District,
                    Neighborhood = i.Neighborhood,
                    PostalCode = i.PostalCode,
                    Orderlines = i.Orderlines.Select(a => new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name.Length > 50 ? a.Product.Name.Substring(0, 47) + "..." : a.Product.Name,
                        Image = a.Product.Image,
                        Quantity = a.Quantity,
                        Price = a.Price,
                        ChosenOption = a.ChosenOption
                    }).ToList()
                }).FirstOrDefault();

            return View(entity);
        }



        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt işlemleri

                var user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.Height = model.Height;
                user.Weight = model.Weight;
                user.Sex = model.Sex;

                var result = _userManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    //kullanıcı oluştu ve kullanıcıyı bir role atayabilirsiniz.
                    if (_roleManager.RoleExists("user"))
                    {
                        _userManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");

                }
                if (user.UserName.Contains(model.UserName))
                {
                    ModelState.AddModelError("", "The Username is already exist.");
                }
                if (user.Email.Contains(model.Email))
                {
                    ModelState.AddModelError("", "The E-Mail address is already exist.");
                }
                else
                {
                    ModelState.AddModelError("", "User creation error.");
                }

            }

            return View(model);
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser u = null;
                if (model.UserName.Contains('@'))
                {
                    u = _userManager.FindByEmail(model.UserName);
                    model.UserName = u.UserName;
                }

                //Login işlemleri
                var user = _userManager.Find(model.UserName, model.Password);

                if (user != null)
                {
                    // varolan kullanıcıyı sisteme dahil et.
                    // ApplicationCookie oluşturup sisteme bırak.

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = _userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Please control the username and password.");
                }
            }

            return View(model);
        }

        // GET: UserInfo
        [Authorize]
        public ActionResult UserInfo()
        {
            var currentUser = _userManager.FindById(User.Identity.GetUserId());
            return View(currentUser);
        }

        // SET: UserInfo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UserInfo(ApplicationUser user)
        {
            var currentUser = await _userManager.FindByIdAsync(User.Identity.GetUserId());

            if (ModelState.IsValid && currentUser != null)
            {
                if (!string.IsNullOrEmpty(user.Name))
                    currentUser.Name = user.Name;
                else
                    ModelState.AddModelError("", "Name cannot be empty");

                if (!string.IsNullOrEmpty(user.Surname))
                    currentUser.Surname = user.Surname;
                else
                    ModelState.AddModelError("", "Surname cannot be empty");

                if (!string.IsNullOrEmpty(user.UserName))
                    currentUser.UserName = user.UserName;
                else
                    ModelState.AddModelError("", "UserName cannot be empty");

                if (!string.IsNullOrEmpty(user.Email))
                    currentUser.Email = user.Email;
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                currentUser.Height = user.Height;
                currentUser.Weight = user.Weight;
                currentUser.Sex = user.Sex;

                if (!string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Surname) && !string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Email))
                {

                    IdentityResult result = await _userManager.UpdateAsync(currentUser);
                    return RedirectToAction("Index", "Account");
                }
            }
            return View(user);
        }


        // GET: UserInfo
        [Authorize]
        public ActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> PasswordChange(string Password, string RePassword)
        {
            var currentUser = await _userManager.FindByIdAsync(User.Identity.GetUserId());
            if (ModelState.IsValid && currentUser != null)
            {

                if (!string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(RePassword))
                    if (Password == RePassword)
                    {

                        await _userManager.RemovePasswordAsync(currentUser.Id);

                        var result = await _userManager.AddPasswordAsync(currentUser.Id, Password);


                        if (result.Succeeded)
                        {
                            var authManager = HttpContext.GetOwinContext().Authentication;
                            authManager.SignOut();

                            return RedirectToAction("Login", "Account");
                        }
                        else
                        {

                            ModelState.AddModelError("", "Password Could not Change ");
                        }

                    }
                    else
                        ModelState.AddModelError("", "Passwords Does not Matched!");
                else
                    ModelState.AddModelError("", "Passwords cannot be empty");
            }
            return View();
        }


        [Authorize]
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }



        [Authorize]
        public string GetMySizeResult(ApplicationUser user)
        {

            if (user != null && user.Height != null && user.Weight != null)
            {
                string size;
                float height = (float)user.Height;
                float weight = (float)user.Weight;

                float divided = height / 100;

                var bmi = weight / (divided * divided);

                if (bmi < 18.5)
                {
                    size = "S";
                }
                else if (bmi < 25)
                {
                    size = "M";
                }
                else if (bmi < 30)
                {
                    size = "L";
                }
                else if (bmi < 35)
                {
                    size = "XL";
                }
                else if (bmi <= 40)
                {
                    size = "XXL";
                }
                else
                {
                    size = null;
                }
                return size;
            }
            return null;
        }

        [Authorize]
        public bool isAlreadyReviewed(int productID)
        {
            var currentUser = _userManager.FindById(User.Identity.GetUserId());

            var product = db.Products.Find(productID);

            if (product == null)
            {
                return false;
            }

            if (product.Reviews.FirstOrDefault(i => i.SenderName == currentUser.UserName) == null)
            {
                return false;
            }
            else
                return true;


        }

    }
}