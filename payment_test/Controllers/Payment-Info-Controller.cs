﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Globalization;


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
                    Name = "fady",
                    Phone = 01212074305,
                    Date = DateTime.ParseExact("2021-10-25","yyyy-MM-dd",CultureInfo.InvariantCulture),
                    Age = 22,
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
        public async Task<ActionResult<List<info>>> Addclient(info cli)
        {
            
                client_info.Add(cli);
                return Ok(client_info);
           
        }
    }
}
