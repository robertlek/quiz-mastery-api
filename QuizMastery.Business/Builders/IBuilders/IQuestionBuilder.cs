﻿using QuizMastery.DataAccess.Entities;

namespace QuizMastery.Business.Builders.IBuilders;

public interface IQuestionBuilder
{
    IQuestionBuilder WithQuizId(Guid id);
    IQuestionBuilder WithMessage(string message);
    IQuestionBuilder WithScore(int score);
    Question Build();
}
