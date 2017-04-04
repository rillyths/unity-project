using UnityEngine;

public class TesterScript : MonoBehaviour {
    Weather theWeather;


	// Use this for initialization
	void Start () {
        theWeather = GameObject.Find("Sun").GetComponent<Weather>();
    }

    private void OnGUI()
    {
        // Generate a new forecast for the weather
        if (GUILayout.Button("New Weather"))
        {
            if (theWeather != null) theWeather.GenerateWeather();
        }

        // Change the season
        if (GUILayout.Button("Summer"))
        {
            if (theWeather != null) theWeather.CurrentSeason = Season.Summer;
        }
        if (GUILayout.Button("Fall"))
        {
            if (theWeather != null) theWeather.CurrentSeason = Season.Fall;
        }
        if (GUILayout.Button("Winter"))
        {
            if (theWeather != null) theWeather.CurrentSeason = Season.Winter;
        }
        if (GUILayout.Button("Spring"))
        {
            if (theWeather != null) theWeather.CurrentSeason = Season.Spring;
        }
    }
}
