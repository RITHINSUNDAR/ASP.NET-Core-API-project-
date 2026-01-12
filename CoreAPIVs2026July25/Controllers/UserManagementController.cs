using CoreAPIVs2026July25.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAPIVs2026July25.Controllers
{
    // [Route("api/[controller]")]
    [Route("UserManagement")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly string _uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        public UserManagementController() 
        { 
            if(!Directory.Exists(_uploadDir))
            {
                Directory.CreateDirectory(_uploadDir);
            }
        }
        userdb dbobj = new userdb();

        // GET: api/<UserManagementController>
        [HttpGet]
        [Route("gettabWithId/{id}")]

        public async Task<IActionResult> Get(int id)
        {
            UserCls getEmployee = dbobj.SelectProfileDB(id);
            var fileUrl = Path.Combine(Directory.GetCurrentDirectory(), "uploads", getEmployee.Photo);

            byte[] imageBytes = await System.IO.File.ReadAllBytesAsync(fileUrl);
            string base64string = Convert.ToBase64String(imageBytes);
            getEmployee.Photo = base64string;
            return Ok(getEmployee);
        }

            

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<UserManagementController>/5
        [HttpGet("{id}")]
        public string Get1(int id)
        {
            return "value";
        }

        // POST api/<UserManagementController>
        [HttpPost]
        [Route("inserttab")]
        public async Task<IActionResult> Post([FromForm] UserCreateDTO createdto)
        {
            UserCls userCls = new UserCls();

            if(createdto.Path==null || createdto.Path.Length==0)
            {
                return BadRequest("No file uploaded.");
            }
            if (!createdto.Path.ContentType.StartsWith("image/"))
            {
                return BadRequest("Only image files are allowed.");
            }
            var filepath = Path.Combine(_uploadDir, createdto.Path.FileName);

            using (var stream = new FileStream(filepath,FileMode.Create))
            {
                await createdto.Path.CopyToAsync(stream);
            }
            userCls.Name = createdto.Name;
            userCls.Age = createdto.Age;
            userCls.Address = createdto.Address;
            userCls.Email = createdto.Email;
            userCls.Photo = createdto.Path.FileName;
            userCls.Username = createdto.Username;
            userCls.Password = createdto.Password;
            dbobj.InsertDB(userCls);

            return await Task.Run(() => Ok(new { message = "Registered successfully!" }));
        }

        //public void Post([FromBody] string value)
        //{
        //}
        [HttpPost]
        [Route("logintab")]

        public async Task<IActionResult> PostLogin([FromBody]  UserLoginDTO createdto)
        {
            UserCls userCls = new UserCls();
            userCls.Username = createdto.Username;
            userCls.Password = createdto.Password;
            string cid = dbobj.LoginDB(userCls);
            if (cid == "1")
            {
                string uid = dbobj.GetUserId(userCls);
                return await Task.Run(() => Ok(new { userId= uid }));

            }
            else
            {
                return await Task.Run(() => Ok(new { message = "Invalid Login!" }));
            }
        }

        // PUT api/<UserManagementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserManagementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
