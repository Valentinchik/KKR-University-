using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	private GameController gameController;

	public int Level;

	public int FlightSkills;
	// Use this for initialization
	void Start () {if (PlayerPrefs.HasKey ("FlightSkills"))FlightSkills = PlayerPrefs.GetInt ("FlightSkills");
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gameController.score >= 1000) 
		{
			Level = Level+1;
			FlightSkills = FlightSkills+Level*10;
			PlayerPrefs.SetInt("FlightSkills",FlightSkills);
			gameController.score= 0;
		}
	
	}
}
