namespace MathsLib
{
    /// <summary>
    /// <para>This class provides basic mathematical operations.</para>
    /// </summary>
    public class MathsProgram
    {
        // method to add two integers
        public int Add(int a, int b)
        {
            return a + b;
        }

        // method to subtract two integers
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        private void HelperMethod()
        {
            // This is a private helper method
        }
        protected internal int Multiple(int a, int b)
        {
            return (a * b);
        }
    }
}
