using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces;

public interface IUserRepository
{
   Task<AppUser?> GetUserByIdAsync(int id);
   Task<AppUser?> GetUserByUsernameAsync(string username);
   Task<MemberDto?> GetUserAsync(string username);
   Task<IEnumerable<MemberDto>> GetUsersAsync();
   void Update(AppUser user);
   Task<bool> SaveAllAsync();
}
