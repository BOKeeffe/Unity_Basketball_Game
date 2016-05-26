using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BinBounds : MonoBehaviour 
{

	Vector3 v1;
	Vector3 v2;
	Vector3 v3;
	Vector3 v4;

	public Text score; 
	private int scored;
	public bool notInBin;

	Basketball basketball;

	Bounds self;

	public Renderer[] bins;

	void Start()
	{
		scored = 0;
		notInBin = true;
		self = GetComponent<Renderer>().bounds;
		basketball = GetComponent<Basketball>();

		Vector3 a = new Vector3( 1, 2, 0 );
		Vector3 b = new Vector3( -2, 3, 5 );

		Vector2 c = new Vector2( 0, -4 );
		Vector2 d = new Vector2(-4, 1);	
	}

	void FixedUpdate()
	{

		v1= new Vector3( self.extents.x, self.extents.y, 0 );
		v2 = new Vector3( -self.extents.x, self.extents.y, 0 );
		v3 = new Vector3( 0, self.extents.y, self.extents.z );
		v4 = new Vector3( 0, self.extents.y, -self.extents.z );

		v1 += transform.position;
		v2 += transform.position;
		v3 += transform.position;
		v4 += transform.position;

		foreach(Renderer r in bins)
		{
			HandleCollision( r.bounds );
		}
		if (scored >= 40){
			Application.LoadLevel(3);
		}
	}

	void HandleCollision(Bounds other)
	{
		// check if other contains each element of the self bounds extents

		Vector3 v_1 = new Vector3( self.extents.x, self.extents.y, 0 );
		Vector3 v_2 = new Vector3( -self.extents.x, self.extents.y, 0 );
		Vector3 v_3 = new Vector3( 0, self.extents.y, self.extents.z );
		Vector3 v_4 = new Vector3( 0, self.extents.y, -self.extents.z );

		v_1 += transform.position;
		v_2 += transform.position;
		v_3 += transform.position;
		v_4 += transform.position;


		if (other.Contains( v_1 ) && other.Contains( v_2 ) &&
			other.Contains( v_3 ) && other.Contains( v_4 ))
		{
			basketball.velocity = Vector3.zero;
			basketball.acceleration = Vector3.zero;
			basketball.damping = 0.75f;
			if(notInBin){
				scored += 5;
				score.text = "Player Score: " + scored;
				notInBin = false;
			}
		}

		if(BoundsIsContained(self.min + transform.position, self.max + transform.position, other))
		{
			basketball.velocity = Vector3.zero;
			basketball.acceleration = Vector3.zero;
			basketball.damping = 0.5f;
		}
	}

	bool BoundsIsContained(Vector3 min, Vector3 max, Bounds container)
	{
		return container.Contains( min ) && container.Contains( max );
	}
}
