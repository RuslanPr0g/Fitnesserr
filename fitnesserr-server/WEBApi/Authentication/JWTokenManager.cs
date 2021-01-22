using Core.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WEBApi.Repository;

namespace WEBApi.Authentication
{
    public class JWTokenManager : IJWTokenManager
    {
        private readonly string key;
        private readonly IUserRepo _repo;

        public JWTokenManager(string key, IUserRepo repo)
        {
            this.key = key;
            this._repo = repo;
        }

        public async Task<string> Authorize(string email, string password, CancellationToken cancellation = default)
        {
            User user = await _repo.FindUserByEmailAsync(email, cancellation);

            if((user is not null)&&(BCrypt.Net.BCrypt.Verify(password, user.Password)))
            {
                var TokenHandler = new JwtSecurityTokenHandler();
                var TokenKey = Encoding.ASCII.GetBytes(key);
                var TokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(TokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = TokenHandler.CreateToken(TokenDescriptor);
                return TokenHandler.WriteToken(token);
            }
            else
            {
                return null;
            }
        }
    }
}
