using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OgrencisController : ControllerBase
    {
        IOgrenciService _ogrenciService;
        public OgrencisController(IOgrenciService ogrenciService)
        {
            _ogrenciService = ogrenciService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _ogrenciService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _ogrenciService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Ogrenci ogrenci)
        {
            var result = _ogrenciService.Add(ogrenci);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
    }

