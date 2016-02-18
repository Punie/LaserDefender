using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public GameObject m_enemyPrefab;
	public float m_Width = 10f;
	public float m_Height = 5f;
	public float m_Speed = 3f;
	public float m_SpawnDelay = 0.5f;

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

		if (AllMembersDead ())
			SpawnEnemies ();
	}

	private void SpawnEnemies ()
	{
		Transform freePos = NextFreePosition ();

		if (freePos)
		{
			GameObject enemy = Instantiate (m_enemyPrefab, freePos.position, freePos.rotation) as GameObject;
			enemy.transform.parent = freePos;
		}

		if (NextFreePosition ())
			Invoke ("SpawnEnemies", m_SpawnDelay);
	}

	private Transform NextFreePosition ()
	{
		foreach (Transform childPositionGameObject in transform)
			if (childPositionGameObject.childCount == 0)
				return childPositionGameObject;

		return null;
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

	private bool AllMembersDead ()
	{
		foreach (Transform childPositionGameObject in transform)
			if (childPositionGameObject.childCount > 0)
				return false;

		return true;
	}
		
	private void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (m_Width, m_Height));
	}
}
