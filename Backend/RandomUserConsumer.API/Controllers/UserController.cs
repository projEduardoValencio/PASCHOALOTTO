using Microsoft.AspNetCore.Mvc;
using RandomUserConsumer.Application.Interfaces;
using RandomuserConsumer.Communication.Responses.Generics;
using RandomuserConsumer.Communication.Responses.User;

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

    #region User List Request
    [HttpGet("list/{page}")]
    [ProducesResponseType(typeof(List<ResponseUserList>), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(String))]
    public async Task<IActionResult> ListUsers(
        [FromServices] IUserUserCase userUseCase,
        [FromRoute] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? search = null
        )
    {
        page = page <= 0? 1 : page;
        ResponseUserList result = new ResponseUserList(
            await userUseCase.ListUsers(page, pageSize, search),
            page,
            pageSize,
            await userUseCase.CountUsers(search),
            search?? string.Empty
        );
        
        return Ok(result);
    }
    #endregion
}