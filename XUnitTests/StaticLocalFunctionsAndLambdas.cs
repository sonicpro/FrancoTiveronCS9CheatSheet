

using Xunit;

namespace Cs9CheatSheet.StaticLocalFunctions.LocalClosureNoCapture
{
    public class StaticLocalFunctionsAndLambdas
    {
        [Fact]
        public void LocalFunction()
        {
            // Static local function do not capture the variables declared in the outer scope.
            int x = 1;

            int NonPureFunction(int a, int b)
            {
                // Side-effect - changing the outer variable.
                x = 5;
                return a + b;
            }

            // Static local function won't compile if it is trying to access the data outside its context.
            static int PureFunction(int a, int b)
            {
                // x = 5; // Compiler error.
                return a + b;
            }

            // Static local function cannot change external in-scope locals.
            Assert.Equal(2, PureFunction(x, 1));
            // x is still 1:
            Assert.Equal(1, x);

            // Capturing functions are not pure:
            Assert.Equal(2, NonPureFunction(x, 1));
            // x is 5 now.
            Assert.Equal(5, x);
        }

        delegate int AddingFunc(int a, int b);

        [Fact]
        public void Lambda()
        {
            int x = 1;

            AddingFunc NotPureLambda = (a, b) => { x = 5; return a + b; };

            AddingFunc PureLambda = static (a, b) => { /*x = 5; // compiler error*/ return a + b; };

            // Static lambdas cannot change external in-scope locals.
            Assert.Equal(2, PureLambda(x, 1));
            // x is still 1.
            Assert.Equal(1, x);

            // Capturing lambdas have side-effects:
            Assert.Equal(2, NotPureLambda(x, 1));
            // x is 5 now.
            Assert.Equal(5, x);
        }
    }
}
