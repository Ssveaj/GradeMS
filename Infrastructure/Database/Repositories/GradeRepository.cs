

using AutoMapper;
using Core.DTO;
using Core.Interface.DataAccess;
using Infrastructure.Database.Fake_database;

namespace Infrastructure.Database.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        public List<GradeDTO> GetStudentsGrade()
        {

            var dummyData = new List<Grade>()
            {
                new Grade { Id = 1, StudentId = 1, StudentGrade = "A" },
                new Grade { Id = 2, StudentId = 2, StudentGrade = "B" },
                new Grade { Id = 3, StudentId = 3, StudentGrade = "C" },
                new Grade { Id = 4, StudentId = 4, StudentGrade = "A" },
            };

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Grade, GradeDTO>(MemberList.Destination);

            });
            config.AssertConfigurationIsValid();
            var mapper = new Mapper(config);
            var mappedData = mapper.Map<List<Grade>, List<GradeDTO>>(dummyData);

            return mappedData;

        }
    }
}
