using FastFoodClassification.Entities.Dtos;
using FastFoodClassification.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodDetection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FastFoodDetectionController : ControllerBase
    {
        private readonly IFastFoodDetectionService _fastFoodDetectionService;

        public FastFoodDetectionController(IFastFoodDetectionService detectionService)
        {
            _fastFoodDetectionService = detectionService; 

        }

        [HttpPost("Detect")]
        public async Task<ActionResult> Detect(FastFoodRequestDto request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Invalid request data.");
                }

                if (string.IsNullOrWhiteSpace(request.Data))
                {
                    return BadRequest("Data cannot be null or empty.");
                }

                var result = await _fastFoodDetectionService.PredictImage(request.Type, request.Data);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while classifying the image.");
            }
        }
    }
}