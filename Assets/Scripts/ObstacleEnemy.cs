using UnityEngine;

public class ObstacleEnemy : MonoBehaviour
{
    public GameObject Prefabobstacle;
    public BoxCollider obstacleCollider;

    public float riseHeight = 3f;
    public float timeUp = 3f;
    public float timeDown = 3f;

    private Vector3 initialPosition;
    private Vector3 upPosition;

    private float timer;
    private bool goingUp = true;

    void Start()
    {
        initialPosition = transform.position;
        upPosition = initialPosition + Vector3.up * riseHeight;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (goingUp)
        {
            transform.position = upPosition;

            if (timer >= timeUp)
            {
                timer = 0;
                goingUp = false;
            }
        }
        else
        {
            transform.position = initialPosition;

            if (timer >= timeDown)
            {
                timer = 0;
                goingUp = true;
            }
        }
    }
}

