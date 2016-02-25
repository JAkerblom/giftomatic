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
using Newtonsoft.Json.Linq;

namespace Giftomatic.Data
{
  public class AzureService
  {
    PredictionDataContext _ctx;
    string[,] _azureModels = new string[,]
    {
      {
        "JUgZsn+BJImk6tSKqPuiaIH1WaVo+J9n+px6qNb4qnLP2K0C9d3Oubkaurhmg+k9SVxA3qXQ3Q4haBoFp6D6BA==",
        "https://europewest.services.azureml.net/workspaces/0c8371e1485946f48a61b4bdd4f07c2c/services/cff0e9af2b8e44b0b57af48ffa8c9e5f/execute?api-version=2.0&details=true"
      }      
    };


    public AzureService (PredictionDataContext ctx)
    {
      _ctx = ctx;
    }

    //string GetPrediction(UserFeatureSet ufs, ItemFeatureSet ifs, ExternalFeatureSet efs)
    public JObject GetPrediction(PredictionData data, int modelNr)
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

      //string apiKey = "JUgZsn+BJImk6tSKqPuiaIH1WaVo+J9n+px6qNb4qnLP2K0C9d3Oubkaurhmg+k9SVxA3qXQ3Q4haBoFp6D6BA==";
      //string uri = "https://europewest.services.azureml.net/workspaces/0c8371e1485946f48a61b4bdd4f07c2c/services/f9b6186cce7642b59fdc1ad4e2d22768/execute?api-version=2.0&details=true";
      string apiKey = _azureModels[modelNr, 1];
      string uri = _azureModels[modelNr, 2];
      InvokeRequestResponseService(columnNames, values).Wait();

      string result = PostJsonAsync(uri, apiKey, columnNames, values).Result;
      
      return JObject.Parse(result);
    }

    public JObject GetPrediction(UserFeatureSet u, int modelNr)
    {
      string result = PostJsonAsync("", "", new string[] { }, new string[,] { { } }).Result;

      return JObject.Parse(result);
    }

    public JObject GetPrediction(ASUserFeatureSet u, int modelNr)
    {
      string[] columnNames = {
        "zip",
        "age",
        "sexType",
        "prefersSoftPresents",
        "prefersSuntrip",
        "prefersDog",
        "santaBelief",
        "chocolatePref",
        "candyPref",
        "kallePref",
        "likesFood1",
        "likesFood2",
        "likesFood3",
        "likesFood4",
        "likesFood5",
        "likesFood6",
        "likesFood7",
        "likesFood8",
        "likesFood9",
        "likesFood10",
        "likesFood11",
        "likesFood12"
      };

      //IDictionary<string, object> dataToDictionary = usf.AsDictionary();

      string[] value = {
        u.Zip,
        u.Age.ToString(),
        u.SexType,
        u.PrefersSoftPresent.ToString(),
        u.PrefersSuntrip.ToString(),
        u.PrefersDog.ToString(),
        u.SantaBelief.ToString(),
        u.ChocolatePref,
        u.CandyPref,
        u.KallePref,
        u.LikesFood1.ToString(),
        u.LikesFood1.ToString(),
        u.LikesFood2.ToString(),
        u.LikesFood3.ToString(),
        u.LikesFood4.ToString(),
        u.LikesFood5.ToString(),
        u.LikesFood6.ToString(),
        u.LikesFood7.ToString(),
        u.LikesFood8.ToString(),
        u.LikesFood9.ToString(),
        u.LikesFood10.ToString(),
        u.LikesFood11.ToString(),
        u.LikesFood12.ToString(),
      };

      string[,] values = new string[,] { 
        {
          "21771",
          "25",
          "male",
          "0",
          "0",
          "1",
          "0",
          "dark",
          "kola",
          "robin-hood",
          "1",
          "1",
          "1",
          "0",
          "1",
          "1",
          "0",
          "0",
          "0",
          "0",
          "0",
          "1"
        }
      };

      //string requestBody = 
      for (int i = 0; i < 3; i++)
      {

      }

      //string apiKey = "JUgZsn+BJImk6tSKqPuiaIH1WaVo+J9n+px6qNb4qnLP2K0C9d3Oubkaurhmg+k9SVxA3qXQ3Q4haBoFp6D6BA==";
      //string uri = "https://europewest.services.azureml.net/workspaces/0c8371e1485946f48a61b4bdd4f07c2c/services/f9b6186cce7642b59fdc1ad4e2d22768/execute?api-version=2.0&details=true";
      string apiKey = _azureModels[modelNr-1, 1];
      string uri = _azureModels[modelNr-1, 2];
      //InvokeRequestResponseService(columnNames, values).Wait();

      string result = PostJsonAsync(uri, apiKey, columnNames, values).Result;

      return JObject.Parse(result);
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
                //Values = new string[,] { {x } }
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

    // removed static. Don't know how it affects in this situation.
    public async Task InvokeRequestResponseService(string[] columnNames, string[,] values)
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
