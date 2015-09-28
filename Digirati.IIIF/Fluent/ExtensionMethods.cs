using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Digirati.IIIF.Fluent
{
    public static class ExtensionMethods
    {

        /// <summary>
        /// This does not test to see if a resource with the same @id has already been asserted.
        /// </summary>
        /// <typeparam name="TSubject"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="subject"></param>
        /// <param name="predicateAsLambda"></param>
        /// <param name="value"></param>
        public static void Assert<TSubject, TValue>(
            this TSubject subject, 
            Expression<Func<TSubject, dynamic>> predicateAsLambda, 
            TValue value)
        {
            var property = GetPropertyFromExpression(predicateAsLambda);
            dynamic current = property.GetValue(subject);
            dynamic newValue;
            if(current == null)
            {
                newValue = value;
            }
            else
            {
                var currentType = current.GetType();
                if(currentType.IsArray)
                {
                    var currentArray = (TValue[])current;
                    TValue[] newArray = new TValue[currentArray.Length + 1];
                    currentArray.CopyTo(newArray, 0);
                    newArray[newArray.Length - 1] = value;
                    newValue = newArray;
                }
                else
                {
                    newValue = new TValue[] { current, value };
                }
            }
            property.SetValue(subject, newValue);
        }

        /// <summary>
        /// Multi value version
        /// </summary>
        /// <typeparam name="TSubject"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="subject"></param>
        /// <param name="predicateAsLambda"></param>
        /// <param name="values"></param>
        public static void AssertMany<TSubject, TValue>(
            this TSubject subject,
            Expression<Func<TSubject, dynamic>> predicateAsLambda,
            IEnumerable<TValue> values)
        {
            if (values != null)
            {
                foreach (TValue value in values)
                {
                    subject.Assert(predicateAsLambda, value);
                }
            }
        }

        private static PropertyInfo GetPropertyFromExpression<T>(
            Expression<Func<T, object>> GetPropertyLambda)
        {
            // thanks: http://stackoverflow.com/questions/17115634/get-propertyinfo-of-a-parameter-passed-as-lambda-expression

            MemberExpression Exp = null;

            //this line is necessary, because sometimes the expression comes in as Convert(originalexpression)
            if (GetPropertyLambda.Body is UnaryExpression)
            {
                var UnExp = (UnaryExpression)GetPropertyLambda.Body;
                if (UnExp.Operand is MemberExpression)
                {
                    Exp = (MemberExpression)UnExp.Operand;
                }
                else
                    throw new ArgumentException();
            }
            else if (GetPropertyLambda.Body is MemberExpression)
            {
                Exp = (MemberExpression)GetPropertyLambda.Body;
            }
            else
            {
                throw new ArgumentException();
            }

            return (PropertyInfo)Exp.Member;
        }
    }
}
