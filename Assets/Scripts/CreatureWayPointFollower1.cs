using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureWayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    private int currentWayPointIndex = 0;
    private SpriteRenderer sprite;

    [SerializeField] private float moveSpeed = 2f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
         
    }

    void Update()
    {
        if (Vector2.Distance(wayPoints[currentWayPointIndex].transform.position, transform.position) < .1f)
        {
            currentWayPointIndex++;
            sprite.flipX = true;
            if(currentWayPointIndex >= wayPoints.Length)
            {
                currentWayPointIndex = 0;
                sprite.flipX = false;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWayPointIndex].transform.position, Time.deltaTime * moveSpeed);
    }
}
