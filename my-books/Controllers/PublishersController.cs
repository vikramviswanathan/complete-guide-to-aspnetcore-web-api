using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.ViewModel;
using my_books.Migrations.ActionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PubisherController : ControllerBase
    {
        private PublishersService _publishersService;

        public PubisherController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet("get-publisher-by-id/{id}")]
        //public IActionResult GetPublisherById(int id)
        //{
        //    var _response = _publishersService.GetPublisherById(id);

        //    if (_response != null)
        //    {
        //        return Ok(_response);
        //    } else
        //    {
        //        return NotFound();
        //    }
        //}
        //public Publisher GetPublisherById(int id)
        //{
        //    var _response = _publishersService.GetPublisherById(id);

        //    if (_response != null)
        //    {
        //        return _response;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        //public ActionResult<Publisher> GetPublisherById(int id)
        //{
        //    var _response = _publishersService.GetPublisherById(id);

        //    if (_response != null)
        //    {
        //        return _response;
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}
        public CustomActionResult GetPublisherById(int id)
        {
            var _response = _publishersService.GetPublisherById(id);

            if (_response != null)
            {
                var _responseObj = new CustomActionResultVM()
                {
                    Exception = new Exception("This is coming from publishers controller")
                };

                return new CustomActionResult(_responseObj);
            }
            else
            {
                var _responseObj = new CustomActionResultVM()
                {
                    Publisher = _response
                };

                return new CustomActionResult(_responseObj);
            }
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publishersService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _publishersService.DeletePublisherId(id);
            return Ok();
        }
    }
}
