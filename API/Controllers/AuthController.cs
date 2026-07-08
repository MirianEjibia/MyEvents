using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UseCases.Auth.DTOs;

namespace API.Controllers
{
    public class AuthController(SignInManager<User> signInManager): BaseApiController
    {
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var user = new User
            {
                UserName = registerUserDto.UserName,
                Email = registerUserDto.Email,                
            };

            var res = await signInManager.UserManager.CreateAsync(user, registerUserDto.Password);
            if(res.Succeeded) return Ok();
            foreach(var err in res.Errors)
            {
                ModelState.AddModelError(err.Code, err.Description);
            }
            return ValidationProblem();
        }

        [AllowAnonymous]
        [HttpGet("/api/me")]
        public async Task<IActionResult> GetUserInfo()
        {
           if(User.Identity?.IsAuthenticated == false) return NoContent();
           var user = await signInManager.UserManager.GetUserAsync(User);
           if(user == null) return Unauthorized();
           return Ok(new
           {
               user.DispalyName,
               user.UserName,
               user.Email,
               user.ImageUrl
           });
        }

        [HttpPost("/api/logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
               await signInManager.SignOutAsync();
            } 
            catch(Exception err)
            {
                Console.WriteLine(err);
            }
            return NoContent();
        }


    }
}