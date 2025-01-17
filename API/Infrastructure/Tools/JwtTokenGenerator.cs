﻿using API.Core.Application.Dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Infrastructure.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(CheckUserResponseDto dto)
        {
            var claims=new List<Claim>();

            if (!string.IsNullOrEmpty(dto.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, dto.Role));
            }

            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));

            if (!string.IsNullOrEmpty(dto.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, dto.Role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            SigningCredentials credentials=new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);

            var expireDate= DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer:JwtTokenDefaults.ValidIssuer,audience:JwtTokenDefaults.ValidAudience,claims:claims,notBefore:DateTime.Now,expires:expireDate,signingCredentials:credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenResponseDto(handler.WriteToken(jwtSecurityToken), expireDate);
        }
    }
}
