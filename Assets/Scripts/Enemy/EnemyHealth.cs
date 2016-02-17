using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
	public float m_MaxHealth = 30f;

	private float m_CurrentHealth;
	private bool m_IsDead;

	private void Awake ()
	{
		
	}

	private void Start ()
	{
		m_CurrentHealth = m_MaxHealth;
		m_IsDead = false;
	}

	public void TakeDamage (float amount)
	{
		m_CurrentHealth -= amount;

		if (m_CurrentHealth <= 0f && !m_IsDead)
			OnDeath ();
	}

	private void OnDeath ()
	{
		m_IsDead = true;
		Destroy (gameObject);
	}

//	public float m_MaxHealth = 10f;
//	public GameObject m_Projectile;
//	public float m_ProjectileSpeed = 15f;
//	public float m_ShotsPerSecond = 0.5f;
//
//	private float m_CurrentHealth;
//
//	void Start ()
//	{
//		m_CurrentHealth = m_MaxHealth;
//	}
//
//	void Update ()
//	{
//		float prob = Time.deltaTime * m_ShotsPerSecond;
//
//		if (Random.value < prob)
//			Fire ();
//	}
//
//	void OnTriggerEnter2D (Collider2D col)
//	{
//		Projectile projectile = col.gameObject.GetComponent<Projectile> ();
//
//		if (projectile)
//		{
//			GetHit (projectile);
//		}
//	}
//
//	void GetHit (Projectile projectile)
//	{
//		m_CurrentHealth -= projectile.GetDamage ();
//		if (m_CurrentHealth <= 0f)
//			Destroy (gameObject);
//		projectile.Hit ();
//	}
//
//	void Fire ()
//	{
//		GameObject projectile = Instantiate (m_Projectile, transform.position, Quaternion.identity) as GameObject;
//		Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D> ();
//
//		projectileRigidbody.velocity = new Vector3 (0f, -m_ProjectileSpeed);
//	}
}
