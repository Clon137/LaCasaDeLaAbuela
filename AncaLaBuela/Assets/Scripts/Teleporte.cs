using UnityEngine;

public class Teleporte : MonoBehaviour
{
    public Transform sotano2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            other.transform.position = sotano2.position;
        }
    }
}
