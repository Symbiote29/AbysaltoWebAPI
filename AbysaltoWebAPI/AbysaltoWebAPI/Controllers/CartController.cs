using AbysaltoWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AbysaltoWebAPI.Models;

namespace AbysaltoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ApiContext _context;

        public CartController(ApiContext context)
        {
            _context = context;
        }
    }
}
