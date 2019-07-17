using System;
using System.Collections.Generic;
using flowershop.Models;
using flowershop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace flowershop.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FlowerController : ControllerBase
  {
    private readonly FlowerRepository _repo;
    public FlowerController(FlowerRepository repo)
    {
      _repo = repo;
    }


    // GET api/flower
    [HttpGet]
    public ActionResult<IEnumerable<Flower>> Get()
    {
      try
      {
        return Ok(_repo.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }



    // GET api/flower/5
    [HttpGet("{id}")]
    public ActionResult<Flower> Get(int id)
    {
      try
      {
        return Ok(_repo.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }



    // POST api/flower
    [HttpPost]
    public ActionResult<IEnumerable<Flower>> Post([FromBody] Flower value)
    {
      try
      {
        return Ok(_repo.Create(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }



    // PUT api/flower/5
    [HttpPut("{id}")]
    public ActionResult<Flower> Put(int id, [FromBody] Flower value)
    {
      try
      {
        return Ok(_repo.Update(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // DELETE api/flower/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_repo.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}
