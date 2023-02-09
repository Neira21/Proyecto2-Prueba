using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieAppV2.Data;
using MovieAppV2.Models;

namespace MovieAppV2.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly MovieContext _context;
        private UserManager<IdentityUser> _um;
        private SignInManager<IdentityUser> _sim;
        public UsuarioController(MovieContext context, UserManager<IdentityUser> um, SignInManager<IdentityUser> sim)
        {
            _context = context;
            _um = um;
            _sim = sim;
        }
        public IActionResult Index()
        {
            var listPelicula=_context.Peliculas.OrderBy(s=>s.ID) .ToList();
            return View(listPelicula);
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(string username, string pwd, Usuario infouser)
        {
            infouser.Username = username;
            infouser.Pwd = pwd;
            if(ModelState.IsValid){
                var IdentityUser = new IdentityUser(username);
                var result =_um.CreateAsync(IdentityUser,pwd).Result;
                if(result.Succeeded)
                {
                    _context.Add(infouser);
                    _context.SaveChanges();
                    return RedirectToAction("login");
                }else{
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("usuario", error.Description);
                    }
                    var result2 =_um.DeleteAsync(IdentityUser).Result;
                    return View();
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string pwd)
        {
            var result = _sim.PasswordSignInAsync(username,pwd,false,false).Result;
            if(result.Succeeded)
            {
                return RedirectToAction("index","home");
            }
            ModelState.AddModelError("usuario","Datos incorrectos");
            return View();
        }
        public async Task<IActionResult> logout()
        {
            await _sim.SignOutAsync();
            return RedirectToAction("index","home");
        }
    }
}