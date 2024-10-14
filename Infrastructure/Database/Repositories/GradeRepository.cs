

using AutoMapper;
using Core.DTO;
using Core.Interface.DataAccess;
using Core.Models;
using Core.Models.RequestModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Infrastructure.Database.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly IServiceScopeFactory scopeFactory;
        private readonly IMapper mapper;
        public GradeRepository(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            this.scopeFactory = scopeFactory;
            this.mapper = mapper;
        }

        public async Task<List<GradeEntityDTO?>> GetListOfStudentsGradeAsync(int studentId, string studentName)
        {
            using(var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<GradeDbContext>();

                var grades = await db.Grades.Where(x => x.StudentId == studentId)
                    .ToListAsync().ConfigureAwait(false);

                return this.mapper.Map<List<GradeEntityDTO?>>(grades);
            }
        }

        public async Task<Result<bool>> SetGradeStudentAsync(SetStudentGradeRequestModel requestModel)
        {
            try
            {
                using (var scope = scopeFactory.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<GradeDbContext>();

                    var student = await db.Grades.FirstOrDefaultAsync(x => x.StudentId == requestModel.StudentId && x.StudentName == requestModel.StudentName);
                    if (student is null)
                    {
                        return new Result<bool>
                        {
                            Error = "The student can not be found",
                            HttpStatusCode = (int)HttpStatusCode.BadRequest,
                            Success = false
                        };
                    }

                    student.StudentGrade = requestModel.StudentGrade;
                    db.Grades.Update(student);
                    db.SaveChanges();

                    return new Result<bool>
                    {
                        HttpStatusCode = (int)HttpStatusCode.OK,
                        Success = true
                    };
                }
            }
            catch(Exception ex)
            {
                return new Result<bool>
                {
                    Error = ex.Message,
                    HttpStatusCode = (int)HttpStatusCode.InternalServerError,
                    Success = false
                };
            }
        }
    }
}
