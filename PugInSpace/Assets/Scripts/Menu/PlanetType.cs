using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class PlanetType : MonoBehaviour {
	public bool pl1, pl2, pl21,pl3,pl4,pl41,pl5;
	public Button b1, b2, b21, b3, b4, b41, b5;

	public Image image;
	public int type ;

	//public int planetType1 ;
	//public int planetType2 ;
	//public bool menButton;

	[ContextMenu("clear prefs")]
	public void ClearPrefs()
	{
		PlayerPrefs.DeleteAll();
	}

	public void Control()
	{
		b1.gameObject.SetActive (true);
		b2.gameObject.SetActive (true);
		b21.gameObject.SetActive (true);
		b3.gameObject.SetActive (true);
		b4.gameObject.SetActive (true);
		b41.gameObject.SetActive (true);
		b5.gameObject.SetActive (true);

		b1.interactable = true;
		b2.interactable = false;
		b21.interactable = false;
		b3.interactable = false;
		b4.interactable = false;
		b41.interactable = false;
		b5.interactable = false;

	}
	public void changeColor()
	{
		if (PlayerPrefs.HasKey ("Planet1Done")) {
			b1.interactable = false;
			b2.interactable = true;
			b21.interactable = true;
		}
		if (PlayerPrefs.HasKey ("Planet2Done")) {
			b2.interactable = false;
			b21.interactable = false;
			b3.interactable = true;
		}
		if (PlayerPrefs.HasKey ("Planet21Done")) {
			b2.interactable = false;
			b21.interactable = false;
			b3.interactable = true;
		}
		if (PlayerPrefs.HasKey ("Planet3Done")) {
			b4.interactable = true;
			b41.interactable = true;
			b3.interactable = false;
		}

		if (PlayerPrefs.HasKey ("Planet4Done")) {
			b4.interactable = false;
			b41.interactable = false;
			b5.interactable = true;
		}
		if (PlayerPrefs.HasKey ("Planet41Done")) {
			b4.interactable = false;
			b41.interactable = false;
			b5.interactable = true;
		}

		if (PlayerPrefs.HasKey ("Planet5Done")) {

			b5.interactable = false;
		}


		if (pl1&&PlayerPrefs.HasKey ("PlanetType1")) {

				type = PlayerPrefs.GetInt ("PlanetType1");
				Debug.Log (PlayerPrefs.GetInt ("PlanetType1"));

		}
		else if (pl2&&PlayerPrefs.HasKey ("PlanetType2"))
		{

				type = PlayerPrefs.GetInt ("PlanetType2");
				Debug.Log (PlayerPrefs.GetInt ("PlanetType2"));

		}
		else if (pl21&&PlayerPrefs.HasKey ("PlanetType21"))
		{
			
			type = PlayerPrefs.GetInt ("PlanetType21");
			Debug.Log (PlayerPrefs.GetInt ("PlanetType21"));
			
		}

		else if (pl3&&PlayerPrefs.HasKey ("PlanetType3"))
		{
			
			type = PlayerPrefs.GetInt ("PlanetType3");
			Debug.Log (PlayerPrefs.GetInt ("PlanetType3"));
			
		}
		else if (pl4&&PlayerPrefs.HasKey ("PlanetType4"))
		{
			
			type = PlayerPrefs.GetInt ("PlanetType4");
			Debug.Log (PlayerPrefs.GetInt ("PlanetType4"));
			
		}
		else if (pl41&&PlayerPrefs.HasKey ("PlanetType41"))
		{
			
			type = PlayerPrefs.GetInt ("PlanetType41");
			Debug.Log (PlayerPrefs.GetInt ("PlanetType41"));
			
		}

		else if (pl5&&PlayerPrefs.HasKey ("PlanetType5"))
		{
			
			type = PlayerPrefs.GetInt ("PlanetType5");
			Debug.Log (PlayerPrefs.GetInt ("PlanetType5"));
			
		}
		else {type = UnityEngine.Random.Range (1, 4);}
		if (type == 1) {
				GetComponent<Image> ().color = Color.green;
			}
		if (type == 2) {
				GetComponent<Image> ().color = Color.yellow;
			}
		if (type == 3) {
				GetComponent<Image> ().color = Color.red;
			}

	
}
	public void SetType()
	{
		PlayerPrefs.SetInt ("PlanetType",type);
		Debug.Log (PlayerPrefs.GetInt ("PlanetType"));
		if(pl1)PlayerPrefs.SetInt ("System1", 1);
		if(pl2)PlayerPrefs.SetInt ("System2", 2);
		if(pl21)PlayerPrefs.SetInt ("System21", 21);
		if(pl3)PlayerPrefs.SetInt ("System3", 3);
		if(pl4)PlayerPrefs.SetInt ("System4", 4);
		if(pl41)PlayerPrefs.SetInt ("System41", 41);
		if(pl5)PlayerPrefs.SetInt ("System5", 5);
	}

	public void SetType1()
	{
		PlayerPrefs.SetInt ("PlanetType1", type);

		Debug.Log (PlayerPrefs.GetInt ("PlanetType1"));
	}

	public void SetType2()
	{
		PlayerPrefs.SetInt ("PlanetType2", type);
		Debug.Log (PlayerPrefs.GetInt ("PlanetType2"));

	}
	public void SetType21()
	{
		PlayerPrefs.SetInt ("PlanetType21", type);
		Debug.Log (PlayerPrefs.GetInt ("PlanetType21"));
		
	}
	public void SetType3()
	{
		PlayerPrefs.SetInt ("PlanetType3", type);
		Debug.Log (PlayerPrefs.GetInt ("PlanetType3"));
		
	}

	public void SetType4()
	{
		PlayerPrefs.SetInt ("PlanetType4", type);
		Debug.Log (PlayerPrefs.GetInt ("PlanetType4"));
		
	}
	public void SetType41()
	{
		PlayerPrefs.SetInt ("PlanetType41", type);
		Debug.Log (PlayerPrefs.GetInt ("PlanetType41"));
		
	}
	public void SetType5()
	{
		PlayerPrefs.SetInt ("PlanetType5", type);
		Debug.Log (PlayerPrefs.GetInt ("PlanetType5"));
		
	}
	public void StartFlight()
	{
		Application.LoadLevel("Main") ;
	}
}