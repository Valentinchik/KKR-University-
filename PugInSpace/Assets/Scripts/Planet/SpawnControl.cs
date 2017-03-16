using UnityEngine;
using System.Collections;

public class SpawnControl : MonoBehaviour {
	public float maxDistance;
	public Vector3 pos1, pos2, pos3, pos4;
	public bool test;

	void Start()
	{
		//test = false;
		pos1 = transform.position + new Vector3(0.0f, 0.0f, 5.0f);
		pos2 = transform.position + new Vector3(0.0f, 0.0f, -5.0f);
		pos3 = transform.position + new Vector3(5.0f, 0.0f, 0.0f);
		pos4 = transform.position + new Vector3(-5.0f, 0.0f, 0.0f);
	}
	void Update()
	{

		Debug.DrawRay (pos1, Vector3.forward,Color.green,maxDistance);
		Debug.DrawRay (pos2, -Vector3.forward,Color.red,maxDistance);
		Debug.DrawRay (pos3, Vector3.right,Color.yellow,maxDistance);
		Debug.DrawRay (pos4, -Vector3.right,Color.blue,maxDistance);
		RaycastHit hit;
		//if (Physics.SphereCast (transform.position, 0.1f, Vector3.right, out hit,0.1f)){delete[0]=hit.transform.root.gameObject;Debug.Log ("1111");Destroy(delete[0].gameObject);}


		if (Physics.Raycast (pos1, Vector3.forward, out hit, maxDistance) && hit.collider.tag == "level"
			|| Physics.Raycast (pos2, -Vector3.forward, out hit, maxDistance) && hit.collider.tag == "level"
			|| Physics.Raycast (pos3, Vector3.right, out hit, maxDistance) && hit.collider.tag == "level"
		    || Physics.Raycast (pos4, -Vector3.right, out hit, maxDistance) && hit.collider.tag == "level") {test = true;
			Debug.Log ("попадание" + hit.collider.tag);
		} 
		if (test != true) {
			Debug.Log ("тікаймо хлопці, це пекло");
			Destroy (gameObject);
		}
	}
	void onTriggerEnter(Collider other)
	{Debug.Log (other.tag);
		if (other.tag == "level") {
			Destroy (gameObject);
		}
	}
}