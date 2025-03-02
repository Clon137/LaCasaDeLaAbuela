using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public OleadaController OC;
    [SerializeField] float cooldown = 10f;
    public float cooldownMax = 15f;    
    
    [SerializeField] GameObject[] enemies;
    int randomNum;
    public int maxRandom = 3;
    int randomPlace;
    [SerializeField] Transform ventana1;
    [SerializeField] Transform ventana2;
    [SerializeField] Transform ventana3;
    [SerializeField] GameObject Light1;
    [SerializeField] GameObject Light2;
    [SerializeField] GameObject Light3;
    Light luz1;
    Light luz2;
    Light luz3;

    [SerializeField] Transform[] aparitionPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Light1.SetActive(false);
        Light2.SetActive(false);
        Light3.SetActive(false);
        luz1 = Light1.GetComponent<Light>();
        luz2 = Light2.GetComponent<Light>();
        luz3 = Light3.GetComponent<Light>();
        turnLight();        
    }

    // Update is called once per frame
    void Update()
    {
        if (OC.oleadaGoing)
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            randomNum = Random.Range(0, maxRandom);
            randomPlace = Random.Range(0, 15);
            GenerateEnemy();
            cooldown = cooldownMax;
        }                
    }

    void GenerateEnemy()
    {
        GameObject enemy = Instantiate(enemies[randomNum], aparitionPoint[randomPlace].position, Quaternion.identity);
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        if (randomPlace <= 4)
        {
            agent.destination = ventana1.position;            
            Light1.SetActive(true);
            Invoke("OffLight1", 5);
        }
        else if (randomPlace <= 9)
        {
            agent.destination = ventana2.position;
            Light2.SetActive(true);
            Invoke("OffLight2", 5);
        }
        else
        {
            agent.destination = ventana3.position;
            Light3.SetActive(true);
            Invoke("OffLight3", 5);
        }
    }

    void OffLight1()
    {
        Light1.SetActive(false);
    }
    void OffLight2()
    {
        Light2.SetActive(false);
    }
    void OffLight3()
    {
        Light3.SetActive(false);
    }
    void turnLight()
    {
        luz1.intensity = 2;
        luz2.intensity = 2;
        luz3.intensity = 2;
        Invoke("turnOffLight", 0.5f);
    }
    void turnOffLight()
    {
        luz1.intensity = 0;
        luz2.intensity = 0;
        luz3.intensity = 0;
        Invoke("turnLight", 0.5f);
    }
}
