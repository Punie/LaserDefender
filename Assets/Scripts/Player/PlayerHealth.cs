using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public float m_MaxHealth = 100f;
	public AudioSource m_DamageAudio;
	public AudioClip m_DeathAudioClip;

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

		m_DamageAudio.Play ();
	}

	private void OnDeath ()
	{
		m_IsDead = true;
		AudioSource.PlayClipAtPoint (m_DeathAudioClip, transform.position);
		Destroy (gameObject);
	}
}
