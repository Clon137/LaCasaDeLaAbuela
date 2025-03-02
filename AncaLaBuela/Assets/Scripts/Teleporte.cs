using UnityEngine;

public class Teleporte : MonoBehaviour
{
    [SerializeField] GameObject CamaraBaja;
    public Transform bajar;
    public Transform subir;
    void Start()
    {
        CamaraBaja.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "Bajar"){
            other.transform.position = bajar.position;
            CamaraBaja.SetActive(true);
        }
        if (other.gameObject.tag == "Player" && gameObject.tag == "Subir"){
            other.transform.position = subir.position;
            CamaraBaja.SetActive(false);
        }
    }
}
