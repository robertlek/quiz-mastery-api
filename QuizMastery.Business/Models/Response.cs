using System.Net;

namespace QuizMastery.Business.Models;

public class Response
{
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccess { get; set; } = true;
    public List<string> ErrorMessages { get; set; } = [];
    public object Result { get; set; } = new object();
}
