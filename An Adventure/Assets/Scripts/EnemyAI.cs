using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float nextWaypointDistance = 3f;

    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;

    Seeker seeker;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null) return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        Vector3 direction = ((Vector3)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector3 displacement = direction * speed * Time.deltaTime;

        rb.MovePosition(rb.position + displacement);

        float distance = Vector3.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (rb.velocity.x >= 0.01f)
        {
            enemyGFX.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (rb.velocity.x <= -0.01f)
        {
            enemyGFX.transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

}
