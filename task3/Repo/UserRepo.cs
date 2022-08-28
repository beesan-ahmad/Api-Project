using task3.Mdels;
using task3.Repo;

namespace task3.Repo
{
    public interface IUserInterface
    {
        public List<User> GetAll();
        public User Get(int id);
        public void delete(int id);

        public User add(User user);
        public User update(User user);
    }



    public class UserRepo : IUserInterface
    {

        List<User> users { get; set; }
        UserRepo()
        {
            users = new List<User>()
            {
                new User() { Id = 1, Name = "Ali"},
                new User() { Id = 2, Name = "Sara" },
                new User() { Id = 3, Name = "beesan" },
                new User() { Id = 4, Name = "ahmad" }
        };
        }
        public List<User> GetAll()
        {
            return users;
        }
        public User Get(int id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }
        public void delete(int id)
        {
            var user = Get(id);
            if (user != null)
                users.Remove(user);
        }

        public User add(User user)
        {
            users.Add(user);
            return user;
        }

        public User update(User user)
        {
            var index = users.FindIndex(e => e.Id == user.Id);
            if (index == -1)
               
            users[index] = user;

            return user;

        }
    }

    



}
