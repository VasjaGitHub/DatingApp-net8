using System.Security.Claims;
using API.DTOs;
using API.Entities;
//using API.Extensions;
//using API.Helpers;
//using API.Interfaces;
//using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController(DataContext context) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users=await context.Users.ToListAsync();
        return users;
    }
    
    [Authorize]
    [HttpGet("{id:int}")] // /api/users/2
    public async Task<ActionResult<AppUser>> GetUsers(int id)
    {
        var user=await context.Users.FindAsync(id);
        if(user==null) return NotFound();
        return user;
    }
}
