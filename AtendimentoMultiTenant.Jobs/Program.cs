using Quartz.Impl;
using Quartz;
using Quartz.Logging;

namespace AtendimentoMultiTenant.Jobs
{
    public class Program
    {
        private static void Main(string[] args)
        {
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

            //Execute();
        }

        //private static async void Execute()
        //{
        //    //services.AddQuartz(options =>
        //    //{
        //    //    options.UseMicrosoftDependencyInjectionJobFactory();
        //    //});
        //    //services.AddQuartzHostedService(options =>
        //    //{
        //    //    options.WaitForJobsToComplete = true;
        //    //});
        //    //services.ConfigureOptions<EmailBackgroundJobSetup>();

        //    //// Grab the Scheduler instance from the Factory
        //    //StdSchedulerFactory factory = new StdSchedulerFactory();
        //    //IScheduler scheduler = await factory.GetScheduler();

        //    //// and start it off
        //    //await scheduler.Start();

        //    //// define the job and tie it to our HelloJob class
        //    //IJobDetail job = JobBuilder.Create<HelloJob>()
        //    //                           .WithIdentity("job1", "group1")
        //    //                           .Build();

        //    //// Trigger the job to run now, and then repeat every 10 seconds
        //    //ITrigger trigger = TriggerBuilder.Create()
        //    //                                 .WithIdentity("trigger1", "group1")
        //    //                                 .StartNow()
        //    //                                 .WithSimpleSchedule(x => x
        //    //                                     .WithIntervalInSeconds(10)
        //    //                                     .RepeatForever())
        //    //                                 .Build();

        //    //// Tell Quartz to schedule the job using our trigger
        //    //await scheduler.ScheduleJob(job, trigger);

        //    //// some sleep to show what's happening
        //    //await Task.Delay(TimeSpan.FromSeconds(10));

        //    // and last shut down the scheduler when you are ready to close your program
        //    //await scheduler.Shutdown();

        //    //var job = new Quartz..JobDetail("dumbJob", null, typeof(Quartz.Job.NativeJob));
        //    //job.JobDataMap.Put(Quartz.Job.NativeJob.PropertyCommand, "echo \"hi\" >> foobar.txt");
        //    //var trigger = TriggerUtils.MakeSecondlyTrigger(5);
        //    //trigger.Name = "dumbTrigger";
        //    //await scheduler.ScheduleJob(job, trigger);

        //    Console.WriteLine("Press any key to close the application");
        //    Console.ReadKey();
        //}
    }
}
