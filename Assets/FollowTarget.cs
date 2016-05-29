using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowTarget : MonoBehaviour
{
    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;
    public bool hit = false;

    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    void Update()
    {
        // Update destination if the target moves one unit
        if (hit == true)
        {
            if (Vector3.Distance(destination, target.position) > 1.0f)
            {
                destination = target.position;
                agent.destination = destination;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
       agent.enabled = true;
        hit = true;
        
    }
}