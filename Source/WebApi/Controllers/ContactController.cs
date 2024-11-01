using Microsoft.AspNetCore.Mvc;

using WebApi.Request;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v1/contact/")]
public class ContactController : ControllerBase
{
    private readonly ILogger<ContactController> _logger;

    public ContactController(ILogger<ContactController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get contacts assigned to a customer
    /// </summary>
    [HttpGet]
    [Produces("application/json")]
    public IActionResult GetContact()
    {
        return Ok();
    }

    /// <summary>
    /// Get contact assigned to a customer
    /// </summary>
    [HttpGet]
    [Route("{id}")]
    [Produces("application/json")]
    public IActionResult GetContactById([FromRoute] string id)
    {
        return Ok();
    }

    /// <summary>
    /// Create a contact
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created</response>
    /// <response code="400">Bad Request</response>
    /// <response code="403">Forbidden</response>
    /// <response code="403">Im a Teapot</response>
    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType<string>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType<ContactRequest>(StatusCodes.Status418ImATeapot)]
    [Produces("application/json")]
    public IActionResult PostContact(ContactRequest model)
    {
        // https://medium.com/@mohammed0hamdan/using-producesresponsetype-to-write-a-better-web-api-actions-in-net-core-18e080c9bf00

        return Ok("Ok");
    }

    /// <summary>
    /// Update contact
    /// </summary>
    [HttpPut]
    [Produces("application/json")]
    [Obsolete]
    public IActionResult PutContact(ContactRequest model)
    {
        return Ok();
    }

    /// <summary>
    /// Delete contact
    /// </summary>
    [HttpDelete]
    [Route("{id}")]
    [Produces("application/json")]
    public IActionResult DeleteContact([FromRoute] string id)
    {
        return Ok();
    }

}