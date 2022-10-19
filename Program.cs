﻿using System;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace FireBaseMicroServices
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 1. Create a scheduler Factory
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            // 2. Get and start a scheduler
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();
            // 3. Create a job
            IJobDetail job = JobBuilder.Create<NumberGeneratorJob>()
                .WithIdentity("number generator job", "number generator group")
                .Build();
            // 4. Create a trigger
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("number generator trigger", "number generator group")
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(3).RepeatForever())
                .Build();
            // 5. Schedule the job using the job and trigger 
            await scheduler.ScheduleJob(job, trigger);
            Console.ReadLine();
        }
    }
}