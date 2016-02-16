using UnityEngine;
using System.Collections;

public class PhysicsController : MonoBehaviour
{
	public float m_Speed = 10f;

	private Rigidbody2D m_Rigidbody;
	private float m_HorizontalInputValue;
	private float m_VerticalInputValue;

	void Awake ()
	{
		m_Rigidbody = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		m_HorizontalInputValue = Input.GetAxis ("Horizontal");
		m_VerticalInputValue = Input.GetAxis ("Vertical");
	}

	void FixedUpdate ()
	{
		Move ();
	}

	void Move ()
	{
		Vector2 horizontalMovement = transform.right * m_HorizontalInputValue * m_Speed * Time.deltaTime;
		Vector2 verticalMovement = transform.up * m_VerticalInputValue * m_Speed * Time.deltaTime;

		m_Rigidbody.MovePosition (m_Rigidbody.position + horizontalMovement + verticalMovement);
	}
}
