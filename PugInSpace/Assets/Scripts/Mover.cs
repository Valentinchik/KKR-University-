using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	public bool background;

	void Start() {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		if(background)GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,1) * speed;
	}
}
