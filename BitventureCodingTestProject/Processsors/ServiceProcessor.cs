using BitventureCodingTestProject.Helpers;
using BitventureCodingTestProject.Models.Requests;
using BitventureCodingTestProject.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace BitventureCodingTestProject.Processsors
{
    public class ServiceProcessor
    {
        public ServiceProcessor()
        {
            ApiHelpers.InitializeClient();
        }
        public async Task CallWebAPIAsync(string file)
        {
            try
            {
                var jsonMapper = MapJsonFile(file);

                foreach (var service in jsonMapper.Services.ToList())
                {
                    if (service.Enabled)
                    {
                        foreach (var endpoint in service.Endpoints.ToList())
                        {
                            if (endpoint.Enabled)
                            {
                                using (HttpResponseMessage responseMessage = await ApiHelpers.ApiClient.GetAsync(service.BaseUrl + endpoint.Resource))
                                {
                                    ResponseJsonModel responseModel = null;

                                    if (responseMessage.IsSuccessStatusCode)
                                    {
                                        if (service.Datatype == "XML")
                                        {
                                            var responseXmlString = await responseMessage.Content.ReadAsStringAsync();

                                            var jsonString = SerializeXml(responseXmlString);

                                            responseModel = JsonConvert.DeserializeObject<ResponseJsonModel>(jsonString);

                                        }
                                        else if (service.Datatype == "JSON")
                                        {
                                            responseModel = await responseMessage.Content.ReadAsAsync<ResponseJsonModel>();
                                        }

                                        CompareRequestAndRespose(responseModel, endpoint.Response.ToList(), service.Identifiers.ToList());
                                    }
                                    else
                                    {
                                        throw new Exception(responseMessage.ReasonPhrase);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " + ex.StackTrace);
            }
        }

        public void CompareRequestAndRespose(ResponseJsonModel response, List<Response> responseRequestModels, List<Identifier> identifiers)
        {
            foreach (var responseRequestModel in responseRequestModels)
            {
                if (!string.IsNullOrEmpty(responseRequestModel.Identifier))
                {
                    var value = string.Empty;
                    if (responseRequestModel.Identifier == identifiers.FirstOrDefault().Key)
                    {
                        value = identifiers.Where(x => x.Key == responseRequestModel.Identifier).FirstOrDefault().Value;
                    }
                    else
                    {
                        Console.WriteLine($"\nThere is no Key in identifies matches {responseRequestModel.Identifier} "); 
                    }
                    
                    if (!string.IsNullOrEmpty(response.Director) || !string.IsNullOrEmpty(response.Name))
                    {
                        if (value == response.Name || value == response.Director)

                        {
                            if (value == response.Name)
                            {
                                Console.WriteLine($"\n{value} it is name supplied  = {response.Name}");
                            }
                            if (value == response.Director)
                            {
                                Console.WriteLine($"\n{value} it is director supplied  = {response.Director}");
                            }

                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(response.Name) || !string.IsNullOrEmpty(response.Director))
                            {
                                Console.WriteLine($"\n{value} is not the same as {response.Name} or {response.Director}");
                            }
                            else
                            {
                                Console.WriteLine($"\nNo data to compare {value} with");
                            }
                        }
                    }
                    else if (response.GeoPlugin != null)
                    {
                        if (value == response.GeoPlugin.GeopluginRequest || value == response.GeoPlugin.GeopluginCity)
                        {
                            if (value == response.GeoPlugin.GeopluginRequest)
                            {
                                Console.WriteLine($"\n{value} it is the GeopluginRequest supplied  = {response.GeoPlugin.GeopluginRequest}");
                            }
                            if (value == response.GeoPlugin.GeopluginCity)
                            {
                                Console.WriteLine($"\n{value} it is  the GeopluginCity supplied = {response.GeoPlugin.GeopluginCity}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNo data found matching your request, sorry :(");
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(responseRequestModel.Regex))
                {
                    if (response.Height == responseRequestModel.Regex || response.Title == responseRequestModel.Regex)
                    {
                        if (responseRequestModel.Regex == response.Height)
                        {
                            Console.WriteLine($"\n{responseRequestModel.Regex} it is the height supplied  = {response.Height}");
                        }
                        if (responseRequestModel.Regex == response.Title)
                        {
                            Console.WriteLine($"\n{responseRequestModel.Regex} it is  the title supplied = {response.Title}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo data found matching your request, sorry :(");
                    }
                }
            }
        }

        public JsonMapper MapJsonFile(string fileName)
        {
            JsonMapper jsonMapper = null;

            using (StreamReader read = new StreamReader(fileName))
            {
                string jsonData = read.ReadToEnd();

                jsonMapper = JsonConvert.DeserializeObject<JsonMapper>(jsonData);
            }

            return jsonMapper;
        }

        public string SerializeXml(string xmlString)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);

            return JsonConvert.SerializeXmlNode(doc); ;
        }
    }
}
