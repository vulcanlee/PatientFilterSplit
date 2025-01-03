using PatientFilterSplit.EntityModel.Sample;
using PatientFilterSplit.Model.Sample;

namespace PateintFilterSplit.Business.Repositorys
{
    public interface IUserRepository
    {
        void AddUser(ElkUser user);
        IEnumerable<ElkUser> GetAllUsers();
        ElkUser GetUserById(int id);
        void RemoveUser(int id);
        void UpdateUser(ElkUser user);
    }
}