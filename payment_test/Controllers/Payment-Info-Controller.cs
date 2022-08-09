using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using RabbitMQ.Client;
using System.Globalization;
using System.Text;
using Newtonsoft.Json;
using System.Net.Mime;

namespace payment_test.Controllers
{

    [Route("api/[controller]")]

    [ApiController]



    public class Payment_Info_Controller : ControllerBase
    {
        
        private static List<info> client_info = new List<info>
        {
             
                new info {
                    Id = 1,
                    Phone = 01212074305,
                    Age = 30,
                    Gender = false,
                    Comment = "wsdsaads d d d  dd ddsakdks "
                }
         };
        [HttpGet]
        public async Task<ActionResult<List<info>>> Get()
        {
            return Ok(client_info);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Addclient(info cli)
       {
            
                client_info.Add(cli);
                return Ok(client_info);
               
        }
    }
}
