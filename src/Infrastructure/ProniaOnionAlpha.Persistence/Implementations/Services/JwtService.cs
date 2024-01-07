using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProniaOnionAlpha.Application.DTOs.Authors;
using ProniaOnionAlpha.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionAlpha.Persistence.Implementations.Services
{
    public class JwtService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _db;
        private readonly IConfiguration _iconfiguration;
        public JwtService(IMapper mapper, AppDbContext db, IConfiguration iconfiguration)
        {
            _mapper = mapper;
            _db = db;
            _iconfiguration = iconfiguration;
        }

        private async Task<string[]> GetUserAsync(LoginDto dto)
        {
            var data = await _db.AccountRoles.Include(c => c.Author).Include(c => c.Role).Where(a => a.Author.Name == dto.Name && a.Author.Password == dto.Password).ToListAsync();
            string[] users = new string[data.Count + 1];
            int i = 0;
            foreach (var item in data)
            {
                if (i == 0)
                {
                    users[i] = item.Author.Name;
                    i++;
                    users[i] = item.Role.Name;
                    i++;
                    continue;
                }
                if (i <= data.Count)
                {
                    users[i] = item.Role.Name;
                }
                else
                {
                    break;
                }
                i++;
            }
            return users;
        }



        public async Task<string> LogIn(LoginDto dto)
        {
            var user = await GetUserAsync(dto);
            if (user != null)
            {
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_iconfiguration["JWT:Key"]);
                List<Claim> data = new List<Claim>();
                for (int i = 0; i < user.Length; i++)
                {
                    if (i == 0)
                    {
                        data.Add(new Claim(ClaimTypes.Name, user[i]));
                    }
                    else
                    {
                        data.Add(new Claim(ClaimTypes.Role, user[i]));
                    }
                }

                Claim[] b_data = new Claim[data.Count];
                int j = 0;
                foreach (var item in data)
                {
                    b_data[j] = item;
                    j++;
                }

                var tokenDecriptor = new SecurityTokenDescriptor
                {

                    Subject = new ClaimsIdentity(b_data),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

                };

                var token = tokenhandler.CreateToken(tokenDecriptor);
                return tokenhandler.WriteToken(token);
            }
            else return "User not registered.";
        }

    }


}
