using UnityEngine;
using UnityEngine.AI;

public class CiervoControl : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] int rangoAtaque = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < rangoAtaque)
        {
            Destroy(gameObject);
        }
    }
}
