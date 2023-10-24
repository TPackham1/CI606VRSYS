using System;
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

    private string IPAddress;

    void Start()
    {
        StartCoroutine("GetIP");
    }
    private IEnumerable GetIP()
    {
        var www = new UnityWebRequest("http://bot.whatismyipaddress.com/")
        {
            downloadHandler = new DownloadHandlerBuffer()
         }; 

        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.ProtocolError)
        { yield break; }


        IPAddress = www.downloadHandler.text;
        // GetCoordinates(IPAddress);


        StartCoroutine("GetCoordinates");
    }

    private IEnumerable GetCoordinates()
    {
        var www = new UnityWebRequest("http://ip-api.com/json/" + IPAddress)
        {
            downloadHandler = new DownloadHandlerBuffer ()
        };
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.ProtocolError)
        { yield break; }

        Info = JsonUtility.FromJson<LocationInfo>(www.downloadHandler.text);
        latitude = Info.lat;
        longitude = Info.lon;
        WeatherData.Begin();
    }

     [Serializable]
    public class LocationInfo
    {
        // public string status;
        public string name;
        public string region;
        public string country;
        
       // public string regionName;
      //  public string city;
       // public string PCNum;
        public float lat;
        public float lon;
        public string tz_id;
       // public string isp;
        public float locationtime_epoch;
        public string localtime;
        //public string query;
    }



// Update is called once per frame
void Update()
    {
        
    }
}
