using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Notebook.App.Domain.Entities;
using Notebook.App.Domain.Interfaces;
using Notebook.App.Models;

namespace Notebook.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Users : ControllerBase
{
    private readonly IMapper _mapper;
    
    private readonly INotebookService _service;


    public Users(IMapper mapper, INotebookService service)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UserRequestModel requestModel)
    {
        var user = _mapper.Map<User>(requestModel);
        
        var newPhones = _mapper.Map<List<Phone>>(requestModel.PhoneInformations);

        await _service.UpdateAsync(user, newPhones);
        
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UserRequestModel requestModel)
    {
        var user = _mapper.Map<User>(requestModel);

        var phones = _mapper.Map<List<Phone>>(requestModel.PhoneInformations);

        await _service.AddAsync(user, phones);
        
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);

        return Ok();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await _service.GetByIdAsync(id);
        
        var response = _mapper.Map<UserResponseModel>(user);

        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _service.GetAllAsync();

        var response = _mapper.Map<List<UserResponseModel>>(users);
        
        return Ok(response);
    }
}