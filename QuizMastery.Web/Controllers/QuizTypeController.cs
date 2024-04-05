using Microsoft.AspNetCore.Mvc;
using QuizMastery.Business.Models;
using QuizMastery.Business.Services.QuizTypeService;
using QuizMastery.DataAccess.Entities;
using System.Net;

namespace quiz_mastery_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizTypeController(IQuizTypeService quizTypeService) : ControllerBase
{
    private readonly IQuizTypeService _quizTypeService = quizTypeService;
    private readonly Response _response = new();

    [HttpGet]
    [Route("GetAllQuizTypes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Response>> GetAllQuizTypes()
    {
        try
        {
            IEnumerable<QuizType> quizTypes = await _quizTypeService.GetAllAsync();

            _response.Result = quizTypes;
            _response.StatusCode = HttpStatusCode.OK;

            return Ok(_response);
        }
        catch (Exception exception)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages.Add(exception.Message);
        }

        return _response;
    }
}
