using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
public class AgentSimpleController : MonoBehaviour
{
    public Transform Target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null && agent.isOnNavMesh)
        {
            agent.SetDestination(Target.position);

            agent.speed = Random.Range(4f, 8f);
            agent.acceleration = Random.Range(5f, 10f);
            agent.stoppingDistance = Random.Range(1f, 3f);
            agent.avoidancePriority = Random.Range(0, 99);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (agent == null || agent.path == null) return;

        Vector3[] corners = agent.path.corners;


        for (int i = 0; i < corners.Length - 1; i++)
        {
            Gizmos.DrawLine(corners[i], corners[i + 1]);
            Gizmos.DrawSphere(corners[i], 0.2f);
        }

    }
}
