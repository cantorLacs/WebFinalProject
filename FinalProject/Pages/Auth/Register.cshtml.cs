using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;
using FinalProject.Pages.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace FinalProject.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly FinalProject.Data.FinalProjectContext _context;

        public RegisterModel(FinalProject.Data.FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, User.Email),
                    new Claim(ClaimTypes.Role, User.Role.ToString()),
                    new Claim(ClaimTypes.Name, User.FirstName)
                };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            return RedirectToPage("/Auth/Login");
        }
    }

}
