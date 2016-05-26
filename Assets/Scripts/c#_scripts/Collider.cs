using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Collider : MonoBehaviour
{
    //public GameObject object1;
    //public GameObject object2;
    public Text scoreText;
    private int score;
    public Renderer[] objects;

    Bounds self;
    gameBalls ball;

    void Start()
    {

        foreach (Renderer rend in objects)
        {
            if (rend.tag != "invisableTarget")
            {
                rend.enabled = true;
            }
            else
                rend.enabled = false;

        }
        score = 0;
        self = GetComponent<Renderer>().bounds;
        ball = GetComponent<gameBalls>();
    }

    void collisionDetection(Renderer other)
    {
        // Check if ball hit target
        if (self.Intersects(other.bounds))
        {

            if (Application.loadedLevel == 1)
            {
                score += 1;
                scoreText.text = "Player Score: " + score + "/10";
                ball.velocity = Vector3.Scale(ball.velocity, new Vector3(-1, -1, -1));
                GetComponent<AudioSource>().Play();
                if (other.tag == "Target")
                {
                    Destroy(other.gameObject);
                }
                if (score == 10)
                {
                    Application.LoadLevel(2);
                }
            }
            if (Application.loadedLevel == 2)
            {
                ball.velocity = Vector3.Scale(ball.velocity, new Vector3(0, 1, 0));
            }

        }
    }


    // Fixed update is called every frame
    void FixedUpdate()
    {
        self = GetComponent<Renderer>().bounds;
        foreach (Renderer rend in objects)
        {
            if (rend != null)
                collisionDetection(rend);
        }

    }
}
