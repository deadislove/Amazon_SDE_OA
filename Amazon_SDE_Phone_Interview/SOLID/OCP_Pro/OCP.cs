using Amazon_SDE_Phone_Interview.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon_SDE_Phone_Interview.SOLID.OCP_Pro
{
    internal class OCP : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Better Salary Calculator Example – OCP implemented");
            var devCalculations = new List<BaseSalarycalculator>
            {
                new SeniorDevSalaryCalculator(new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 160 }),
                new JuniorDevSalaryCalculator(new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate = 20, WorkingHours = 150 }),
                new SeniorDevSalaryCalculator(new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 180 })
            };
            var calculatorPro = new SalaryCalculatorPro(devCalculations);
            Console.WriteLine($"Sum of all the developer salaries is {calculatorPro.CalculateTotalSalaries()} dollars");
        }

        #region Dispose
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

        public interface IOCP : IDisposable
        {
            abstract double CalculateSalary();
        }

        public abstract class BaseSalarycalculator : IOCP
        {
            protected DeveloperReport DeveloperReport { get; private set; }
            public BaseSalarycalculator(DeveloperReport developerReport)
            {
                DeveloperReport = developerReport;
            }

            public abstract double CalculateSalary();

            public void Dispose() => GC.SuppressFinalize(this);
            
        }

        public class SeniorDevSalaryCalculator : BaseSalarycalculator
        {
            public SeniorDevSalaryCalculator(DeveloperReport report) : base(report)
            { }

            public override double CalculateSalary()
                => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours * 1.2;
        }

        public class JuniorDevSalaryCalculator : BaseSalarycalculator
        {
            public JuniorDevSalaryCalculator(DeveloperReport report) : base(report)
            { }

            public override double CalculateSalary()
                => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours;
        }

        public class SalaryCalculatorPro
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
    }
}
