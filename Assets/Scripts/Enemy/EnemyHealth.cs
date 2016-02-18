using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
	public float m_MaxHealth = 30f;
	public int m_ScoreValue = 25;
	public AudioClip m_DeathAudioClip;

	private float m_CurrentHealth;
	private bool m_IsDead;
	private ScoreKeeper m_ScoreKeeper;

	private void Awake ()
	{
		m_ScoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
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
		m_ScoreKeeper.Score (m_ScoreValue);
		AudioSource.PlayClipAtPoint (m_DeathAudioClip, transform.position);
		Destroy (gameObject);
	}
}
