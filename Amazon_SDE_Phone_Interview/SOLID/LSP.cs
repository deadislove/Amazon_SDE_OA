using Amazon_SDE_Phone_Interview.Interface;

namespace Amazon_SDE_Phone_Interview.SOLID
{
    internal class LSP : ISolution
    {
        private bool disposedValue;

        public void Solution()
        {
            Console.WriteLine("Liskov Substitution Principle");
            var numbers = new int[] { 5, 7, 9, 8, 1, 6, 4 };
            SumCalculator sum = new SumCalculator(numbers);
            Console.WriteLine($"The sum of all the numbers: {sum.Calculate()}");
            Console.WriteLine();
            EvenNumbersSumCalculator evenSum = new EvenNumbersSumCalculator(numbers);
            Console.WriteLine($"The sum of all the even numbers: {evenSum.Calculate()}");
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
        ~LSP()
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
                
        internal class SumCalculator : Calculator
        {
            public SumCalculator(int[] numbers) : base(numbers)
            {
                
            }

            public override int Calculate() => _numbers.Sum();
        }

        internal class EvenNumbersSumCalculator : SumCalculator
        {
            public EvenNumbersSumCalculator(int[] numbers) : base(numbers)
            { }

            public override int Calculate() => _numbers.Where(x => x % 2 == 0).Sum();
        }

        // Implementing the Liskov Substitution Principle

        internal abstract class Calculator
        {
            protected readonly int[] _numbers;
            public Calculator(int[] numbers)
            {
                _numbers = numbers;
            }

            public abstract int Calculate();
        }
    }
}
