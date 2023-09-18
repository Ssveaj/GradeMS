using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.DataAccess
{
    public interface IGradeRepository
    {
        List<GradeDTO> GetStudentsGrade();
    }
}
