using UnityEngine;
using System.Collections;

public class GenerateLevel : MonoBehaviour {

	public GameObject[] level;
	public GameObject[] spawnPoint; 
	public SpawnControl[] delete; 
	// Use this for initialization
	void Start () {


			for (int i=0; i<spawnPoint.Length; i++) {
Instantiate (level [Random.Range (0, level.Length)], spawnPoint [Random.Range (0, spawnPoint.Length)].transform.position, spawnPoint [Random.Range (0, spawnPoint.Length)].transform.rotation);
			//delete = new GameObject[6];
			//delete[]=delete[i];
			
		}
	}
	
	// Update is called once per frame
	void Update () {int i;
		GameObject[] del = GameObject.FindGameObjectsWithTag("level");
		delete = new SpawnControl[del.Length];
		for (i = 0; i < del.Length; i++) {
			delete [i] = del [i].GetComponent<SpawnControl> ();

		}
		for (i = 0; i < del.Length+2; i++) {
			if(delete[i].transform.position==delete[i+1].transform.position||delete[i].transform.position==delete[i+2].transform.position||
			   delete[i].transform.position==delete[i+3].transform.position||delete[i].transform.position==delete[i+4].transform.position||delete[i].transform.position==delete[i+5].transform.position){Debug.Log ("ooops"); Destroy(delete[i].gameObject);}
		
		}


	}
}
