using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class WeatherAPI : MonoBehaviour
{
    // Start is called before the first frame update
    private string apiKey = "dbacd66fb41f43c6b3b142955231610";
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
        if (whereAmI.result == UnityWebRequest.Result.ProtocolError)
        { yield break; }
    }




// Update is called once per frame
void Update()
    {
        
    }
}
