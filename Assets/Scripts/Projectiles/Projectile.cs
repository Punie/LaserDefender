using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public float m_Damage = 10f;


	private void OnTriggerEnter2D (Collider2D other)
	{
		PlayerHealth playerHealth = other.GetComponent<PlayerHealth> ();
		EnemyHealth enemyHealth = other.GetComponent<EnemyHealth> ();

		if (playerHealth)
		{
			playerHealth.TakeDamage (m_Damage);
			Destroy (gameObject);
		}
		else if (enemyHealth)
		{
			enemyHealth.TakeDamage (m_Damage);
			Destroy (gameObject);
		}
	}
}
