using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using webservice_bac.DataAccess;
using webservice_bac.Models;
using webservice_bac.Utils;

namespace webservice_bac.Controllers
{
    public class ClienteController : ApiController
    {
        [HttpGet]
        [Route("bac/client")]
        public IHttpActionResult Get()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable);
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(
                    new ClienteRepository().GetAll()
                ));
            }
            catch (Exception ex)
            {
                Error error = new Error
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException != null ? ex.InnerException.Message : null
                };

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(JsonConvert.SerializeObject(error));
            }
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return ResponseMessage(response);
        }

        [HttpGet]
        [Route("bac/client")]
        public IHttpActionResult GetById([FromUri] int codigo)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable);
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(
                    new ClienteRepository().FindById(codigo)
                ));
            }
            catch (Exception ex)
            {
                Error error = new Error
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException != null ? ex.InnerException.Message : null
                };

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(JsonConvert.SerializeObject(error));
            }
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return ResponseMessage(response);
        }

        [HttpPost]
        [Route("bac/client")]
        public IHttpActionResult Add([FromBody] Cliente cliente)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable);
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(
                    new ClienteRepository().Add(cliente)
                ));
            }
            catch (Exception ex)
            {
                Error error = new Error
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException != null ? ex.InnerException.Message : null
                };

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(JsonConvert.SerializeObject(error));
            }
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return ResponseMessage(response);
        }

        [HttpGet]
        [Route("bac/client")]
        public IHttpActionResult Put([FromBody] Cliente cliente)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable);
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(
                    new ClienteRepository().Update(cliente)
                ));
            }
            catch (Exception ex)
            {
                Error error = new Error
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException != null ? ex.InnerException.Message : null
                };

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(JsonConvert.SerializeObject(error));
            }
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return ResponseMessage(response);
        }

        [HttpDelete]
        [Route("bac/client")]
        public IHttpActionResult Delete([FromUri] int codigo)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NotAcceptable);
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(JsonConvert.SerializeObject(
                    new ClienteRepository().Delete(codigo)
                ));
            }
            catch (Exception ex)
            {
                Error error = new Error
                {
                    Message = ex.Message,
                    InnerMessage = ex.InnerException != null ? ex.InnerException.Message : null
                };

                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(JsonConvert.SerializeObject(error));
            }
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return ResponseMessage(response);
        }

    }
}
