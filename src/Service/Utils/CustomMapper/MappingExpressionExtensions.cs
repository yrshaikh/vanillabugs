using System;
using AutoMapper;

namespace Service.Core
{
    internal static class MappingExpressionExtensions
    {

        public static IMappingExpression<TSource, TDestination> FixDestination<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mappingExpression, String[] properties)
        //where TDestination : Object
        {
            Type x = typeof(TDestination);
            foreach (var item in properties)
            {
                mappingExpression.ForMember(item, opt => opt.Ignore());
            }

            return mappingExpression;
        }
    }
}
