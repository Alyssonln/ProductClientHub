using Microsoft.AspNetCore.Mvc;
using ProductClientHub.API.UseCases.Clients.Register;
using ProductClientHub.Communication.Requests;
using ProductClientHub.Communication.Responses;
using ProductClientHub.Exception.ExceptionsBase;

namespace ProductClientHub.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(RequestClientJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestClientJson request)
    {
        try
        {
            var useCase = new RegisterClientsUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
        catch (ProductClientHubException ex)
        {
            var erros = ex.GetErrors();

            return BadRequest(new ResponseErrorMessagesJson(erros));
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson("ERRO DESCONHECIDO."));
        }
    }

    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok();
    }
}
