using FastFoodClassification.Entities.Dtos;

namespace FastFoodClassification.Services;

public interface IFastFoodDetectionService
{
    Task<FastFoodResponseDto> PredictImage(SourceType type, string value);
}