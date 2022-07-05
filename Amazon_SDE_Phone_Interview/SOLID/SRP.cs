using Amazon_SDE_Phone_Interview.Interface;

namespace Amazon_SDE_Phone_Interview.SOLID
{
    internal partial class SRP : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Single responsibility principle");
            var report = new WorkReport();
            report.AddEntry(new WorkReportEntry { ProjectCode = "123Ds", ProjectName = "Project1", SpentHours = 5 });
            report.AddEntry(new WorkReportEntry { ProjectCode = "987Fc", ProjectName = "Project2", SpentHours = 3 });

            IEntryManager<ScheduleTask> scheduler = new Scheduler();
            scheduler.AddEntry(new ScheduleTask { TaskId = 1, Content = "Do something now.", ExecuteOn = DateTime.Now.AddDays(5) });
            scheduler.AddEntry(new ScheduleTask { TaskId = 2, Content = "Don't forget to...", ExecuteOn = DateTime.Now.AddDays(2) });

            Console.WriteLine(report.ToString());
            Console.WriteLine(scheduler.ToString());

            FileSaver<WorkReportEntry>.SaveToFile(@"Reports", "WorkReport.txt", report);
            FileSaver<ScheduleTask>.SaveToFile(@"Schedulers", "Schedule.txt", scheduler);
        }

        internal class WorkReportEntry
        {
            public string ProjectCode { get; set; } = string.Empty;
            public string ProjectName { get; set; } = string.Empty;
            public int SpentHours { get; set; } = 0;
        }

        public class WorkReport
        {

            private readonly List<WorkReportEntry> _entries;

            public WorkReport()
            {
                _entries = new List<WorkReportEntry>();
            }

            public void AddEntry(WorkReportEntry entry) => _entries.Add(entry);
            public void RemoveEntryAt(int index) => _entries.RemoveAt(index);
            public override string ToString() =>
                string.Join(Environment.NewLine, _entries.Select(x => $"Code: {x.ProjectCode}, Name: {x.ProjectName}, Hours: {x.SpentHours}"));

        }

        public class FileSaver<T>
        {
            public static void SaveToFile(string directoryPath, string fileName, IEntryManager<T> workReport)
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                File.WriteAllText(Path.Combine(directoryPath, fileName), workReport.ToString());
            }

            public static void SaveToFile(string directoryPath, string fileName, WorkReport workReport)
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                File.WriteAllText(Path.Combine(directoryPath, fileName), workReport.ToString());
            }
        }


        #region Dispose
        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~SRP()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    /**
     * Making the code even better.
     */
    internal partial class SRP : ISolution
    {
        internal interface IEntryManager<T>
        {
            void AddEntry(T entry);
            void RemoveEntryAt(int index);
        }

        internal class ScheduleTask {
            public int TaskId { get; set; } = 0;
            public string Content { get; set; } = string.Empty;
            public DateTime ExecuteOn { get; set; } = DateTime.Now;
        }

        public class Scheduler : IEntryManager<ScheduleTask>
        {
            private readonly List<ScheduleTask> _scheduleTasks;

            public Scheduler()
            {
                _scheduleTasks = new List<ScheduleTask>();
            }

            public void AddEntry(ScheduleTask entry)
                => _scheduleTasks.Add(entry);

            public void RemoveEntryAt(int index)
                => _scheduleTasks.RemoveAt(index);
            public override string ToString()
                => string.Join(Environment.NewLine, _scheduleTasks.Select(x => $"Task with id: {x.TaskId} with content: {x.Content} is going to be executed on: {x.ExecuteOn}"));
        }
    }
}
