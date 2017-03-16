using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public float minDamage, maxDamage;
	//private GameController gameController;
	public GameObject explosion;
	//public GameObject playerExplosion;
	public Health health;
	public EnemyAI enemyAI;
	public PlayerStats playerStats;

	//public int enemyType;
	public int scoreValue;
	private GameController gameController;
	
	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
		
		GameObject playerStatsObject = GameObject.FindWithTag ("Player");
		playerStats = playerStatsObject.GetComponent <PlayerStats>();
		
		
	
	}
	public void Updtae()
	{
		
	}
	
	void OnTriggerEnter(Collider other) {


		if (other.tag == "Player") {
			return;}
		if (other.tag == "enemy") {Instantiate (explosion, transform.position, transform.rotation);
			GameObject healthObject = GameObject.FindWithTag ("enemy");
			health = healthObject.GetComponent <Health>();
			//health.currentHealth = health.currentHealth - Random.Range(minDamage, maxDamage);

			GameObject enemyAIObject = GameObject.FindWithTag ("enemy");
			enemyAI = enemyAIObject.GetComponent <EnemyAI>();
			health.currentHealth = health.currentHealth - playerStats.FlightSkills*Random.Range(minDamage, maxDamage)/health.armor;
			if (enemyAI.enemyType == 1) {
				scoreValue = 100 * enemyAI.enemyType;
			}
		     if (enemyAI.enemyType == 2) {
				scoreValue = 100*enemyAI.enemyType;
			}
		     if (enemyAI.enemyType == 3) {
				scoreValue = 100*enemyAI.enemyType;
			}
			if(health.currentHealth<=1)
			{
				gameController.AddScore (scoreValue);
			}
		}
	}
}