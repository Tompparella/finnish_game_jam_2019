using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCwalk : MonoBehaviour
{
    public float speed;
    private float realSpeed;
    public float sightDistance = 20f;
    public Vector2 direction = new Vector2(0, 0);



    void Update()
    {
        MoveCharacter(direction);
    }

    void FixedUpdate()
    {
        FollowUpdate();
    }

    void MoveCharacter(Vector2 directionvector)
    {
        transform.Translate(directionvector.normalized * realSpeed * Time.deltaTime);
    }

    void FollowUpdate()
    {
        float distance = FollowDistance();

        bool withinSight = (distance < sightDistance);

        if (withinSight)
        {
            direction.x = (GameObject.Find("Player").transform.position.x - this.transform.position.x);
            direction.y = (GameObject.Find("Player").transform.position.y - this.transform.position.y);
            realSpeed = speed;
        }
        else
        {
            realSpeed = 0;
        }
    }

    float FollowDistance()
    {
        float dist = Vector2.Distance(new Vector2(this.transform.position.x, this.transform.position.y),
                                                       GameObject.Find("Player").transform.position);
        Debug.Log("Distance to other: " + dist);
        return dist;
    }
}