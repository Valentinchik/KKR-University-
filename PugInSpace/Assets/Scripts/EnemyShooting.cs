using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {
	public float minDamage, maxDamage;
	private GameController gameController;
	public GameObject explosion;
	public GameObject playerExplosion;
	public Health health;
	public Health enemyAI ;
	void Awake()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	void Start() {

		GameObject healthObject = GameObject.FindWithTag ("Player");
		if (healthObject != null) {
			health = healthObject.GetComponent <Health> ();
		}
		if (health == null) {
			gameController.GameOver();
		}
		GameObject enemyAIObject = GameObject.FindWithTag ("Player");
		enemyAI = enemyAIObject.GetComponent <Health>();

	
	}
	public void Updtae()
	{
		
	}
	
	void OnTriggerEnter(Collider other) {
		//Instantiate (explosion, transform.position, transform.rotation);
		
		if (other.tag == "Player") {Instantiate (explosion, transform.position, transform.rotation);
			health.currentHealth = health.currentHealth - Random.Range(minDamage, maxDamage)/health.armor;
			
			if(gameController.dead == true){
				Instantiate (playerExplosion, transform.position, transform.rotation);
				gameController.GameOver();}
		}

	}
}