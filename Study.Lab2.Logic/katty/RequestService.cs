using Study.Lab2.Logic.Interfaces.katty;
using System.Net;

namespace Study.Lab2.Logic.katty;

public class RequestService : IRequestService
{
    public string SendRequest(string url)
    {
        try
        {
            var request = WebRequest.Create(url);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        catch (WebException ex)
        {
            if (ex.Response != null)
            {
                using (var errorResponse = ex.Response)
                using (var stream = errorResponse.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    var errorText = reader.ReadToEnd();
                    return $"Error: {(int)((HttpWebResponse)errorResponse).StatusCode} - {errorText}";
                }
            }
            return $"Error: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    public async Task<string> SendRequestAsync(string url, CancellationToken cancellationToken = default)
    {
        try
        {
            var request = WebRequest.Create(url);
            using (var response = await request.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
        catch (WebException ex)
        {
            if (ex.Response != null)
            {
                using (var errorResponse = ex.Response)
                using (var stream = errorResponse.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    var errorText = await reader.ReadToEndAsync();
                    return $"Error: {(int)((HttpWebResponse)errorResponse).StatusCode} - {errorText}";
                }
            }
            return $"Error: {ex.Message}";
        }
        catch (OperationCanceledException)
        {
            return "Error: Операция была отменена";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}