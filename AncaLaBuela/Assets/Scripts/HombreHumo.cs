using UnityEngine;

public class HombreHumo : MonoBehaviour
{
    public GameObject destino;
    public GameObject activar;
    public static bool bloqueo = false;
    Vector3 posicionDestino;
    float distance; 
    [SerializeField] float visionArea = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, destino.transform.position);
        posicionDestino = destino.transform.position;
        transform.position = Vector3.MoveTowards(transform.position,posicionDestino,Time.deltaTime);

        if (distance <= visionArea){
            Destroy(gameObject);
            activar.SetActive(true);
            bloqueo = true;
        }
    }

}
