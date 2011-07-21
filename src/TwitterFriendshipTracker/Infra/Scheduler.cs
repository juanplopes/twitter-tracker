using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskScheduler;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
namespace TwitterFriendshipTracker.Infra
{
    public class Scheduler
    {
        public const string FolderName = "Twitter Friendship Tracker";
        TaskScheduler.TaskScheduler scheduler = new TaskScheduler.TaskScheduler();
        ITaskFolder folder;
        public Scheduler()
        {
            scheduler.Connect(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            try
            {
                folder = scheduler.GetFolder(@"\").CreateFolder(FolderName, Type.Missing);
            }
            catch (COMException e)
            {
                if (e.ErrorCode == -2147024713)
                    folder = scheduler.GetFolder(@"\").GetFolder(FolderName);
                else throw;
            }
        }

        public bool IsScheduled
        {
            get
            {
                var task = folder.GetTasks(0).OfType<IRegisteredTask>().FirstOrDefault();
                return task != null && 
                    task.Definition.Actions.OfType<IExecAction>()
                    .Any(x => x.Path.Contains(MyLocation) && x.Arguments == "update");
            }
        }

        public string MyLocation
        {
            get { return Assembly.GetExecutingAssembly().Location; }
        }

        public void ScheduleThis()
        {
            var xml = string.Format(TaskXml.Daily, MyLocation, "update");

            foreach (IRegisteredTask task in folder.GetTasks(0))
                folder.DeleteTask(task.Name, 0);
            folder.RegisterTask("Daily", xml,
                (int)_TASK_CREATION.TASK_CREATE_OR_UPDATE, null, null,
                _TASK_LOGON_TYPE.TASK_LOGON_S4U, null);
        }
    }
}
