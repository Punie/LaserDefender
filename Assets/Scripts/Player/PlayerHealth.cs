using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public float m_MaxHealth = 100f;
	public AudioClip m_DamageAudioClip;
	public AudioClip m_DeathAudioClip;
	public Sprite[] m_DamageSprites;

	private float m_CurrentHealth;
	private bool m_IsDead;
	private PlayerDamageDisplay m_PlayerDamageDisplay;


	private void Awake ()
	{
		m_PlayerDamageDisplay = GetComponentInChildren<PlayerDamageDisplay> ();
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

		EnableDamageSprite (m_CurrentHealth / m_MaxHealth);

		AudioSource.PlayClipAtPoint (m_DamageAudioClip, transform.position);
	}

	private void EnableDamageSprite (float health)
	{
		if (health <= 0.25f)
			m_PlayerDamageDisplay.ChangeSprite (m_DamageSprites [2]);
		else if (health <= 0.5f)
			m_PlayerDamageDisplay.ChangeSprite (m_DamageSprites [1]);
		else if (health <= 0.75f)
			m_PlayerDamageDisplay.ChangeSprite (m_DamageSprites [0]);
		else
			m_PlayerDamageDisplay.ChangeSprite (null);
	}

	private void OnDeath ()
	{
		m_IsDead = true;
		AudioSource.PlayClipAtPoint (m_DeathAudioClip, transform.position);
		Destroy (gameObject);
	}
}
