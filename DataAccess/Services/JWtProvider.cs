using DataAccess.Context;
using EntitiesProject.Abstractions;
using EntitiesProject.Models;
using EntitiesProject.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    internal sealed class JwtProvider : IJwtProvider
    {
        private readonly ApplicationContext _context;
        private readonly JWTToken _jwt;
        public JwtProvider(ApplicationContext context, IOptions<JWTToken> jwt)
        {
            _context = context;
            _jwt = jwt.Value;
        }

        public async Task<string> CreateTokenAsync(AppUser user)
        {
            Claim[] claims = new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim("NameLastname", string.Join(" ",user.Name,user.LastName)),
            new Claim("Email", user.Email)
            };

            JwtSecurityToken securityToken = new(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(10),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey)), SecurityAlgorithms.HmacSha512));

            JwtSecurityTokenHandler handler = new();
            string token = handler.WriteToken(securityToken);

            return token;
        }
    }
}


