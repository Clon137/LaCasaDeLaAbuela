using UnityEngine;
using UnityEngine.AI;


public class ErNegroControler : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] GameObject Player;
    [SerializeField] int vidas = 1;
    FPS controladorVida;
    float distance;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        controladorVida = Player.GetComponent<FPS>();
        }
    void Update(){
        agent.destination = Player.transform.position;
    }
    void OnTriggerEnter (Collider other){
        if (other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<FPS>().Damage();
            Destroy(gameObject);
        }
    }
    
    public void Damage()
    {
        vidas -= 1;
        if (vidas < 1) {
            Destroy(gameObject);
    }
}
}
