using UnityEngine;
using System.Threading.Tasks;

public class IPDataAPIClient : MonoBehaviour
{
    private APIClient apiClient;

    private void Start()
    {
        apiClient = GetComponent<APIClient>();
    }

    private async Task<IPData> FetchAndLogData()
    {
        apiClient.SetApiURL("https://api.ipify.org?format=json");

        string data = await apiClient.GetDataFromAPIAsync();
        
        IPData ipData = JsonUtility.FromJson<IPData>(data);

        Debug.Log("IP: " + ipData.ip);

        return ipData;
    }

    public async Task<IPData> GetIPData()
    {
        IPData ipData = await FetchAndLogData();

        return ipData;
    }

    [System.Serializable]
    public class IPData
    {
        public string ip;
    }
}