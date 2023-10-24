using System;
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
                StartCoroutine("GetWeatherInfo");
                timer = minuetsBetweenUpdate * 60;
            }
            else { timer -= Time.deltaTime;  }
           
        }
    }
    
    private IEnumerator GetWeatherInfo()
    {
        var www = new UnityWebRequest();  
    }

    [Serializable]
    public class WeatherInfo()
    { 
        public float latitude;
        public float longitude;
        public string timezone;
        public Current currently;
        public int offset;
    }

    [Serializable]
    public class Current
    {
        public string lastUpdated;
        public 

    }

}
