using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour
{
	public int m_Score = 0;

	private Text m_ScoreText;

	private void Awake ()
	{
		m_ScoreText = GetComponent<Text> ();
		Reset ();
	}

	public void Score (int points)
	{
		m_Score += points;
		m_ScoreText.text = "Score: " + m_Score;
	}

	public void Reset ()
	{
		m_Score = 0;
		m_ScoreText.text = "Score: " + m_Score;
	}
}
