using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System.Net;

namespace PetStoreRestSharp.Clients
{
    public abstract class BaseClient
    {
        protected readonly RestClient RestClient;
        protected readonly Uri BaseUrl;

        protected BaseClient(Uri baseUrl)
        {
            BaseUrl = baseUrl;
            RestClient = new RestClient(BaseUrl);
        }

        protected virtual T ExecuteWithDeserialization<T>(Method method, string url, object body, HttpStatusCode? expectedStatusCode)
        {
            return DeserializeResponse<T>(Execute(method, url, body, expectedStatusCode));
        }

        protected virtual RestResponse ExecuteWithoutDeserialization(Method method, string url, object body, HttpStatusCode? expectedStatusCode)
        {
            return (Execute(method, url, body, expectedStatusCode));
        }

        protected virtual RestResponse ExecuteWithFileUpload(Method method, string url, string filePath, string contentType, HttpStatusCode? expectedStatusCode)
        {
            var request = new RestRequest(url, method);
            var fileName = Path.GetFileName(filePath);
            var response = RestClient.Execute(request);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }
            var fileBytes = File.ReadAllBytesAsync(filePath).GetAwaiter().GetResult();
            return Execute(request, url, null, expectedStatusCode);
        }

        protected virtual RestResponse Execute(Method method, string url, object? body, HttpStatusCode? expectedStatusCode)
        {
            var request = new RestRequest(url, method);
            return Execute(request, url, body, expectedStatusCode);
        }

        protected virtual RestResponse Execute(RestRequest request, string url, object? body, HttpStatusCode? expectedStatusCode)
        {
            AddAutorization(request);
            AddHeaders(request);

            if (body != null)
            {
                var bodyString = JsonConvert.SerializeObject(body, SerializationSettings);
                request.AddJsonBody(bodyString);
            }

            var requestDate = DateTime.UtcNow;
            var response = Execute(request);

            if (expectedStatusCode != null && !response.StatusCode.Equals(expectedStatusCode))
            {
                var parameters = string.Join(string.Empty, request.Parameters
                    .Where(x => !x.Type.Equals(ParameterType.HttpHeader))
                    .Select(x => $"{x.Name} ({x.Type}): {x.Value}\n"));

                var newLine = Environment.NewLine;
                var responseHeaders = string.Join(newLine, response.Headers!);

                throw new HttpRequestException(
                    $"Request to {url} failed. " +
                    $"Expected status code: {(int)expectedStatusCode} but received {(int)response.StatusCode}. " +
                    $"Request date (UTC): {requestDate}{newLine}" +
                    $"Request parameters:{newLine}{parameters}{newLine}" +
                    $"Response headers:{newLine}{responseHeaders}{newLine}" +
                    $"Response content:{newLine}{response.Content}");
            }
            return response;
        }

        protected virtual RestResponse Execute(RestRequest request)
        {
            return RestClient.Execute(request);
        }

        protected virtual void AddHeaders(RestRequest request) { }

        protected virtual void AddAutorization(RestRequest request) { }

        protected virtual T DeserializeResponse<T>(RestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content!, SerializationSettings);
        }

        protected virtual JsonSerializerSettings SerializationSettings => new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        protected async Task<T> HandleResponseAsync<T>(RestResponse response, Func<Task<T>> onSuccess, string errorPrefix)
        {
            if (response.IsSuccessful)
                return await onSuccess();
            throw new Exception($"{errorPrefix}: {response.ErrorMessage ?? response.StatusDescription}");
        }
    }
}
