//using CMS.Command.Comments.v1;
//using CMS.Query.Comments;
//using CMS.RestApi.Common;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CMS.RestApi.Comments.v1;
//[Route("api/v1/[controller]")]
//[ApiController]
//public class CommentController: BaseController

//{
//    public CommentController(ICommandBus commandBus, IQueryBus queryBus) :
//       base(commandBus, queryBus)
//    { }

//    [HttpGet("{id}")]
//    public async Task<ActionResult<GetCommentDto>> Get(long id, CancellationToken token)
//    {
//        var result = await queryBus.DispatchAsync(new GetCommentQuery(id), token);
//        return Ok(result);
//    }
//    [HttpGet]
//    public async Task<ActionResult<IEnumerable<GetCommentDto>>> Get([FromQuery] GetCommentsQuery query, CancellationToken token)
//    {
//        var result = await queryBus.DispatchAsync(query, token);
//        return Ok(result);
//    }
//    [HttpPost]
//    public async Task<ActionResult> Post(RegisterCommentCommand command, CancellationToken token)
//    {
//        var result = await commandBus.DispatchAsync(command, token);
//        return Created("", result);
//    }
//    [HttpPut("{id}")]
//    public async Task<ActionResult> Put(long id, [FromBody] ModifyCommentCommand command, CancellationToken token)
//    {
//        command.Id = id;
//        var result = await commandBus.DispatchAsync(command, token);
//        return Ok(result);
//    }
//    [HttpDelete]
//    public async Task<ActionResult> Delete(RemoveCommentCommand command, CancellationToken token)
//    {
//        var result = await commandBus.DispatchAsync(command, token);
//        return Ok(result);
//    }
//}


