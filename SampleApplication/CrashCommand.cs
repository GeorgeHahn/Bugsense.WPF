﻿using System;
using System.Threading;

namespace SampleApplication
{
    public static class CrashHelper
    {
        public static void Crash()
        {
            throw new ArgumentException("Thrown intentionally");
        }
    }

    public class CrashCommand : AlwaysExecutableCommand
    {
        public override void Execute(object parameter)
        {
            CrashHelper.Crash();
        }
    }

    public class BackgroundCrashCommand : AlwaysExecutableCommand
    {
        public override void Execute(object parameter)
        {
            ThreadPool.QueueUserWorkItem(Crash);
        }

        private void Crash(object state)
        {
            CrashHelper.Crash();
        }
    }
}
