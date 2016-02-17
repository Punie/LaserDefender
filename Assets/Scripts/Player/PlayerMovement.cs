using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float m_Speed = 10f;

	private Rigidbody2D m_Rigidbody;
	private float m_MovementInputValue;

	private float m_MinXPos;
	private float m_MaxXPos;

	private void Awake ()
	{
		m_Rigidbody = GetComponent<Rigidbody2D> ();
		m_MovementInputValue = 0f;
	}

	private void Start ()
	{
		DetectCameraBoundaries ();
	}

	private void DetectCameraBoundaries ()
	{
		float padding = transform.lossyScale.x / 2f;
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;

		Vector3 bottomLeftCorner = Camera.main.ViewportToWorldPoint (new Vector3 (0f, 0f, distanceToCamera));
		Vector3 bottomRightCorner = Camera.main.ViewportToWorldPoint (new Vector3 (1f, 0f, distanceToCamera));

		m_MinXPos = bottomLeftCorner.x + padding;
		m_MaxXPos = bottomRightCorner.x - padding;
	}

	private void Update ()
	{
		m_MovementInputValue = Input.GetAxis ("Horizontal");
	}

	private void FixedUpdate ()
	{
		Move ();
	}

	private void Move ()
	{
		Vector3 unboundMovement = transform.position + Vector3.right * m_MovementInputValue * m_Speed * Time.deltaTime;
		float xBound = Mathf.Clamp (unboundMovement.x, m_MinXPos, m_MaxXPos);

		Vector3 movement = new Vector3 (xBound, unboundMovement.y, unboundMovement.z);
		m_Rigidbody.MovePosition (movement);
	}
}
