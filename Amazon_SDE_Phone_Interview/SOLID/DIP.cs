using Amazon_SDE_Phone_Interview.Interface;

namespace Amazon_SDE_Phone_Interview.SOLID
{
    internal class DIP : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Dependency Inversion Principle");
            var empManager = new EmployeeManager();
            empManager.AddEmployee(new Employee { Name = "Leen", Gender = Gender.Female, Position = Position.Manager });
            empManager.AddEmployee(new Employee { Name = "Mike", Gender = Gender.Male, Position = Position.Amdinistrator });
            var stats = new EmployeeStatistics(empManager);
            Console.WriteLine($"Number of female managers in our company is: {stats.CountFemaleManager()}");
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
        ~DIP()
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

        internal enum Gender
        {
            Male,
            Female
        }

        internal enum Position
        {
            Amdinistrator,
            Manager,
            Executive
        }

        internal interface IEmployeeSearchable
        {
            IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position);
        }

        internal class Employee
        {
            public string Name { get; set; } = string.Empty;
            public Gender Gender { get; set; }
            public Position Position { get; set; }
        }

        internal class EmployeeManager : IEmployeeSearchable
        {
            private readonly List<Employee> _employees = new List<Employee>();

            public EmployeeManager()
            { }

            public void AddEmployee(Employee employee) => _employees.Add(employee);

            public IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position)
                => _employees.Where(emp => emp.Gender.Equals(gender) && emp.Position.Equals(position));
            
            public List<Employee> Employees => _employees;
        }

        internal class EmployeeStatistics
        {
            private readonly IEmployeeSearchable _emp;

            public EmployeeStatistics(IEmployeeSearchable emp)
                => _emp = emp;

            public int CountFemaleManager()
                => _emp.GetEmployeesByGenderAndPosition(Gender.Female, Position.Manager).Count();
        }
    }
}
