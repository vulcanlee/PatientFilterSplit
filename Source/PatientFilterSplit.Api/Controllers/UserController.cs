using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PateintFilterSplit.Business.Repositorys;
using PatientFilterSplit.Dto;
using PatientFilterSplit.Dto.Sample;
using PatientFilterSplit.EntityModel.Sample;
using PatientFilterSplit.Model.Sample;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientFilterSplit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<APIResult<IEnumerable<UserDto>>> Get()
        {
            var result = new APIResult<IEnumerable<UserDto>>();
            try
            {
                var users = mapper.Map<IEnumerable<UserDto>>(userRepository.GetAllUsers());
                result.Payload = users;
                result.HTTPStatus = 200;
                return Ok(result);

            }
            catch (Exception ex)
            {
                result.HTTPStatus = 401;
                result.Success = false;
                result.Message = ex.Message;
                return BadRequest(result);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<APIResult<UserDto>> Get(int id)
        {
            var result = new APIResult<UserDto>();
            try
            {


                var user = mapper.Map<UserDto>(userRepository.GetUserById(id));
                result.Payload = user;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.HTTPStatus = 401;
                result.Success = false;
                result.Message = ex.Message;
                return BadRequest(result);

            }
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] UserDto user)
        {
            userRepository.AddUser(mapper.Map<ElkUser>(user));
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDto user)
        {
            userRepository.UpdateUser(mapper.Map<ElkUser>(user));
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userRepository.RemoveUser(id);
        }
    }
}
