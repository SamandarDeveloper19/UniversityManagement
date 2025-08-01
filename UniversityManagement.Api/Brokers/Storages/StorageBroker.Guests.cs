using Microsoft.EntityFrameworkCore;
using UniversityManagement.Api.Models.Students;

namespace UniversityManagement.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Student> Students { get; set; }
    }
}
