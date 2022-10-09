
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
	public int maxHealth = 4;
	public int currentHealth;

	public HealthBar healthBar;
	public static PlayerHealth instance;
		


	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log(collision.transform.name);
		if (collision.gameObject.tag == "Projectile")
		{
			TakeDamage(1);
		
		}
	}
	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);

		if (currentHealth <= 0)
        {
			Destroy(gameObject);
			Debug.Log("Player DIED");
			
        }
	}
}
