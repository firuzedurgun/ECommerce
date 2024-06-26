﻿using ECommerce.DAL.Abstract;
using ECommerce.Data.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoriesController(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryDAL.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == null || _categoryDAL.GetAll() == null)
                return BadRequest();
          
            var category = _categoryDAL.Get(Convert.ToInt32(id));
            if (category == null)
                return NotFound("Category Not Found!!!");

            return Ok(category);

        }
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryDAL.Add(category);
                return CreatedAtAction("Get",new {id = category.Id},category);
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult Put(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryDAL.Update(category);
                return Ok(category);
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _categoryDAL.Get(i => i.Id == id);
            if (category == null)
                return BadRequest();

            _categoryDAL.Delete(id);
            return Ok();
        }
    }
}
