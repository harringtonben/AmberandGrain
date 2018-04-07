using AmberAndGrain.Models;
using AmberAndGrain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmberAndGrain.Controllers
{
    [RoutePrefix("api/batches")]
    public class BatchesController : ApiController
    {
        [HttpPost, Route("")]
        public HttpResponseMessage AddBatch(AddBatchDto addBatch)
        {
            var batchRepository = new BatchRepository();
            var createBatch = batchRepository.Create(addBatch.RecipeId, addBatch.Cooker);
    

            if (createBatch)
                return Request.CreateResponse(HttpStatusCode.Created);

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Sorry we could not create a batch at this time, please try again later.");
        }

        [HttpPatch, Route("{batchId}/mash")]
        public HttpResponseMessage MashBatch(int batchId)
        {
            var batchRepository = new BatchRepository();
            Batch singleBatch;
            try
            {
               singleBatch = batchRepository.Get(batchId);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Batch with {batchId} does not exit. U suk.");
            }

            if (singleBatch.Status == BatchStatus.Created)
            {
                singleBatch.Status = BatchStatus.Mashed;
                var updateStatus = batchRepository.Update(singleBatch);

                return updateStatus ? Request.CreateResponse(HttpStatusCode.OK) : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "I suk");
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "U suk");
        }
    }

}
