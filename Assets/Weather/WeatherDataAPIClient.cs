using UnityEngine;
using static LonLatDataAPIClient;
using System.Threading.Tasks;

public class WeatherDataAPIClient : MonoBehaviour
{
    private APIClient apiClient;
    private LonLatDataAPIClient lonLatDataApiClient;

    private void Start()
    {
        apiClient = GetComponent<APIClient>();
        lonLatDataApiClient = GetComponent<LonLatDataAPIClient>();

        GetWeatherData();
    }

    private async Task<WeatherData> FetchAndLogData()
    {
        LonLatData lonLatData = await lonLatDataApiClient.GetLonLatData();

        string apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={lonLatData.lat}&longitude={lonLatData.lon}&current=temperature_2m,is_day,rain,snowfall,windspeed_10m&forecast_days=1";

        apiClient.SetApiURL(apiUrl);

        string data = await apiClient.GetDataFromAPIAsync();

        WeatherData weatherData = JsonUtility.FromJson<WeatherData>(data);

        Debug.Log($"Rain: {weatherData.current.rain}{weatherData.current_units.rain}");
        Debug.Log($"Snowfall: {weatherData.current.snowfall}{weatherData.current_units.snowfall}");
        Debug.Log($"Windspeed (10m): {weatherData.current.windspeed_10m}{weatherData.current_units.windspeed_10m}");

        return weatherData;
    }

    public async Task<WeatherData> GetWeatherData()
    {
        WeatherData weatherData = await FetchAndLogData();

        return weatherData;
    }

    [System.Serializable]
    public class WeatherData
    {
        public float latitude;
        public float longitude;
        public float generationtime_ms;
        public int utc_offset_seconds;
        public string timezone;
        public string timezone_abbreviation;
        public float elevation;

        public CurrentUnits current_units;
        public Current current;

        [System.Serializable]
        public class CurrentUnits
        {
            public string time;
            public string interval;
            public string temperature_2m;
            public string is_day;
            public string rain;
            public string snowfall;
            public string windspeed_10m;
        }

        [System.Serializable]
        public class Current
        {
            public string time;
            public int interval;
            public float temperature_2m;
            public int is_day;
            public float rain;
            public float snowfall;
            public float windspeed_10m;
        }
    }
}
