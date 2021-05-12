using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Extensions;
using TelegramBot.Models;
using TelegramBot.Services;

static class Program
{
    static TelegramBotClient Bot;
    static string BOT_TOKEN = "1781380295:AAFtICjdAUNRcy07CEFMrcFCJ9DQHkWivMQ";
    static List<Quiz> Quizzes = new List<Quiz>();

    static async Task Main()
    {
        var cts = new CancellationTokenSource();

        try
        {
            Bot = new TelegramBotClient(BOT_TOKEN);

            var me = await Bot.GetMeAsync();
            Console.WriteLine($"Start listening for @{me.Username}");

            await Bot.ReceiveAsync(new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync), cts.Token);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            cts.Cancel();
        }
    }

    private static async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken cancellationToken)
    { 
        if (update.Type != UpdateType.Message)
            return;

        try
        {
            await BotOnMessageReceived(update.Message);
        }
        catch (Exception exception)
        {
            await HandleErrorAsync(client, exception, cancellationToken);
        }
    }

    static async Task BotOnMessageReceived(Message message)
    {
        Console.WriteLine($"Receive message type: {message.Type}");

        if (message.Type != MessageType.Text)
            return;

        if (message.Text.Equals("/quiz"))
        {
            StartNewQuiz(message);
        }
        else if (message.Text.IsDigit())
        {
            GetNextQuestion(message);
        }
        else
        {
            await Bot.SendTextMessageAsync(message.Chat.Id, $"Received {message.Text}");
        }
    }

    private static async void GetNextQuestion(Message msg)
    {
        var quiz = Quizzes.Where(x => x.ChatId.Equals(msg.Chat.Id)).First();

        var previousQuestion = quiz.AnsweredQuizModel.AnsweredQuestionModels[quiz.CurrentQuestion - 1];

        if (previousQuestion.QuestionModel.AnswerModels.Where(x => x.Number.Equals(msg.Text)).First().IsCorrect)
        {
            quiz.Score++;
        }

        if (quiz.CurrentQuestion == quiz.AnsweredQuizModel.AnsweredQuestionModels.Count)
        {
            GetResults(msg, quiz);

            return;
        }

        var question = quiz.AnsweredQuizModel.AnsweredQuestionModels[quiz.CurrentQuestion];

        StringBuilder sb = new StringBuilder();

        sb.Append($"Вопрос: {question.QuestionModel.Question}" + Environment.NewLine);

        for (int i = 0; i < question.QuestionModel.AnswerModels.Count; i++)
        {
            sb.Append($"{i + 1}. {question.QuestionModel.AnswerModels[i].AnswerText}" + Environment.NewLine);
            question.QuestionModel.AnswerModels[i].Number = (i + 1).ToString();
        }

        quiz.CurrentQuestion++;

        await Bot.SendTextMessageAsync(msg.Chat.Id, sb.ToString());
    }

    private static void GetResults(Message msg, Quiz quiz)
    {
        Bot.SendTextMessageAsync(msg.Chat.Id, $"Ваш итоговый счет: {quiz.Score}");
        Quizzes.Remove(quiz);
    }

    private static async void StartNewQuiz(Message msg)
    {
        if (Quizzes.Any(x => x.ChatId == msg.Chat.Id))
        {
            await Bot.SendTextMessageAsync(msg.Chat.Id, "Вы уже начали викторину!");
            return;
        }

        var quiz = await new QuizService().GetRandomQuizAsync();

        Quiz newQuiz = new Quiz()
        {
            AnsweredQuizModel = quiz,
            ChatId = msg.Chat.Id,
            CurrentQuestion = 0
        };

        Quizzes.Add(newQuiz);

        string message = $"Название викторины: {quiz.QuizModel.Name}" + Environment.NewLine
            + $"Тема викторины: {quiz.QuizModel.Topic}";

        await Bot.SendTextMessageAsync(msg.Chat.Id, message);

        var question = newQuiz.AnsweredQuizModel.AnsweredQuestionModels[newQuiz.CurrentQuestion];

        StringBuilder sb = new StringBuilder();

        sb.Append($"Вопрос: {question.QuestionModel.Question}" + Environment.NewLine);

        for (int i = 0; i < question.QuestionModel.AnswerModels.Count; i++)
        {
            sb.Append($"{i+1}. {question.QuestionModel.AnswerModels[i].AnswerText}" + Environment.NewLine);
            question.QuestionModel.AnswerModels[i].Number = (i + 1).ToString();
        }

        newQuiz.CurrentQuestion++;

        await Bot.SendTextMessageAsync(msg.Chat.Id, sb.ToString());
    }

    static Task HandleErrorAsync(ITelegramBotClient cleint, Exception exception, CancellationToken cancellationToken)
    {
        var ErrorMessage = exception switch
        {
            ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(ErrorMessage);

        return Task.CompletedTask;
    }
}