using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Object_Collider : MonoBehaviour 
{
	public GameObject object1;
	public GameObject object2;
	public Text score; 
	private int scored;
	public Renderer[] objects;

	Bounds self;

	Basketball basketball;

	void Start()
	{

        foreach (Renderer rend in objects) {
            if (rend.tag != "invisableCube")
            {
                
                rend.enabled = true;
            }

        }
		scored = 0;
		self = GetComponent<Renderer>().bounds;

		basketball = GetComponent<Basketball>();
	}

	void HandleCollision(Renderer other)
	{
		// Check if ball hit target
		if(self.Intersects(other.bounds))
		{

			if(Application.loadedLevel == 1){
				scored += 5;
				score.text = "Player Score: " + scored + "/40";
				basketball.velocity = Vector3.Scale( basketball.velocity, new Vector3( -1, -1, -1 ) );
				GetComponent<AudioSource>().Play();
				if(other.tag == "Target")
				{
					Destroy(other.gameObject);
				}
				if (scored == 40){
					Application.LoadLevel(2);
				}
			}
			if (Application.loadedLevel == 2){
				basketball.velocity = Vector3.Scale( basketball.velocity, new Vector3( 0, 1, 0 ) );
			}

		}
	}

	
	// Fixed update is called every frame
	void FixedUpdate () 
	{
		self = GetComponent<Renderer>().bounds;
		foreach(Renderer r in objects)
		{
			if(r != null)
				HandleCollision(r);
		}

	}
}
