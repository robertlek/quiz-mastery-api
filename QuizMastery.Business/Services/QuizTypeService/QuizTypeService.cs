﻿using QuizMastery.DataAccess.Context;
using QuizMastery.DataAccess.Entities;
using QuizMastery.DataAccess.Repository;

namespace QuizMastery.Business.Services.QuizTypeService;

public class QuizTypeService(BaseContext db) : BaseRepositoy<QuizType>(db), IQuizTypeService
{
    private readonly BaseContext _db = db;
}
