using FastFoodClassification.Entities.Dtos;
using FastFoodClassification.Utilities.Helpers;
using Microsoft.Extensions.ML;


namespace FastFoodClassification.Services;

public class FastFoodDetectionService : IFastFoodDetectionService
{
    private readonly ImageHelper _imageHelper;
    private readonly PredictionEnginePool<MLModel1.ModelInput, MLModel1.ModelOutput> _prediction;

    public FastFoodDetectionService(PredictionEnginePool<MLModel1.ModelInput, MLModel1.ModelOutput> prediction)
    {
        _prediction = prediction;
        _imageHelper = new ImageHelper();
    }

    public async Task<FastFoodResponseDto> PredictImage(SourceType type, string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Value cannot be null or empty.", nameof(value));

        var result = type switch
        {
            SourceType.UrlAddress => await _imageHelper.UrlToBase64String(value),
            SourceType.FilePath => await _imageHelper.PathToBase64String(value),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };

        var input = new MLModel1.ModelInput
        {
            ImageSource = Convert.FromBase64String(result)
        };

        var predictResult = await Task.FromResult(_prediction.Predict(input));
        var accuracyPercentages = predictResult.Score.Select(score => score).ToArray();

        return new FastFoodResponseDto()
        {
            Label = predictResult.Label.ToString(),
            Predicted = predictResult.PredictedLabel,
            Accuracy = accuracyPercentages,
            PredictRate = Convert.ToInt32(predictResult.Score.Max() * 100)
        };
    }
}