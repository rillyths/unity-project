using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weather : MonoBehaviour {
    // Created Apr 3, 2017 by rillyths


    public WeatherState CurrentWeather;             // The current weather state
    public Season CurrentSeason;                    // The current season

    [SerializeField]
    int _temperature;                               // The temperature
                                                    // To be used later for precipitation,
                                                    // plants or crops, & animals


	// Use this for initialization
	void Start () {
        _temperature = 70;
        CurrentSeason = Season.Summer;
        CurrentWeather = WeatherState.Unknown;
        StartCoroutine("WeatherCycle");
	}

    // A finite state machine to control the weather
    IEnumerator WeatherCycle()
    {
        while(true)
        {
            switch(CurrentWeather)
            {
                // Call the corresponding weather function for the CurrentWeather
                case WeatherState.Sunny:
                    Sunny();
                    break;
                case WeatherState.Cloudy:
                    Cloudy();
                    break;
                case WeatherState.Rainy:
                    Rainy();
                    break;
                default:
                    GenerateWeather();                      // If CurrentWeather is invalid,
                    Debug.Log("Unrecognized weather");      // regenerate the weather
                    break;
            }
            yield return null;
        }
    }

    // Generate random weather phenomena & set the temperature
    public void GenerateWeather()
    {
        int low;                                        // The lowest the temperature can be
        int high;                                       // The highest the temp can be
        int margin;                                     // Randomized int to increase/decrease
                                                        // the highs & lows for temperature

        CurrentWeather = (WeatherState)Random.Range(1, 4);
        // Randomize the weather
        // Note: Update later! Maybe use a humidity value?

        switch (CurrentWeather)
        {
            case WeatherState.Sunny:
                margin = Random.Range(-6, 21);          // Sunny weather is warmer
                break;
            case WeatherState.Cloudy:
                margin = Random.Range(-15, 6);          // Cloudy weather is colder
                break;
            case WeatherState.Rainy:
                margin = Random.Range(-10, 10);         // Rainy weather is neutral
                break;
            default:                                    // Default if weather is invalid
                margin = 0;
                break;
        }
        Debug.Log(margin + " as extremity");

        switch (CurrentSeason)
        {
            // Each season has different high/low temperatures,
            // so change the high & low based on the current season
            // Then add the margin for additional variety
            case Season.Summer:
                low = 68 + margin;
                high = 87 + margin;
                break;
            case Season.Fall:
                low = 51 + margin;
                high = 71 + margin;
                break;
            case Season.Winter:
                low = 30 + margin;
                high = 51 + margin;
                break;
            case Season.Spring:
                low = 48 + margin;
                high = 69 + margin;
                break;
            default:
                low = 40;
                high = 60;
                break;
        }
        
        _temperature = (Random.Range(low, high + 1) + _temperature) / 2;
        // Grab a randomized integer based on the high & low values
        // then average it with the current temperature's value
        // This is to prevent temperature from jumping around wildly
        // So that going from 62 to 104 will actually result in 83, not 104
    }

    #region Weather functions
    void Sunny()
    {
        // Put particles, audio, etc for sunny weather here
    }

    void Cloudy()
    {
        // Put particles, audio, etc for cloudy weather here
    }

    void Rainy()
    {
        // Put particles, audio, etc for rainy weather here
    }
    #endregion
}

public enum WeatherState
{
    Unknown,            // If the weather is Unknown, either initialization or
    Sunny,              // weather generation was not done as intended
    Cloudy,
    Rainy
}

// Include Early Summer/Midsummer/Late Summer, etc as separate seasons?
public enum Season
{
    Summer,
    Fall,
    Winter,
    Spring
}