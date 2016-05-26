using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ballPowerBar : MonoBehaviour
{
    const float SPEED = 8;

    Slider powerBar;

    float pwr;

    void Start()
    {
        powerBar = GetComponent<Slider>();
        StartCoroutine(PingPong(powerBar.minValue, powerBar.maxValue, SPEED));
    }

    void FixedUpdate()
    {

    }

    IEnumerator PingPong(float min, float max, float speed)
    {
        float direction = 1f;

        while (1 > 0)
        {
            powerBar.value += (Time.deltaTime * speed) * direction;

            if (powerBar.value <= min || powerBar.value >= max)
                direction = -direction;

            yield return null;
        }
    }
}