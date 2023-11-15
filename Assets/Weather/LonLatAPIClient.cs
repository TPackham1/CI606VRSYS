using UnityEngine;
using System.Threading.Tasks;
using static IPDataAPIClient;

public class LonLatDataAPIClient : MonoBehaviour
{
    private APIClient apiClient;
    private IPDataAPIClient ipDataApiClient;

    private void Start()
    {
        apiClient = GetComponent<APIClient>();
        ipDataApiClient = GetComponent<IPDataAPIClient>();
    }

    private async Task<LonLatData> FetchAndLogData()
    {
        IPData ipData = await ipDataApiClient.GetIPData();

        string apiUrl = $"http://ip-api.com/json/{ipData.ip}";

        apiClient.SetApiURL(apiUrl);

        string data = await apiClient.GetDataFromAPIAsync();

        LonLatData lonLatData = JsonUtility.FromJson<LonLatData>(data);

        Debug.Log("Lat: " + lonLatData.lat);
        Debug.Log("Lon: " + lonLatData.lon);

        return lonLatData;
    }

    public async Task<LonLatData> GetLonLatData()
    {
        LonLatData lonLatData = await FetchAndLogData();

        return lonLatData;
    }

    [System.Serializable]
    public class LonLatData
    {
        public string query;
        public string status;
        public string country;
        public string countryCode;
        public string region;
        public string regionName;
        public string city;
        public string zip;
        public float lat;
        public float lon;
        public string timezone;
        public string isp;
        public string org;
    }
}