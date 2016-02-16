using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float m_Speed = 10f;
	public float m_Padding = 1f;

	float m_xMin;
	float m_xMax;


	void Start ()
	{
		DetectCameraBounderies ();
	}

	void Update ()
	{
		Move ();
	}

	void DetectCameraBounderies ()
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
}
