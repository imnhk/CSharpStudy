using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CSharpStudy
{
    class Lambda
    {

    }

    class MainApp
    {
        delegate int Calculate(int a, int b);
        delegate string Concatenate(string[] args);

        static void Main(string[] args)
        {
            Calculate calc = (a, b) => a + b;
            Concatenate concat = (arr) =>
            {
                string result = "";
                foreach (string str in args)
                    result += str;
                return result;
            };
            Func<int> func1 = () => 10;
            Func<int, int> func2 = (x) => x;
            Func<int, int, int> func3 = (x, y) => x * y;

            Action act1 = () => Console.WriteLine("action1");
            Action<int> act2 = (x) => Console.WriteLine(x * x);
            Action<double, double> act3 = (x, y) => Console.WriteLine("div: {0}", x / y);

            Console.WriteLine(calc(3, 4));
            Console.WriteLine(concat(args));
            Console.WriteLine(func1());
            Console.WriteLine(func2(123));
            Console.WriteLine(func3(23, 56));
            act1();
            act2(23);
            act3(23.11, 56.3234);

            // Using expression tree
            Expression const1 = Expression.Constant(1); // 1
            Expression const2 = Expression.Constant(2); // 2
            Expression leftExp = Expression.Multiply(const1, const2); // 1*2

            Expression param1 = Expression.Parameter(typeof(int)); // x
            Expression param2 = Expression.Parameter(typeof(int)); // y
            Expression rightExp = Expression.Subtract(param1, param2); // x-y

            Expression exp = Expression.Add(leftExp, rightExp); // (1*2)+(x-y)
            Expression<Func<int, int, int>> expression =
                Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>
                (exp, new ParameterExpression[] { (ParameterExpression)param1, (ParameterExpression)param2 });

            Func<int, int, int> func = expression.Compile();
            Console.WriteLine($"1*2+({7}-{8}) = {func(7, 8)}");

            // Using lambda
            Expression<Func<int, int, int>> lambdaExp = (a, b) => 1 * 2 + (a - b);
            Func<int, int, int> lambdaFunc = lambdaExp.Compile();
            Console.WriteLine("Same result: {0}", lambdaFunc(7, 8));

        }
    }
}
