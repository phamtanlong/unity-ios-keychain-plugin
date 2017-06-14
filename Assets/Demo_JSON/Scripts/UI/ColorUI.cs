using UnityEngine;
using UnityEngine.UI;

public class ColorUI : MonoBehaviour 
{
	private const float _maxColorValue = 255;

	[SerializeField] private Text rValue;
	[SerializeField] private Text gValue;
	[SerializeField] private Text bValue;

	public void SaveColor()
	{
		int r = ConvertStringToInt(this.rValue.text);
		int g = ConvertStringToInt(this.gValue.text);
		int b = ConvertStringToInt(this.bValue.text);

		Color finalColor = new Color(r / _maxColorValue, g / _maxColorValue, b / _maxColorValue);
		SceneDataManager.UpdateBackgroundColor(finalColor);
	}

	private int ConvertStringToInt(string input)
	{
		return int.Parse(input);
	}
}
