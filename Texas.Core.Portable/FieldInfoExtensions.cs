using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PokerHandEvaluator.Portable
{
    public static class FieldInfoExtensions
    {
        public static TResult TryGetValue<TResult>(this FieldInfo fieldInfo)
        {
            try
            {
                if (fieldInfo.FieldType.FullName == typeof(TResult).FullName)
                    return (TResult)fieldInfo.GetValue(fieldInfo);
                else
                    return default(TResult);
            }
            catch { }
            return default(TResult);
        }

    }
}
