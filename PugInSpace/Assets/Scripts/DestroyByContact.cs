using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public bool enemy;
	public bool player;

	//public Health health;

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;
	//public float minDamage, maxDamage;


	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (enemy && other.tag != "Player") {return;
		}
		if (enemy && other.tag == "Player") {
			Instantiate (playerExplosion, transform.position, transform.rotation);
			gameController.GameOver();
		}

		if (other.tag == "Boundary") {
			return;
		}
		if (player&&other.tag == "enemyWeapon") {return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player"&&other.tag != "enemyWeapon") {
			Instantiate (playerExplosion, transform.position, transform.rotation);
			gameController.GameOver();
		}



		if (other.tag != "Player")gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);

	}
}
