using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyItemShop.Models;

namespace MyItemShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : BaseController<Item, ItemDTO>
    {


        public ItemsController(UserContext context, IMapper mapper) : base(context, mapper)
        {
      
        }

        
            
        

    
    } 
}
