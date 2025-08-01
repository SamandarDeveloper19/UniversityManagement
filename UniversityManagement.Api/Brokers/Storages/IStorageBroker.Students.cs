using UniversityManagement.Api.Models.Students;

namespace UniversityManagement.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Student> InsertStudentAsync(Student student);
    }
}
