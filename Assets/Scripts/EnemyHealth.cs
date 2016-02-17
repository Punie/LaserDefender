using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
	public float m_MaxHealth = 10f;

	private float m_CurrentHealth;

	void Start ()
	{
		m_CurrentHealth = m_MaxHealth;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		Projectile projectile = col.gameObject.GetComponent<Projectile> ();

		if (projectile)
		{
			GetHit (projectile);
		}
	}

	void GetHit (Projectile projectile)
	{
		m_CurrentHealth -= projectile.GetDamage ();
		if (m_CurrentHealth <= 0f)
			Destroy (gameObject);
		projectile.Hit ();
	}
}
