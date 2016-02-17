using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public GameObject m_enemyPrefab;
	public float m_Width = 10f;
	public float m_Height = 5f;

	public float m_Speed = 3f;

	private float m_MinXPos;
	private float m_MaxXPos;
	private bool m_GoingRight = true;

	private void Start ()
	{
		SpawnEnemies ();
		DetectCameraBoundaries ();
	}

	private void Update ()
	{
		MoveEnemyFormation ();
	}

	private void SpawnEnemies ()
	{
		foreach (Transform child in transform)
		{
			GameObject enemy = Instantiate (m_enemyPrefab, child.transform.position, child.transform.rotation) as GameObject;
			enemy.transform.parent = child;
		}
	}

	private void DetectCameraBoundaries ()
	{
		float padding = m_Width / 2f;
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;

		Vector3 bottomLeftCorner = Camera.main.ViewportToWorldPoint (new Vector3 (0f, 0f, distanceToCamera));
		Vector3 bottomRightCorner = Camera.main.ViewportToWorldPoint (new Vector3 (1f, 0f, distanceToCamera));

		m_MinXPos = bottomLeftCorner.x + padding;
		m_MaxXPos = bottomRightCorner.x - padding;
	}

	private void MoveEnemyFormation ()
	{
		Vector3 unboundMovement;
		float xBound;

		if (m_GoingRight)
			unboundMovement = transform.position + Vector3.right * m_Speed * Time.deltaTime;
		else
			unboundMovement = transform.position += Vector3.left * m_Speed * Time.deltaTime;

		xBound = Mathf.Clamp (unboundMovement.x, m_MinXPos, m_MaxXPos);

		transform.position = new Vector3 (xBound, unboundMovement.y, unboundMovement.z);

		if (xBound <= m_MinXPos)
			m_GoingRight = true;
		else if (xBound >= m_MaxXPos)
			m_GoingRight = false;
	}
		
	private void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (m_Width, m_Height));
	}

//	public GameObject m_enemyPrefab;
//
//	public float m_Width = 10f;
//	public float m_Height = 5f;
//
//	public float m_Speed = 3f;
//
//	float m_xMin;
//	float m_xMax;
//	bool m_GoingLeft = true;
//
//	void Start ()
//	{
//		SpawnEnemies ();
//		DetectCameraBoundaries ();
//	}
//
//	void Update ()
//	{
//		MoveEnemyFormation ();
//	}
//
//	void OnDrawGizmos ()
//	{
//		Gizmos.DrawWireCube (transform.position, new Vector3 (m_Width, m_Height, 0f));
//	}
//
//	void SpawnEnemies ()
//	{
//		foreach (Transform child in transform)
//		{
//			GameObject enemy = Instantiate (m_enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
//			enemy.transform.parent = child;
//		}
//	}
//
//	void DetectCameraBoundaries ()
//	{
//		float distance = transform.position.z - Camera.main.transform.position.z;
//
//		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
//		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));
//
//		m_xMin = leftmost.x + (m_Width / 2f);
//		m_xMax = rightmost.x - (m_Width / 2f);
//	}
//
//	void MoveEnemyFormation ()
//	{
//		if (m_GoingLeft)
//			transform.position += Vector3.left * m_Speed * Time.deltaTime;
//		else
//			transform.position += Vector3.right * m_Speed * Time.deltaTime;
//
//		float x = Mathf.Clamp (transform.position.x, m_xMin, m_xMax);
//
//		transform.position = new Vector3 (x, transform.position.y, transform.position.z);
//
//		if (x <= m_xMin)
//			m_GoingLeft = false;
//		else if (x >= m_xMax)
//			m_GoingLeft = true;
//	}
}
