using QuizMastery.Business.Components;
using QuizMastery.Business.Services.AnswerService;
using QuizMastery.Business.Services.QuestionService;
using QuizMastery.DataAccess.Context;
using QuizMastery.DataAccess.Entities;
using QuizMastery.DataAccess.Repository;

namespace QuizMastery.Business.Services.QuizService;

public class QuizService(BaseContext db,
    IQuestionService questionService,
    IAnswerService answerService) : BaseRepositoy<Quiz>(db), IQuizService
{
    private readonly IQuestionService _questionService = questionService;
    private readonly IAnswerService _answerService = answerService;

    public async Task<object> GetQuizComponentsTree(Quiz quiz)
    {
        var tree = new Composite(quiz.Name, "Quiz");

        tree = await GetTreeWithQuestions(quiz, tree);

        return tree.ConvertIntoJson();
    }

    private async Task<Composite> GetTreeWithQuestions(Quiz quiz, Composite tree)
    {
        IEnumerable<Question> questions = await _questionService.GetAllAsync(x => x.QuizId == quiz.Id);

        foreach (var question in questions)
        {
            var questionTree = new Composite(question.Message, "Question");

            questionTree = await GetQuestionTreeWithAnswers(question, questionTree);

            tree.Add(questionTree);
        }

        return tree;
    }

    private async Task<Composite> GetQuestionTreeWithAnswers(Question question, Composite tree)
    {
        IEnumerable<Answer> answers = await _answerService.GetAllAsync(x => x.QuestionId == question.Id);

        foreach (var answer in answers)
        {
            var answerLeaf = new Leaf(answer.Message, "Answer");

            tree.Add(answerLeaf);
        }

        return tree;
    }
}
