using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour
{
	void Start ()
	{
		Text scoreText = GetComponent<Text> ();
		scoreText.text = ScoreKeeper.m_Score.ToString ();
		ScoreKeeper.Reset ();
	}
}
