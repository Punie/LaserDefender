using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public float m_MaxHealth = 100f;

	private float m_CurrentHealth;
	private bool m_IsDead;

	private void Awake ()
	{
		
	}

	private void OnEnable ()
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
}
