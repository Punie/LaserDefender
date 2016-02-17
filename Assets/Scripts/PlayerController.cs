using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float m_Speed = 10f;
	public float m_Padding = 1f;
	public GameObject m_Projectile;
	public float m_ProjectileSpeed = 15f;
	public float m_FiringRate = 0.2f;

	public float m_MaxHealth = 10f;

	float m_xMin;
	float m_xMax;

	float m_CurrentHealth;


	void Start ()
	{
		DetectCameraBoundaries ();
		m_CurrentHealth = m_MaxHealth;
	}

	void Update ()
	{
		Shoot ();
		Move ();
	}

	void DetectCameraBoundaries ()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));

		m_xMin = leftmost.x + m_Padding;
		m_xMax = rightmost.x - m_Padding;
	}

	void Move ()
	{
		if (Input.GetKey (KeyCode.LeftArrow))
			transform.position += Vector3.left * m_Speed * Time.deltaTime;
		else if (Input.GetKey (KeyCode.RightArrow))
			transform.position += Vector3.right * m_Speed * Time.deltaTime;

		float x = Mathf.Clamp (transform.position.x, m_xMin, m_xMax);

		transform.position = new Vector3 (x, transform.position.y, transform.position.z);
	}

	void Shoot ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
			InvokeRepeating ("Fire", 0.0001f, m_FiringRate);
		if (Input.GetKeyUp (KeyCode.Space))
			CancelInvoke ("Fire");
	}

	void Fire ()
	{
		GameObject projectile = Instantiate (m_Projectile, transform.position, Quaternion.identity) as GameObject;
		Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D> ();

		projectileRigidbody.velocity = new Vector3 (0f, m_ProjectileSpeed);
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
