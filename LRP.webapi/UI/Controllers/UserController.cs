using LRP.webapi.Domain.Entities;
using LRP.webapi.Domain.Interfaces;
using LRP.webapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LRP.webapi.UI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private static IRepository<User> _userRepository;

    public UserController(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("{id}")]
    public async Task<User> GetById(int id)
    {
        return await _userRepository.GetById(id);
    }

    [HttpGet]
    public async Task<IEnumerable<User>> GetByQuery([FromQuery]Dictionary<string, string> query)
    {
        return await _userRepository.GetByQuery(query);
    }

    [HttpPost]
    public async Task Post(User user)
    {
        await _userRepository.Add(user);
    }

    [HttpPatch]
    public async Task Patch()
    {
        await _userRepository.Patch();
    }

    [HttpPut]
    public async Task Put(User user)
    {
        await _userRepository.Update(user);
    }

    [HttpDelete]
    public async Task Delete(int id)
    {
        await _userRepository.Delete(id);
    }
}