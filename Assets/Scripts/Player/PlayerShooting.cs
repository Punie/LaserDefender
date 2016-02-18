using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
	public Rigidbody2D m_Projectile;
	public Transform m_FireTransform;
	public float m_ProjectileSpeed = 10f;
	public float m_FiringRate = 0.2f;
	public AudioSource m_ShootingAudio;


	private void Update ()
	{
		if (Input.GetButtonDown ("Fire"))
			InvokeRepeating ("Fire", 0.001f, m_FiringRate);
		else if (Input.GetButtonUp ("Fire"))
			CancelInvoke ("Fire");
	}

	private void Fire ()
	{
		Rigidbody2D projectileInstance = Instantiate (m_Projectile, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody2D;
		projectileInstance.velocity = m_FireTransform.up * m_ProjectileSpeed;

		m_ShootingAudio.Play ();
	}
}
