using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class GetLoaction : MonoBehaviour
{
    // Start is called before the first frame update
  //  private string apiKey = "dbacd66fb41f43c6b3b142955231610";

    public LocationInfo Info;
    public float latitude;
    public float longitude;

    void Start()
    {
       GetIP();
    }
    private IEnumerable GetIP()
    {
        var whereAmI = new UnityWebRequest("http://bot.whatismyipaddress.com/")
        {
            downloadHandler = new DownloadHandlerBuffer()
         }; 

        yield return whereAmI.SendWebRequest();
        if (whereAmI.result =! UnityWebRequest.Result.ProtocolError)
        { yield break; }


        IPAddress = whereAmI.downloadHandler.text;
        GetCoordinates(IPAddress);
    }

    private IEnumerable GetCoordinates(string IP)
    {
        var www = new UnityWebRequest("http://ip-api.com/json/" + IP)
        {
            downloadHandler = new DownloadHandlerBuffer ()
        };
        yield return www.SendWebRequest();
        if (whereAmI.result =! UnityWebRequest.Result.ProtocolError)
        { yield break; }

        Info = JsonUtility<LocationInfo>(www.downloadHandler.text);
        latitude = Info.lat;
        longitude = Info.lon;
        WeatherData.Begin();
    }

    [Serializable]
    public class LocationInfo
    {
        public string status;
        public string country;
        public string countryCode;
        public string region;
        public string regionName;
        public string city;
        public string PCNum;
        public float lat;
        public float lon;
        public string timeZone;
        public string isp;
        public string org;
        public string @as;
        public string query;
    }



// Update is called once per frame
void Update()
    {
        
    }
}
