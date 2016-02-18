using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour
{
	public Rigidbody2D m_Projectile;
	public Transform m_FireTransform;
	public float m_ProjectileSpeed = 10f;
	public float m_ShotsPerSecond = 0.5f;
	public AudioClip m_FireAudioClip;


	private void Update ()
	{
		float prob = Time.deltaTime * m_ShotsPerSecond;

		if (Random.value < prob)
			Fire ();
	}

	private void Fire ()
	{
		Rigidbody2D projectileInstance = Instantiate (m_Projectile, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody2D;
		projectileInstance.velocity = m_FireTransform.up * m_ProjectileSpeed;

		AudioSource.PlayClipAtPoint (m_FireAudioClip, transform.position);
	}
}