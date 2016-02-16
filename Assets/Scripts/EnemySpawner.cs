using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;

	void Start ()
	{
		GameObject enemy = Instantiate (enemyPrefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
		enemy.transform.parent = transform;
	}
}
