using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float cooldown = 10f;
    [SerializeField] GameObject tronquito;
    [SerializeField] GameObject helado;
    [SerializeField] GameObject calabaza;
    int randomNum;
    int randomPlace;
    [SerializeField] Transform ventana1;
    [SerializeField] Transform ventana2;
    [SerializeField] Transform ventana3;

    [SerializeField] Transform[] aparitionPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            randomNum = Random.Range(1,4);
            randomPlace = Random.Range(0,15);
            GenerateEnemy();
            cooldown = 10;
        }
    }

    void GenerateEnemy()
    {
        if (randomNum == 1)
        {
            GameObject tronco = Instantiate(tronquito, aparitionPoint[randomPlace].position, Quaternion.identity);
            NavMeshAgent agent = tronco.GetComponent<NavMeshAgent>();
            if (randomPlace <= 4) {agent.destination = ventana1.position;}
            else if (randomPlace <= 9) {agent.destination = ventana2.position;}
            else {agent.destination = ventana3.position;}
        }
        else if (randomNum == 2)
        {
            GameObject heladito = Instantiate(helado, aparitionPoint[randomPlace].position, Quaternion.identity);
            NavMeshAgent agent = heladito.GetComponent<NavMeshAgent>();
            if (randomPlace <= 4) {agent.destination = ventana1.position;}
            else if (randomPlace <= 9) {agent.destination = ventana2.position;}
            else {agent.destination = ventana3.position;}
        }
        else if (randomNum == 3)
        {
            GameObject calabacita = Instantiate(calabaza, aparitionPoint[randomPlace].position, Quaternion.identity);
            NavMeshAgent agent = calabacita.GetComponent<NavMeshAgent>();
            if (randomPlace <= 4) {agent.destination = ventana1.position;}
            else if (randomPlace <= 9) {agent.destination = ventana2.position;}
            else {agent.destination = ventana3.position;}
        }
    }
}
