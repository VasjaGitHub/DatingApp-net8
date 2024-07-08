using API.Data;
using System.Security.Claims;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository):BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users=await userRepository.GetUsersAsync();
        return Ok(users);
    }
    
    [HttpGet("{username}")] // /api/users/2
    public async Task<ActionResult<MemberDto>> GetUsers(string username)
    {
        var user=await userRepository.GetMemberAsync(username);
        if(user==null) return NotFound();
        return user;
    }
}
