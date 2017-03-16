using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	//public int PlanetType;
	public Health playerHealth;
	public GameObject[] hazards;
	public GameObject[] enemiesWeak;
	public GameObject[] enemiesMiddle;
	public GameObject[] enemiesStrong;
	public Vector3 spawnValues;
	public int hazardCount;
	public int enemiesCount;

	public float spawnWait;
	public float startWait;
	public float waveWait;

	public float enemySpawnWait;
	public float enemyStartWait;
	public float enemyWaveWait;


	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public int score;
	private bool gameOver;
	private bool restart;
	public bool dead;
	public int type = 0;
	public float timeLeft;

	void Start() {
		type = type+PlayerPrefs.GetInt ("PlanetType");
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnWaves ());
		StartCoroutine(SpawnEnemies ());
		if (type == 1)
			timeLeft = 40;
		if (type == 2)
			timeLeft = 50;
		if (type == 3)
			timeLeft = 60;
	}

	void Update() {

		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			if (PlayerPrefs.HasKey ("System1")) {
				Debug.Log ("Планета 1 пройдена");
				PlayerPrefs.SetInt("Planet1Done",1);
			}
			if (PlayerPrefs.HasKey ("System2"))
			{Debug.Log ("Планета 2 пройдена");
				PlayerPrefs.SetInt("Planet2Done",2);
		}
			if (PlayerPrefs.HasKey ("System21"))
			{Debug.Log ("Планета 21 пройдена");
				PlayerPrefs.SetInt("Planet2Done",21);
			}
			if (PlayerPrefs.HasKey ("System3"))
			{Debug.Log ("Планета 3 пройдена");
				PlayerPrefs.SetInt("Planet3Done",3);
			}
			if (PlayerPrefs.HasKey ("System4"))
			{Debug.Log ("Планета 4 пройдена");
				PlayerPrefs.SetInt("Planet4Done",4);
			}
			if (PlayerPrefs.HasKey ("System41"))
			{Debug.Log ("Планета 41 пройдена");
				PlayerPrefs.SetInt("Planet41Done",41);
			}
			if (PlayerPrefs.HasKey ("System5"))
			{Debug.Log ("Планета 5 пройдена");
				PlayerPrefs.SetInt("Planet5Done",5);
			}
			Application.LoadLevel("Menu");

		}



		if (restart) {
			if (Input.GetKeyDown(KeyCode.R)) {
				Application.LoadLevel(Application.loadedLevel);
				gameOver = false;
			}
		}
		if (playerHealth.currentHealth <= 1) {dead= true;
		}
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds(startWait);
		while(!restart) {
			for (int i = 0; i < hazardCount; ++i) {

				GameObject hazard = hazards [Random.Range (0, hazards.Length)];




				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
			if (gameOver) {
				restartText.text = "Press 'R' for restart";
				restart = true;
			}
		}
	}

	IEnumerator SpawnEnemies() {
		yield return new WaitForSeconds(enemyStartWait);
		while(!restart) {
			for (int j = 0; j < enemiesCount; ++j) {
				

				GameObject weakEnemy = enemiesWeak [Random.Range (0, enemiesWeak.Length)];
				GameObject midEnemy = enemiesMiddle [Random.Range (0, enemiesMiddle.Length)];
				GameObject strongEnemy = enemiesStrong [Random.Range (0, enemiesStrong.Length)];
				
				
			
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				if(type ==1)
				{Instantiate (weakEnemy , spawnPosition, spawnRotation);}
				else if(type ==2)
				{Instantiate (midEnemy, spawnPosition, spawnRotation);}
				else if(type ==3)
				{Instantiate (strongEnemy, spawnPosition, spawnRotation);}
				yield return new WaitForSeconds(enemySpawnWait);
			}
			yield return new WaitForSeconds(enemyWaveWait);
		}
	}

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	public void GameOver() {
		gameOver = true;
		gameOverText.text = "Game Over";
	}
}
