﻿using DirectoryOfTeachers.Framework.Attributes;
using DirectoryOfTeachers.Framework.Parameters;
using DirectoryOfTeachers.Framework.Commands;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Commands
{
    [Command("/start", Description = "Комманда для початку взаємодії з ботом")]
    public class StartCommand : Command
    {
        public override async Task InvokeAsync(CommandParameters parameters)
        {
            await parameters.SendTextAnswerAsync($"Вітаю! Цей бот створений як довідник викладачів. За допомогою бота Ви зможете взнати трохи інформації наприклад про вчителя який буде вести пару цього семестру, взнати чи легко його здати, який в нього характер і т.д. Команда /help допоможе вам розібратися в боті!");
        }
    }
}
