using CMS.Command.Users.v1;
using CMS.Query.Users.v1;
using CMS.RestApi.Common;
using Microsoft.AspNetCore.Mvc;

namespace CMS.RestApi.Users.v1;
[Route("api/v1/[controller]")]
[ApiController]
public class UserController:BaseController
{
    public UserController(ICommandBus commandBus, IQueryBus queryBus) :
        base(commandBus, queryBus)
    { }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetUserDto>> Get(long id, CancellationToken token)
    {
        var result = await queryBus.DispatchAsync(new GetUserQuery(id), token);
        return Ok(result);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetUserDto>>> Get([FromQuery] GetUsersQuery query, CancellationToken token)
    {
        var result = await queryBus.DispatchAsync(query, token);
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult> Post(RegisterUserCommand command, CancellationToken token)
    {
        var result = await commandBus.DispatchAsync(command, token);
        return Created("", result);
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(long id, [FromBody] ModifyUserCommand command, CancellationToken token)
    {
        command.Id = id;
        var result = await commandBus.DispatchAsync(command, token);
        return Ok(result);
    }
    [HttpDelete]
    public async Task<ActionResult> Delete(RemoveUserCommand command, CancellationToken token)
    {
        var result = await commandBus.DispatchAsync(command, token);
        return Ok(result);
    }
    
    
}
