using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour 
{
	const float SPEED = 1;

	Slider slider;

	float pwr;

	void Start()
	{
		slider = GetComponent<Slider>();
		StartCoroutine( PingPong( slider.minValue, slider.maxValue, SPEED ) );
	}

	void FixedUpdate()
	{
		
	}

	IEnumerator PingPong(float min, float max, float speed)
	{
		float dir = 1f;

		while(1 > 0)
		{
			slider.value += (Time.deltaTime * speed) * dir;

			if (slider.value <= min || slider.value >= max)
				dir = -dir;

			yield return null;
		}
	}
}
