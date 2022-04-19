using Crm.CEP.Queries;
using Crm.CEP.Segments;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crm.CEP.DBHelper
{
    public class SegmentParseDBHelper
    {
        private const string StringStr = "string";
        private readonly string BooleanStr = nameof(Boolean).ToLower();
        private readonly string Number = nameof(Number).ToLower();
        private readonly string In = nameof(In).ToLower();
        private readonly string And = nameof(And).ToLower();

        private readonly MethodInfo MethodContains = typeof(Enumerable).GetMethods(
                        BindingFlags.Static | BindingFlags.Public)
                        .Single(m => m.Name == nameof(Enumerable.Contains)
                            && m.GetParameters().Length == 2);

        private delegate Expression Binder(Expression left, Expression right);

        private int count = 0;
        private Expression ParseTree<T>(
            QueryAttributes item,
            ParameterExpression parm)
        {
            Expression left = null;
            //JsonReader reader = new JsonTextReader(new StringReader(item.ToString()));
           // var token = JToken.Load(reader);

           // var nextCondition = token.ToObject<IList<QueryAttributes>>();
          // foreach (var obj in nextCondition) 
           // { 
            var gate = item.NextCondition;
                                
            Binder binder = gate == And ? (Binder)Expression.And : Expression.Or;

            Expression bind(Expression left, Expression right) =>
              left == null ? right : binder(left, right);


            string @operator = item.SegmentOperation;

            var field = item.SegmentAttribute.Replace(" ","");

            var value = item.SegmentValue;

            var property = Expression.Property(parm, field);

            if (@operator == "Equal To")
            {
                var toCompare = Expression.Constant(value);
                var right2 = Expression.Equal(property, toCompare);
                left = bind(left, right2);
            }
            else
            {
                if (@operator == "Less Than/Equal To")
                {
                    var toCompare = Expression.Constant(value);
                    var right2 = Expression.LessThanOrEqual(property, toCompare);
                    left = bind(left, right2);
                }
                else
                {
                    if (@operator == "Greater Than/Equal To")
                    {
                        var toCompare = Expression.Constant(value);
                        var right2 = Expression.GreaterThanOrEqual(property, toCompare);
                        left = bind(left, right2);
                    }
                }
            }


       // }
            return left;
        }

        public Expression<Func<T, bool>> ParseExpressionOf<T>(QueryAttributes doc)
        {
            var itemExpression = Expression.Parameter(typeof(T));

            var conditions = ParseTree<T>(doc, itemExpression);

            if (conditions.CanReduce)
            {
                conditions = conditions.ReduceAndCheck();
            }

            var query = Expression.Lambda<Func<T, bool>>(conditions, itemExpression);
            return query;
        }

        public Func<T, bool> ParsePredicateOf<T>(QueryAttributes doc)
        {
            var query = ParseExpressionOf<T>(doc);
            return query.Compile();
        }


    }
}
