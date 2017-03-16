using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float fullHealth;
	public float currentHealth;
	public bool dead;
	public float armor;
	public void Start()
	{
		currentHealth = fullHealth;
	}



	public void Update()
	{
		if (currentHealth <= 0) 
		{
			dead=true;
			Destroy(gameObject);
		}
	}
}
