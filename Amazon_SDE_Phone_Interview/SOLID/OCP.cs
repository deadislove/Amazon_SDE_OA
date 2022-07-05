using Amazon_SDE_Phone_Interview.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_SDE_Phone_Interview.SOLID
{
    internal class OCP : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Open–closed principle");
            var devReports = new List<DeveloperReport>
            {
                new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate  = 30.5, WorkingHours = 160 },
                new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate  = 20, WorkingHours = 150 },
                new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate  = 30.5, WorkingHours = 180 }
            };
            var calculator = new SalaryCalculator(devReports);
            Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");
            Console.WriteLine();
            Console.WriteLine("Better Salary Calculator Example – OCP implemented");
            var devCalculations = new List<BaseSalarycalculator>
            {
                new SeniorDevSalaryCalculator(new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 160 }),
                new JuniorDevSalaryCalculator(new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate = 20, WorkingHours = 150 }),
                new SeniorDevSalaryCalculator(new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 180 })
            };
            var calculatorPro = new SalaryCalculatorPro(devCalculations);
            Console.WriteLine($"Sum of all the developer salaries is {calculatorPro.CalculateTotalSalaries()} dollars");
            Console.WriteLine();
            Console.WriteLine("Filtering Computer Monitors Example");

            var monitors = new List<ComputerMonitor>
            {
                new ComputerMonitor { Name = "Samsung S345", Screen = Screen.CurvedScreen, Type = MonitorType.OLED },
                new ComputerMonitor { Name = "Philips P532", Screen = Screen.WideScreen, Type = MonitorType.LCD },
                new ComputerMonitor { Name = "LG L888", Screen = Screen.WideScreen, Type = MonitorType.LED },
                new ComputerMonitor { Name = "Samsung S999", Screen = Screen.WideScreen, Type = MonitorType.OLED },
                new ComputerMonitor { Name = "Dell D2J47", Screen = Screen.CurvedScreen, Type = MonitorType.LCD }
            };
            var filter = new MonitorFilter();
            var lcdMonitors = filter.FilterByType(monitors, MonitorType.LCD);
            Console.WriteLine("All LCD monitors");
            foreach (var monitor in lcdMonitors)
            {
                Console.WriteLine($"Name: {monitor.Name}, Type: {monitor.Type}, Screen: {monitor.Screen}");
            }

            Console.WriteLine();
            Console.WriteLine("Filtering Computer Monitors Example Pro");
            var filterPro = new MonitorFilterPro();
            var lcdMonitorsPro = filterPro.Filter(monitors, new MonitorTypeSpecification(MonitorType.LCD));
            foreach (var monitorPro in lcdMonitorsPro)
            {
                Console.WriteLine($"Name: {monitorPro.Name}, Type: {monitorPro.Type}, Screen: {monitorPro.Screen}");
            }

            Console.WriteLine();
            Console.WriteLine("Additional Filter Requests");
            Console.WriteLine("All WideScreen Monitors");
            var wideScreenMonitors = filterPro.Filter(monitors, new ScreenSpecification(Screen.WideScreen));
            foreach (var monitor in wideScreenMonitors)
            {
                Console.WriteLine($"Name: {monitor.Name}, Type: {monitor.Type}, Screen: {monitor.Screen}");
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
        ~OCP()
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

        internal class DeveloperReport
        {
            public int Id { get; set; } = 0;
            public string Name { get; set; } = string.Empty;
            public string Level { get; set; } = string.Empty;
            public int WorkingHours { get; set; } = 0;
            public double HourlyRate { get; set; } = 0;
        }

        public class SalaryCalculator
        {
            private readonly IEnumerable<DeveloperReport> _developerReport;
            public SalaryCalculator(List<DeveloperReport> developerReport)
            {
                _developerReport = developerReport;
            }

            public double CalculateTotalSalaries()
            {
                double totalSalaries = 0D;

                foreach (var devReport in _developerReport)
                {
                    totalSalaries += devReport.HourlyRate * devReport.WorkingHours;
                }
                return totalSalaries;
            }
        }

        /**
         * Better Salary Calculator Example – OCP implemented
         */
        internal abstract class BaseSalarycalculator
        {
            protected DeveloperReport DeveloperReport { get; private set; }
            public BaseSalarycalculator(DeveloperReport developerReport)
            {
                DeveloperReport = developerReport;
            }

            public abstract double CalculateSalary();
        }

        internal class SeniorDevSalaryCalculator : BaseSalarycalculator
        {
            public SeniorDevSalaryCalculator(DeveloperReport report) : base(report)
            { }

            public override double CalculateSalary()
                => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours * 1.2;
        }

        internal class JuniorDevSalaryCalculator : BaseSalarycalculator
        {
            public JuniorDevSalaryCalculator(DeveloperReport report) : base(report)
            { }

            public override double CalculateSalary()
                => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours;
        }

        internal class SalaryCalculatorPro
        {
            private readonly IEnumerable<BaseSalarycalculator> _developerCalculation;

            public SalaryCalculatorPro(IEnumerable<BaseSalarycalculator> developerCalculation)
            {
                _developerCalculation = developerCalculation;
            }

            public double CalculateTotalSalaries()
            {
                double totalSalaries = 0D;

                foreach (var devCalc in _developerCalculation)
                {
                    totalSalaries += devCalc.CalculateSalary();
                }

                return totalSalaries;
            }
        }

        /**
         * Filtering Computer Monitors Example
         */

        internal enum MonitorType
        {
            OLED,
            LCD,
            LED
        }

        internal enum Screen
        {
            WideScreen,
            CurvedScreen
        }

        internal class ComputerMonitor
        {
            public string Name { get; set; } = string.Empty;
            public MonitorType Type { get; set; }
            public Screen Screen { get; set; }
        }

        public class MonitorFilter
        {
            public List<ComputerMonitor> FilterByType(IEnumerable<ComputerMonitor> monitors, MonitorType type)
                => monitors.Where(m => m.Type.Equals(type)).ToList();

            public List<ComputerMonitor> FilterByScreen(IEnumerable<ComputerMonitor> monitors, Screen screen) 
                => monitors.Where(m => m.Screen == screen).ToList();
        }

        internal interface ISpecificaion<T>
        {
            bool isStatisFied(T item);
        }

        internal interface IFilter<T>
        {
            List<T> Filter(IEnumerable<T> monitors, ISpecificaion<T> specificaion);
        }

        internal class MonitorTypeSpecification : ISpecificaion<ComputerMonitor>
        {
            private readonly MonitorType _type;
            public MonitorTypeSpecification(MonitorType type)
            {
                _type = type;
            }

            public bool isStatisFied(ComputerMonitor item) => item.Type.Equals(_type);
        }

        internal class MonitorFilterPro : IFilter<ComputerMonitor>
        {
            public List<ComputerMonitor> Filter(IEnumerable<ComputerMonitor> monitor, ISpecificaion<ComputerMonitor> specificaion)
                => monitor.Where(m => specificaion.isStatisFied(m)).ToList();
        }

        /**
         * Additional Filter Requests
         */
        internal class ScreenSpecification : ISpecificaion<ComputerMonitor>
        {
            private readonly Screen _screen;

            public ScreenSpecification(Screen screen) {
                _screen = screen;
            }

            public bool isStatisFied(ComputerMonitor item) => item.Screen.Equals(_screen);
        }
    }
}
