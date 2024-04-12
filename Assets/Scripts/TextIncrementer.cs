using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextIncrementer : MonoBehaviour
{
	[SerializeField] int currentValue = 0;

	private Text _textComponent;

	private void Start()
	{
		_textComponent = GetComponent<Text>();
		_textComponent.text = currentValue.ToString();
	}

	public void IncrementValue()
	{
		currentValue++;
		_textComponent.text = currentValue.ToString();
	}
}
