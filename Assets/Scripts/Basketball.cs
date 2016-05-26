using UnityEngine;
using System.Collections;

public class Basketball : MonoBehaviour 
{
	[Header( "Initial conditions" )]
	public Vector3 position = Vector3.zero;
	public Vector3 velocity = Vector3.zero;
	public Vector3 acceleration = new Vector3( 0, -9.81f, 0 );

	public float radius = 0.5f;
	[Range(0, 1)]
	public float damping = 0.3f;

	void Start()
	{
		position = transform.position;
	}

	void FixedUpdate()
	{

		// Check if the ball hits the ground, and velocity is negative i.e. if the ball is dropping
		// If it is, reverse the velocity to make it bounce
		if (position.y < radius)
		{
			position.y = radius;
			if(velocity.y < 0)
			{
				velocity.y = -velocity.y;
				velocity *= 1 - damping;
				if(position.y - transform.position.y > 0.01f)
					GetComponent<AudioSource>().Play();
			}
				
		}

		velocity = velocity + acceleration * Time.deltaTime;
		position = position + velocity * Time.deltaTime;

		if(acceleration != Vector3.zero)
			transform.position = position;
	}

	// This will just add force to the object in a direction
	// For example, you could use transform.forward to add 
	// forward force to the ball.
	public void AddForce(Vector3 force)
	{
		if(velocity == Vector3.zero)
		{
			force.y += 3;
			velocity += force;
		}
		
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere( transform.position, radius );
	}
}
