using UnityEngine;
using System.Collections;

public class PlayerControllerTransform : MonoBehaviour
{
	public float m_Speed = 10f;


	void Update ()
	{
		if (Input.GetKey (KeyCode.LeftArrow))
			transform.position += new Vector3 (-m_Speed * Time.deltaTime, 0f, 0f);
		else if (Input.GetKey(KeyCode.RightArrow))
			transform.position += new Vector3 (m_Speed * Time.deltaTime, 0f, 0f);
	}
}
