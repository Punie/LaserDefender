using UnityEngine;
using System.Collections;

public class PlayerDamageDisplay : MonoBehaviour
{
	SpriteRenderer m_SpriteRenderer;

	private void Awake ()
	{
		m_SpriteRenderer = GetComponent<SpriteRenderer> ();
	}

	public void ChangeSprite (Sprite sprite)
	{
		m_SpriteRenderer.sprite = sprite;
	}
}
