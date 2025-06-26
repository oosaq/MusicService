using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicService.Application.Interfaces;
using MusicService.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicService.JwtProvider
{
    public class JwtProvider(
        IConfiguration configuration) : IJwtProvider
    {
        public string GenerateAccessToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]!)), SecurityAlgorithms.HmacSha256);

            Claim[] claims = [
                new("UserEmail", user.Email),
                new("UserId", user.Id.ToString()),
                ];

            var token = new JwtSecurityToken(
               signingCredentials: signingCredentials,
               expires: DateTime.Now.AddDays(int.Parse(configuration["JwtSettings:AccessExpireDays"]!)),
               claims: claims
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
