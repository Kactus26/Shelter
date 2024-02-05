using Microsoft.AspNetCore.Mvc;
using Shelter.Interfaces;

namespace Shelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerConrtoller : Controller
    {
        private readonly IOwner _ownerRepository;
        public OwnerConrtoller()
        {
            
        }
    }
}
