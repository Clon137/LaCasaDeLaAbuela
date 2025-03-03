using UnityEngine;
using UnityEngine.AI;

public class EnemyPersonalControl : MonoBehaviour
{
    [SerializeField] float health = 1;
    NavMeshAgent agent;
    PlayerController controladorVida;
    [SerializeField] GameObject Player;
    [SerializeField] int rangoAtaque = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
        controladorVida = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < rangoAtaque)
        {
            controladorVida.Damage();
            Destroy(gameObject);
        }
    }

    public void Damage()
    {
        health -= 1;
        if (health < 1) {Destroy(gameObject);}
    }
}
