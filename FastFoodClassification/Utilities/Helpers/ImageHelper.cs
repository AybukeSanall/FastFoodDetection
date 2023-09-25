using FastFoodClassification.Utilities.Exceptions;

namespace FastFoodClassification.Utilities.Helpers;

public class ImageHelper
{
    public async Task<string> UrlToBase64String(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Value cannot be null or empty.", nameof(value));

        var isValid = Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute);

        if (isValid)
        {
            using var client = new HttpClient();
            using var response = await client.GetAsync(value);
            await using var stream = await response.Content.ReadAsStreamAsync();

            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        throw new ClassificationsException($"{nameof(value)} değeri bir url içermemektedir. İşleminize devam edebilmek için lütfen geçerli bir url giriniz.");
    }

   
    public async Task<string> PathToBase64String(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("Value cannot be null or empty.", nameof(value));

        var isFileExists = File.Exists(value);
        if (isFileExists)
        {
            var bytes = await File.ReadAllBytesAsync(value);
            return Convert.ToBase64String(bytes);
        }

        throw new ClassificationsException($"{nameof(value)} değerinde belirtilen dosya bulunamadı.");
    }
}