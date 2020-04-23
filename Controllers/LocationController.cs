using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interface;
using Models.Model;

namespace TestApplication.Controllers
{
    [ApiController]
    ////[Authorize]
    public class LocationController : ControllerBase
    {
        private readonly ILocationBusinessLayer locationBusinessLayer;
        public LocationController(ILocationBusinessLayer locationBusinessLayer)
        {
            this.locationBusinessLayer = locationBusinessLayer;
        }

        [HttpGet]
        [Route("api/v1/location/")]
        public async Task<IActionResult> GetAllLocations()
        {
            try
            {
                var result = await this.locationBusinessLayer.GetAllLocations();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("api/v1/location/{locationId}")]
        public async Task<IActionResult> GetLocationById(int locationId)
        {
            try
            {
                var result = await this.locationBusinessLayer.GetLocationsById(locationId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("api/v1/AddLocation/")]
        public async Task<IActionResult> AddLocation(Location location)
        {
            try
            {
                var result = await this.locationBusinessLayer.AddLocation(location);
                return Created("", location);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("api/v1/UpdateLocation/")]
        public async Task<IActionResult> UpdateLocation(Location location)
        {
            try
            {
                var result = await this.locationBusinessLayer.UpdateLocation(location);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("api/v1/DeleteLocation/{locationId}")]
        public async Task<IActionResult> DeleteLocation(int locationId)
        {
            try
            {
                var result = await this.locationBusinessLayer.DeleteLocation(locationId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}