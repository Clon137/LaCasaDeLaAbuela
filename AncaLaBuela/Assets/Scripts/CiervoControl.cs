using UnityEngine;
using UnityEngine.AI;

public class CiervoControl : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= 2)
        {
            Destroy(gameObject);
        }
    }
}
