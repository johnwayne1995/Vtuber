using System;
using UnityEngine;
using UnityEngine.UI;

namespace GeoGame.Localization
{
	public class StringLocalizer : MonoBehaviour
	{
		public string id;
		public Text textElement;

		public string currentValue { get; private set; }
		public bool controlRectTransformWidth;
		public float padding = 50;

		void Start()
		{
			Localize();
		}

		private void OnEnable()
		{
			LocalizationManager.onLanguageChanged += Localize;
		}

		private void OnDisable()
		{
			
			LocalizationManager.onLanguageChanged -= Localize;
		}

		void Localize()
		{
			currentValue = LocalizationManager.Localize(id);
			textElement.text = currentValue;
			// textElement.isRightToLeftText = LocalizationManager.IsRightToLeftWritingSystem;

			if (controlRectTransformWidth)
			{
				// textElement.ForceMeshUpdate();
				// textElement.GraphicUpdateComplete();
				RectTransform rectTransform = GetComponent<RectTransform>();
				if (rectTransform != null)
				{
					GetComponent<RectTransform>().sizeDelta = new Vector2(textElement.flexibleWidth + padding, rectTransform.sizeDelta.y);
				}
			}
		}

#if UNITY_EDITOR
		void OnValidate()
		{
			if (textElement == null)
			{
				textElement = GetComponent<Text>();
				if (textElement == null)
				{
					textElement = GetComponentInChildren<Text>();
				}
			}
		}
#endif
	}
}