using Microsoft.AspNetCore.Mvc;
using QuizMastery.Business.Directors;
using QuizMastery.Business.Models;
using QuizMastery.Business.Models.Question;
using QuizMastery.Business.Services.QuestionService;
using QuizMastery.Business.Services.QuizService;
using QuizMastery.DataAccess.Entities;
using System.Net;

namespace quiz_mastery_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController(IQuestionService questionService,
    IQuizService quizService) : ControllerBase
{
    private readonly IQuestionService _questionService = questionService;
    private readonly IQuizService _quizService = quizService;
    private readonly Response _response = new();

    [HttpPost]
    [Route("AddQuestion")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response>> AddQuestion([FromBody] AddQuestionModel model)
    {
        try
        {
            if (model == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            Quiz? quiz = await _quizService.GetAsync(x => x.Id == model.QuizId);

            if (quiz == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            Question question = await _questionService.AddAsync(QuestionDirector.BuildFromAdd(model));

            _response.Result = question;
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
    [Route("GetAllQuestions")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Response>> GetAllQuestions()
    {
        try
        {
            IEnumerable<Question> questions = await _questionService.GetAllAsync();

            _response.Result = questions;
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
    [Route("GetAllQuestionsFromQuiz/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Response>> GetAllQuestionsFromQuiz(Guid id)
    {
        try
        {
            Quiz? quiz = await _quizService.GetAsync(x => x.Id == id);

            if (quiz == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            var questions = await _questionService.GetAllAsync(x => x.QuizId == quiz.Id);

            _response.Result = questions;
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
    [Route("GetQuestion/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response>> GetQuestion(Guid id)
    {
        try
        {
            Question? question = await _questionService.GetAsync(x => x.Id == id);

            if (question == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return NotFound(_response);
            }

            _response.Result = question;
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
    [Route("RemoveQuestion/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response>> RemoveQuestion(Guid id)
    {
        try
        {
            Question? question = await _questionService.GetAsync(x => x.Id == id);

            if (question == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return NotFound(_response);
            }

            await _questionService.RemoveAsync(question);

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
    [Route("UpdateQuestion/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Response>> UpdateQuestion(Guid id, [FromBody] QuestionModel model)
    {
        try
        {
            if (model == null || id != model.Id)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            Question? question = await _questionService.GetAsync(x => x.Id == id, tracked: false);

            if (question == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;

                return NotFound(_response);
            }

            Quiz? quiz = await _quizService.GetAsync(x => x.Id == model.QuizId);

            if (quiz == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;

                return BadRequest(_response);
            }

            question = await _questionService.UpdateAsync(QuestionDirector.BuildFromUpdate(model));

            _response.Result = question;
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
