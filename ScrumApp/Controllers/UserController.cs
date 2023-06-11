using System;
using Microsoft.AspNetCore.Mvc;
using ScrumApp.Services;
using ScrumApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace ScrumApp.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly MongoDBService _mongoDBService;



        public UserController(MongoDBService mongoDBService) 
        {
            _mongoDBService = mongoDBService;

        }

        [HttpGet]
        public async Task<List<User>> Get() {
            await _mongoDBService.GetAsync<User>("Users");
            return _mongoDBService.GetAsync<User>("Users").Result;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<List<User>>> Get(string userName)
        {
            var users = await _mongoDBService.GetQueryAsync<User>("Users", userName);
            return users;
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] User user)
        {
            try
            {
                await _mongoDBService.CreateAsync("Users", user);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Failed to create user: {ex.Message}");
            }
        }




    }
}
