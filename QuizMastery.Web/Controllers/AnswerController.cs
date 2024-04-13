using Microsoft.AspNetCore.Mvc;
using QuizMastery.Business.Directors;
using QuizMastery.Business.Models;
using QuizMastery.Business.Models.Answer;
using QuizMastery.Business.Services.AnswerService;
using QuizMastery.Business.Services.QuestionService;
using QuizMastery.DataAccess.Entities;
using System.Net;

namespace quiz_mastery_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnswerController(IAnswerService answerService,
    IQuestionService questionService) : ControllerBase
{
    private readonly IAnswerService _answerService = answerService;
    private readonly IQuestionService _questionService = questionService;
    private readonly Response _response = new();

    [HttpPost]
    [Route("AddAnswer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response>> AddAnswer([FromBody] AddAnswerModel model)
    {
        try
        {
            if (model == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            Question? question = await _questionService.GetAsync(x => x.Id == model.QuestionId);

            if (question == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            Answer answer = await _answerService.AddAsync(AnswerDirector.BuildFromAdd(model));

            _response.Result = answer;
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
    [Route("GetAllAnswers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Response>> GetAllAnswers()
    {
        try
        {
            IEnumerable<Answer> answers = await _answerService.GetAllAsync();

            _response.Result = answers;
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
    [Route("GetAllAnswersFromQuestion/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response>> GetAllAnswersFromQuestion(Guid id)
    {
        try
        {
            Question? question = await _questionService.GetAsync(x => x.Id == id);

            if (question == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            var answers = await _answerService.GetAllAsync(x => x.QuestionId == question.Id);

            _response.Result = answers;
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
    [Route("GetAnswer/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response>> GetAnswer(Guid id)
    {
        try
        {
            Answer? answer = await _answerService.GetAsync(x => x.Id == id);

            if (answer == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return NotFound(_response);
            }

            _response.Result = answer;
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
    [Route("RemoveAnswer/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response>> RemoveAnswer(Guid id)
    {
        try
        {
            Answer? answer = await _answerService.GetAsync(x => x.Id == id);

            if (answer == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return NotFound(_response);
            }

            await _answerService.RemoveAsync(answer);

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
    [Route("UpdateAnswer/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response>> UpdateAnswer(Guid id, [FromBody] AnswerModel model)
    {
        try
        {
            if (model == null || id != model.Id)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            Answer? answer = await _answerService.GetAsync(x => x.Id == id, tracked: false);

            if (answer == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return NotFound(_response);
            }

            Question? question = await _questionService.GetAsync(x => x.Id == model.QuestionId);

            if (question == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            answer = await _answerService.UpdateAsync(AnswerDirector.BuildFromUpdate(model));

            _response.Result = answer;
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
