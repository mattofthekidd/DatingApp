using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers { 
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase {
        
    }
}

/*
    the [ApiController] attribute gives us several features
        -automatic data binding for our api requests
        -[FromBody] is not neccessary
        -automatic checking of validation before running the api method
*/