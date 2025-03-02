using UnityEngine;
using UnityEngine.AI;

public class PanController : MonoBehaviour
{
    [SerializeField] float health = 2;
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
        float distance = Random.Range(-5, 5);
        transform.position += new Vector3 (0, 0, distance);
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
}
