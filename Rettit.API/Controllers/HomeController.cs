﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reddit.Logic.ILogic;
using Rettit.Models;

namespace Rettit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IPostLogic _postLogic;

        public HomeController(IPostLogic postLogic) 
        {
            _postLogic = postLogic;
        }

        // GET: api/Posts
        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPosts()
        {
            string authHeaderValue = Request.Headers["Authorization"];
            var tokenClaims = GetClaims(authHeaderValue.Substring("Bearer ".Length).Trim());
            var userId = Convert.ToInt32(tokenClaims.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            return _postLogic.GetSubscribedPosts(userId).ToList();
        }

        private ClaimsPrincipal GetClaims(string token)
        {
            var signingKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes("A-VERY-STRONG-KEY-HERE"));
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = false,
                ValidateAudience = false
            };

            return handler.ValidateToken(token, validations, out var tokenSecure);
        }
    }
}
