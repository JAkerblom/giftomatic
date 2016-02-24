using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Giftomatic.Models;

namespace Giftomatic.Data
{
  public class AzureService
  {
    PredictionDataContext _ctx;

    public AzureService (PredictionDataContext ctx)
    {
      _ctx = ctx;
    }

    //string GetPrediction(UserFeatureSet ufs, ItemFeatureSet ifs, ExternalFeatureSet efs)
    string GetPrediction(PredictionDataCollection data)
    {
      UserFeatureSet ufs = data.UserFeatures;
      ItemFeatureSet ifs = data.ItemFeatures;
      ExternalFeatureSet efs = data.ExternalFeatures;

      string[] columnNames = {
        "sexType",
        "age",
        "avgIncome",
        "prefersSuntrip",
        "prefersSoftPresent",
        "chocolatePref",
        "santaBelief",
        "itemID",
        "rating",
        "isExpensive",
        "priceGroup",
        "Category",
        "isFashionCat",
        "isSportsCat",
        "isElectronicsCat"
      };

      string[,] values = new string[,] { { } };
      
      //string requestBody = 
      for (int i = 0; i < 3; i++)
      {
        
      }

      string apiKey = "JUgZsn+BJImk6tSKqPuiaIH1WaVo+J9n+px6qNb4qnLP2K0C9d3Oubkaurhmg+k9SVxA3qXQ3Q4haBoFp6D6BA==";
      string uri = "https://europewest.services.azureml.net/workspaces/0c8371e1485946f48a61b4bdd4f07c2c/services/f9b6186cce7642b59fdc1ad4e2d22768/execute?api-version=2.0&details=true";
      InvokeRequestResponseService(columnNames, values).Wait();

      string result = PostJsonAsync(uri, apiKey, columnNames, values).Result;
      
      return result;
    }

    public async Task<string> PostJsonAsync(string uri, string apiKey, string[] columnNames, string[,] values)
    {
      using (var client = new HttpClient())
      {
        var scoreRequest = new
        {
          Inputs = new Dictionary<string, StringTable>() {
            {
              "inpu1",
              new StringTable()
              {
                //ColumnNames = new string[] {"sexType", "age", "avgIncome", "prefersSuntrip", "prefersSoftPresent", "chocolatePref", "santaBelief", "itemID", "rating", "isExpensive", "priceGroup", "Category", "isFashionCat", "isSportsCat", "isElectronicsCat"},
                //Values = new string[,] { { } }
                ColumnNames = columnNames,
                Values = values
              }
            }
          },
          GlobalParameters = new Dictionary<string, string>() { }
        };

        //const string apiKey = "";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        client.BaseAddress = new Uri(uri);
        //client.BaseAddress = new Uri("https://europewest.services.azureml.net/workspaces/0c8371e1485946f48a61b4bdd4f07c2c/services/f9b6186cce7642b59fdc1ad4e2d22768/execute?api-version=2.0&details=true");

        //return await client.PostAsJsonAsync("", scoreRequest);        
        
        HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

        if (response.IsSuccessStatusCode)
        {
          return await response.Content.ReadAsStringAsync();
        }
        else
        {
          return null;
        }
        //var task = await client.PostAsJsonAsync(uri, new StringContent(json, Encoding.UTF8, "application/json"));
        //task.EnsureSuccessStatusCode();
        //return await task.Content.ReadAsStringAsync();
      }
    }

    static async Task InvokeRequestResponseService(string[] columnNames, string[,] values)
    {
      using (var client = new HttpClient())
      {
        var scoreRequest = new
        {
          Inputs = new Dictionary<string, StringTable>() {
            {
              "inpu1",
              new StringTable()
              {
                //ColumnNames = new string[] {"sexType", "age", "avgIncome", "prefersSuntrip", "prefersSoftPresent", "chocolatePref", "santaBelief", "itemID", "rating", "isExpensive", "priceGroup", "Category", "isFashionCat", "isSportsCat", "isElectronicsCat"},
                //Values = new string[,] { { } }
                ColumnNames = columnNames,
                Values = values
              }
            }
          },
          GlobalParameters = new Dictionary<string, string>() { }
        };
        
        const string apiKey = "";
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", apiKey);
        client.BaseAddress = new Uri("https://europewest.services.azureml.net/workspaces/0c8371e1485946f48a61b4bdd4f07c2c/services/f9b6186cce7642b59fdc1ad4e2d22768/execute?api-version=2.0&details=true");

        // result = await DoSomeTask().ConfigureAwait(false)

        HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

        if (response.IsSuccessStatusCode)
        {
          string result = await response.Content.ReadAsStringAsync();
        }
      }
    }
  }

  public class StringTable
  {
    public string[] ColumnNames { get; set; }
    public string[,] Values { get; set; }
  }
}
