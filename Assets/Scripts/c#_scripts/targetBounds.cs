using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class targetBounds : MonoBehaviour
{

    Vector3 v1;
    Vector3 v2;
    Vector3 v3;
    Vector3 v4;

    public Text score;
    private int scored;
    public bool notInBin;

    gameBalls ball;

    Bounds self;

    public Renderer[] target;

    void Start()
    {
        scored = 0;
        notInBin = true;
        self = GetComponent<Renderer>().bounds;
        ball = GetComponent<gameBalls>();

        Vector3 a = new Vector3(1, 2, 0);
        Vector3 b = new Vector3(-2, 3, 5);

        Vector2 c = new Vector2(0, -4);
        Vector2 d = new Vector2(-4, 1);
    }

    void FixedUpdate()
    {

        v1 = new Vector3(self.extents.x, self.extents.y, 0);
        v2 = new Vector3(-self.extents.x, self.extents.y, 0);
        v3 = new Vector3(0, self.extents.y, self.extents.z);
        v4 = new Vector3(0, self.extents.y, -self.extents.z);

        v1 += transform.position;
        v2 += transform.position;
        v3 += transform.position;
        v4 += transform.position;

        foreach (Renderer r in target)
        {
            HandleCollision(r.bounds);
        }
        if (scored >= 10)
        {
            Application.LoadLevel(3);
        }
    }

    void HandleCollision(Bounds other)
    {
        // check if other contains each element of the self bounds extents
        Vector3 v_1 = new Vector3(self.extents.x, self.extents.y, 0);
        Vector3 v_2 = new Vector3(-self.extents.x, self.extents.y, 0);
        Vector3 v_3 = new Vector3(0, self.extents.y, self.extents.z);
        Vector3 v_4 = new Vector3(0, self.extents.y, -self.extents.z);

        v_1 += transform.position;
        v_2 += transform.position;
        v_3 += transform.position;
        v_4 += transform.position;


        if (other.Contains(v_1) && other.Contains(v_2) &&
            other.Contains(v_3) && other.Contains(v_4))
        {
            ball.velocity = Vector3.zero;
            ball.acceleration = Vector3.zero;
            ball.damping = 0.75f;
            if (notInBin)
            {
                scored += 1;
                score.text = "Player Score: " + scored;
                notInBin = false;
            }
        }

        if (BoundsIsContained(self.min + transform.position, self.max + transform.position, other))
        {
            ball.velocity = Vector3.zero;
            ball.acceleration = Vector3.zero;
            ball.damping = 0.5f;
        }
    }

    bool BoundsIsContained(Vector3 min, Vector3 max, Bounds container)
    {
        return container.Contains(min) && container.Contains(max);
    }
}