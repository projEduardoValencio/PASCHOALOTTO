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
    public IActionResult GenerateUser()
    {
        return Ok(new ResponseRandomUserGereted());
    }
    
    [HttpGet("list")]
    [ProducesResponseType(typeof(List<ResponseUserItemList>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListUsers([FromServices] IUserUserCase userUseCase)
    {
        List<ResponseUserItemList> result = await userUseCase.ListUsers(10, 1, null);
        return Ok(result);
    }
}