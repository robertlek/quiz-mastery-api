using Microsoft.AspNetCore.Mvc;
using QuizMastery.Business.Directors;
using QuizMastery.Business.Models;
using QuizMastery.Business.Models.QuizType;
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

    [HttpPost]
    [Route("AddQuizType")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response>> AddQuizType([FromBody] AddQuizTypeModel model)
    {
        try
        {
            if (model == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            QuizType quizType = await _quizTypeService.AddAsync(QuizTypeDirector.BuildFromAdd(model));

            _response.Result = quizType;
            _response.StatusCode = HttpStatusCode.Created;

            return Ok(_response);
        }
        catch (Exception exception)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages.Add(exception.Message);
        }

        return _response;
    }

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

    [HttpGet]
    [Route("GetQuizType/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response>> GetQuizType(Guid id)
    {
        try
        {
            QuizType? quizType = await _quizTypeService.GetAsync(x => x.Id == id);

            if (quizType == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return NotFound(_response);
            }

            _response.Result = quizType;
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

    [HttpDelete]
    [Route("RemoveQuizType/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response>> RemoveQuizType(Guid id)
    {
        try
        {
            QuizType? quizType = await _quizTypeService.GetAsync(x => x.Id == id);

            if (quizType == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return NotFound(_response);
            }

            await _quizTypeService.RemoveAsync(quizType);

            _response.StatusCode = HttpStatusCode.NoContent;

            return Ok(_response);
        }
        catch (Exception exception)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages.Add(exception.Message);
        }

        return _response;
    }

    [HttpPut]
    [Route("UpdateQuizType/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response>> UpdateQuizType(Guid id, [FromBody] QuizTypeModel model)
    {
        try
        {
            if (model == null || id != model.Id)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            QuizType? quizType = await _quizTypeService.GetAsync(x => x.Id == id, tracked: false);

            if (quizType == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return NotFound(_response);
            }

            quizType = await _quizTypeService.UpdateAsync(QuizTypeDirector.BuildFromUpdate(model));

            _response.Result = quizType;
            _response.StatusCode = HttpStatusCode.NoContent;

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
