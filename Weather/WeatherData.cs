using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WeatherData : MonoBehaviour
{
    public GetLocation getLocation;
    private float latitude;
    private float longitude;
    private bool locationInitialized;
    private float timer;
    public float minuetsBetweenUpdate;


    public string apiKey;



    public void Begin()
    {
        latitude = getLocation.latitude;
        longitude = getLocation.longitude;
        locationInitialized = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (locationInitialized)
        {
            if (timer <= 0)
            {
                GetWeatherInfo();
                timer = minuetsBetweenUpdate * 60;
            }
            else { timer -= Time.deltaTime;  }
        }
    }

    private IEnumerator GetWeatherInfo()
    { 
        
    }
    
}
