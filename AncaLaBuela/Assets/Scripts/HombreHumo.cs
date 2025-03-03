using UnityEngine;

public class HombreHumo : MonoBehaviour
{
    public GameObject activar;
    public static bool bloqueo = false;
    float distance; 
    [SerializeField] float visionArea = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (distance <= visionArea){
            Destroy(gameObject);
            activar.SetActive(true);
            bloqueo = true;
        }
    }

}
