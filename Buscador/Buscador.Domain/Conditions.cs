using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Buscador.Domain.com.clarin.filters;

namespace Buscador.Domain
{
    public static class Conditions
    {
        public static IEnumerable<Condition> From(string conditionsString, IUrlOfuscator urlOfuscator)
        {
            var conditionsArray = Regex.Split(conditionsString, urlOfuscator.OfuscatedCharacters["&"].ToString());
            conditionsArray = conditionsArray.Where(x => x != string.Empty).ToArray();
            //conditionsArray:
            //param=1
            //param=2
            var conditions = new List<Condition>();

            conditionsArray.ToList().ForEach(x => conditions.Add(ConditionFactory.GetInstance(Regex.Split(x, urlOfuscator.OfuscatedCharacters["="].ToString())[0],
                                                                                              Regex.Split(x, urlOfuscator.OfuscatedCharacters["="].ToString())[1])));
            return conditions;
        }
    }

    public static class ConditionFactory
    {
        public static Condition GetInstance(string paramName, string value)
        {
            if (paramName == "PG")
                return new PageCondition(paramName, value);

            if (paramName == "PS")
                return new PageSizeCondition(paramName, value);

            return paramName == "SO" ? new OrderCondition(paramName, value) : new Condition(paramName,value);
        }
    }

    public class Condition
    {
        public string Value { get; set; }

        public string ParamName { get; set; }

        public Condition(string paramName, string value)
        {
            ParamName = paramName;
            Value = value;
        }

        public bool Empty()
        {
            return string.IsNullOrEmpty(ParamName) && string.IsNullOrEmpty(Value);
        }
    }

    public class PageCondition : Condition
    {
        public PageCondition(string paramName, string value) : base(paramName, value)
        {}   
    }

    public class PageSizeCondition : Condition
    {
        public PageSizeCondition(string paramName, string value)
            : base(paramName, value)
        { }
    }

    public class OrderCondition : Condition
    {
        public OrderCondition(string paramName, string value) : base(paramName, value)
        {}   
    }
}