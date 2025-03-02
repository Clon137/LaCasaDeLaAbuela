using UnityEngine;
using UnityEngine.AI;

public class SlimeControl : MonoBehaviour
{
    [SerializeField] float health = 1;
    [SerializeField] GameObject littleSlime;
    NavMeshAgent agent;
    PlayerController controladorVida;
    [SerializeField] GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
        controladorVida = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 2)
        {
            controladorVida.Damage();
            Destroy(gameObject);
        }
    }

    public void Damage()
    {
        health -= 1;
        if (health < 1)
        {            
            GameObject slime1 = Instantiate(littleSlime, transform.position + new Vector3(1f, 0, 0), Quaternion.identity);
            GameObject slime2 = Instantiate(littleSlime, transform.position - new Vector3(1f, 0, 0), Quaternion.identity);
            NavMeshAgent agent1 = slime1.GetComponent<NavMeshAgent>();
            NavMeshAgent agent2 = slime2.GetComponent<NavMeshAgent>();
            agent1.destination = agent.destination;
            agent2.destination = agent.destination;
            Destroy(gameObject);
        }
    }
}
