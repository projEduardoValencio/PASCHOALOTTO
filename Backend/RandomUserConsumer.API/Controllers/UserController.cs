using Microsoft.AspNetCore.Mvc;
using RandomUserConsumer.Application.Interfaces;
using RandomuserConsumer.Communication.Responses.RandomUserApi;
using RandomuserConsumer.Communication.Responses.User;
using RandomUserConsumer.Domain.Entities;

namespace PASCHOALOTTO_Random_User_Consumer.Controllers;


[ApiController]
[Route("/user")]
public class UserController : ControllerBase
{
    [HttpGet("ping")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public IActionResult Hello()
    {
        return Ok("pong!");
    }

    [HttpGet("generate")]
    [ProducesResponseType(typeof(ResponseUserGenerated), StatusCodes.Status200OK)]
    public async Task<IActionResult> GenerateUser([FromServices] IUserUserCase userUseCase)
    {
        return Ok(await userUseCase.GenerateUser());
    }
    
    [HttpGet("list/{page}")]
    [ProducesResponseType(typeof(List<ResponseUserItemList>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(String), StatusCodes.Status404NotFound)]
    [ProducesErrorResponseType(typeof(String))]
    public async Task<IActionResult> ListUsers(
        [FromServices] IUserUserCase userUseCase,
        [FromRoute] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? search = null
        )
    {
        List<ResponseUserItemList> result = 
            await userUseCase.ListUsers(page <= 0 ? 1 : page, pageSize, null);
        
        return Ok(result);
    }
}