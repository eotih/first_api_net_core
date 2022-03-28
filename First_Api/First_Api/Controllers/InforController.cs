using First_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InforController : ControllerBase
    {
        Bai1Context context = new Bai1Context();
        [HttpGet]
        public IEnumerable<Infor> Get()
        {
            return context.Infors.ToList();
        }
        
        [HttpPost]
        public Response Post(Infor infor)
        {
            if (infor is null)
            {
                throw new ArgumentNullException(nameof(infor));
            }
            Infor infor1 = new()
            {
                Name = infor.Name,
                Phone = infor.Phone,
                Email = infor.Email,
                Age = infor.Age
            };
            context.Infors.Add(infor1);
            context.SaveChanges();
            return new Response
            {
                Status = 201,
                Message = infor
            };
            
        }
    }
}