﻿using System.Threading.Tasks;


namespace FreeRoamProject.Shared.TypeExtensions
{

    public static class TaskExtensions
    {
        public static async void InvokeAndForget(this Task task)
        {
            await task;
        }
    }
}