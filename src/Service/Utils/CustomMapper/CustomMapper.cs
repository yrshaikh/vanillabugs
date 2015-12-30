using System.Collections.Generic;
using AutoMapper;
using Data.Core.EntityFramework;

namespace Service.Core
{
    public static class CustomMapper
    {
        public static void ConfigureCustomMapper()
        {
            Mapper.Initialize(cfg => cfg.SourceMemberNameTransformer = ConvertNames);

            /*** Projects ***/
            Mapper.CreateMap<Project, ProjectModel>();
            Mapper.CreateMap<Project, ProjectListModel>().FixDestination(new string[] { "UpdatedDateTimeMoment" })
                .ForMember(dest => dest.MemberCount, opt => opt.MapFrom(src => src.UserProjectMappings.Count));

            /*** Project User ***/
            Mapper.CreateMap<AspNetUser, AspNetUserModel>();
            
            /*** Issues ***/
            Mapper.CreateMap<Issue, CreateIssueModel>();
            Mapper.CreateMap<IssuePriorityMaster, IssueMasterModel>();
            Mapper.CreateMap<IssueStatusMaster, IssueMasterModel>();
            Mapper.CreateMap<IssueTypeMaster, IssueMasterModel>();

            Mapper.AssertConfigurationIsValid();
        }
        
        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            try
            {
                return Mapper.Map<TSource, TDestination>(source);
            }
            catch (AutoMapperMappingException ex)
            {
                throw new AutoMappingException(ex.Message, ex);
            }
        }

        public static IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source)
        {
            return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
        }

        public static TDestination DynamicMap<TSource, TDestination>(TSource source)
        {
            return Mapper.DynamicMap<TSource, TDestination>(source);
        }

        #region private methods
        private static string ConvertNames(string inputString)
        {
            // transform the sections into w/e you need     
            return inputString.Replace("_", "");
        }
        #endregion
    }

}
