using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Internal;

namespace Approval.Web
{
    public static class AutoMapperExtensions
    {
        public static IMappingExpression<TSource, TDestination> MapRecordMember<TSource, TDestination, TMember>(
            this IMappingExpression<TSource, TDestination> mappingExpression,
            Expression<Func<TDestination, TMember>> destinationMember, Expression<Func<TSource, TMember>> sourceMember)
        {
            var memberName = ReflectionHelper.FindProperty(destinationMember).Name;

            return mappingExpression
                .ForMember(destinationMember, opt => opt.MapFrom(sourceMember))
                .ForCtorParam(memberName, opt => opt.MapFrom(sourceMember));
        }
    }
}
