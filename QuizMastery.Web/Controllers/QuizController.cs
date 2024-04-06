using Microsoft.AspNetCore.Mvc;
using QuizMastery.Business.Directors;
using QuizMastery.Business.Models;
using QuizMastery.Business.Models.Quiz;
using QuizMastery.Business.Services.QuizService;
using QuizMastery.Business.Services.QuizTypeService;
using QuizMastery.DataAccess.Entities;
using System.Net;

namespace quiz_mastery_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizController(IQuizService quizService,
    IQuizTypeService quizTypeService) : ControllerBase
{
    private readonly IQuizService _quizService = quizService;
    private readonly IQuizTypeService _quizTypeService = quizTypeService;
    private readonly Response _response = new();

    [HttpPost]
    [Route("AddQuiz")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response>> AddQuiz([FromBody] AddQuizModel model)
    {
        try
        {
            if (model == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            QuizType? quizType = await _quizTypeService.GetAsync(x => x.Id == model.QuizTypeId);

            if (quizType == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            Quiz quiz = await _quizService.AddAsync(QuizDirector.BuildFromAdd(model));

            _response.Result = quiz;
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
    [Route("GetAllQuizzes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Response>> GetAllQuizzes()
    {
        try
        {
            IEnumerable<Quiz> quizzes = await _quizService.GetAllAsync();

            _response.Result = quizzes;
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
    [Route("GetQuiz/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response>> GetQuiz(Guid id)
    {
        try
        {
            Quiz? quiz = await _quizService.GetAsync(x => x.Id == id);

            if (quiz == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return NotFound(_response);
            }

            _response.Result = quiz;
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
    [Route("GetQuizComponentsTree/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response>> GetQuizComponentsTree(Guid id)
    {
        try
        {
            Quiz? quiz = await _quizService.GetAsync(x => x.Id == id);

            if (quiz == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return NotFound(_response);
            }

            _response.Result = await _quizService.GetQuizComponentsTree(quiz);
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
    [Route("RemoveQuiz/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response>> RemoveQuiz(Guid id)
    {
        try
        {
            Quiz? quiz = await _quizService.GetAsync(x => x.Id == id);

            if (quiz == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return NotFound(_response);
            }

            await _quizService.RemoveAsync(quiz);

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
    [Route("UpdateQuiz/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response>> UpdateQuiz(Guid id, [FromBody] QuizModel model)
    {
        try
        {
            if (model == null || id != model.Id)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            Quiz? quiz = await _quizService.GetAsync(x => x.Id == id, tracked: false);

            if (quiz == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return NotFound(_response);
            }

            QuizType? quizType = await _quizTypeService.GetAsync(x => x.Id == model.QuizTypeId);

            if (quizType == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            quiz = await _quizService.UpdateAsync(QuizDirector.BuildFromUpdate(model, quiz));

            _response.Result = quiz;
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
