using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Collections;
using System;

public class APIClient : MonoBehaviour
{
    private string apiUrl;
  // WeatherDataAPIClient weatherDataAPIClient;
   // IPDataAPIClient ipDataAPIClient;
    // LonLatDataAPIClient lonLatDataAPIClient;

    public async Task<string> GetDataFromAPIAsync()
    {
        // Create a task completion source to convert the Unity coroutine to a task.
        TaskCompletionSource<string> taskCompletionSource = new();

        StartCoroutine(GetDataFromAPI(taskCompletionSource));

        try
        {
            string data = await taskCompletionSource.Task;
            if (!string.IsNullOrEmpty(data))
            { 
                Debug.Log("Received Data: " + data);
                return data;
            }
            else
            {
                Debug.LogWarning("No data received.");
                return "";
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error fetching data: " + e.Message);
            return null;
        }
    }

    public void SetApiURL(string newApiURL)
    {
        apiUrl = newApiURL;
    }

    private IEnumerator GetDataFromAPI(TaskCompletionSource<string> tcs)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(apiUrl))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError
                || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + request.error);
                tcs.SetResult(string.Empty); // Set the result to an error or an appropriate default value
            }
            else
            {
                string data = request.downloadHandler.text;
                tcs.SetResult(data); // Set the result to the API response data
            }
        }
    }
}