using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task3.Repo;
using task3.Mdels;
namespace task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private IUserInterface _userRepo;
        public Users( IUserInterface UserRep )
        {
           // _userRepo = UserRepo;
        }
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return Ok(_userRepo);
        }
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userRepo.Get(id);
            if (user == null)
                return NotFound();
            return user;
        }
        [HttpDelete]

        public ActionResult<User> Delete(int id)
        {
            var user = _userRepo.Get(id);
            if (user == null)
                return NotFound();
            _userRepo.delete(id);
            return Ok();
        }
        [HttpPost]
        public ActionResult<User> Creat(User user)
        {
            _userRepo.add(user);
            return Ok();
        }
        [HttpPut]
      public ActionResult<User> Update(User user)
        {
            var _user = _userRepo.Get(user.Id);
            if(_user == null)
                return NotFound();
            _userRepo.update(user);
            return Ok();
        }
    }

}
