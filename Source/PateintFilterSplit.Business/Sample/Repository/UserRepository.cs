using PatientFilterSplit.EntityModel;
using PatientFilterSplit.EntityModel.Sample;
using PatientFilterSplit.Model.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PateintFilterSplit.Business.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;
        private readonly ElkDBContext elkDB;

        public UserRepository(ElkDBContext elkDB)
        {
            this.elkDB = elkDB;
        }

        public void AddUser(ElkUser user)
        {
            user.CreatedDate = DateTime.Now;
            user.UpdatedDate = DateTime.Now;
            elkDB.ElkUser.Add(user);
            elkDB.SaveChanges();
        }

        public ElkUser GetUserById(int id)
        {
            return elkDB.ElkUser.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<ElkUser> GetAllUsers()
        {
            return elkDB.ElkUser;
        }

        public void RemoveUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                elkDB.Remove(user);
                elkDB.SaveChanges();
            }
        }

        public void UpdateUser(ElkUser user)
        {
            var existingUser = GetUserById(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.UpdatedDate = DateTime.Now;
                elkDB.Update(existingUser);
                elkDB.SaveChanges();
            }
        }
    }
}
