using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalMaterials.Data.DAL
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MaterialsContext context) : base(context) { }
    }
}
