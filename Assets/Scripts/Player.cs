using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour 
{
	private float newBall;
	gameBalls ball;

	public Slider pwrBar;

	Vector3 initialPosition;

	void Awake()
	{
		newBall = Time.time + 3;
		ball = GetComponentInChildren<gameBalls>();
		ball.acceleration = Vector3.zero;
		initialPosition = ball.transform.localPosition;
	}
	
	void FixedUpdate()
	{
		float timeLeft = newBall - Time.time;
		if(Input.GetMouseButtonUp(0) && ball)
		{
			ball.transform.parent = null;
			ball.position = ball.transform.position;
			ball.acceleration = new Vector3( 0, -9.81f, 0 );
			ball.applyForces( Camera.main.transform.forward * pwrBar.value );
		}
		if (timeLeft <= 0) 
		{
			print("IN");
			if(Application.loadedLevel == 2){
				ball.GetComponent<targetBounds>().notInBin = true;
			}
			newBall = Time.time + 5;
			ball.transform.parent = Camera.main.transform;
			ball.transform.localPosition = initialPosition;
			ball.acceleration = Vector3.zero;
			ball.velocity = Vector3.zero;
		}
	}
}
