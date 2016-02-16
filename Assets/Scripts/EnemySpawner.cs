using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public GameObject m_enemyPrefab;

	public float m_Width = 10f;
	public float m_Height = 5f;

	public float m_Speed = 3f;

	float m_xMin;
	float m_xMax;
	bool m_GoingLeft = true;

	void Start ()
	{
		SpawnEnemies ();
		DetectCameraBoundaries ();
	}

	void Update ()
	{
		MoveEnemyFormation ();
	}

	void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (m_Width, m_Height, 0f));
	}

	void SpawnEnemies ()
	{
		foreach (Transform child in transform)
		{
			GameObject enemy = Instantiate (m_enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void DetectCameraBoundaries ()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));

		m_xMin = leftmost.x + (m_Width / 2f);
		m_xMax = rightmost.x - (m_Width / 2f);
	}

	void MoveEnemyFormation ()
	{
		if (m_GoingLeft)
			transform.position += Vector3.left * m_Speed * Time.deltaTime;
		else
			transform.position += Vector3.right * m_Speed * Time.deltaTime;

		float x = Mathf.Clamp (transform.position.x, m_xMin, m_xMax);

		transform.position = new Vector3 (x, transform.position.y, transform.position.z);

		if (x <= m_xMin)
			m_GoingLeft = false;
		else if (x >= m_xMax)
			m_GoingLeft = true;
	}
}
