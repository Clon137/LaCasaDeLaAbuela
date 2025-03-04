using UnityEngine;

public class FPSShot : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    AudioSource audioSrc;
    [SerializeField] AudioClip sonido;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
        Instantiate(projectile, transform.position, transform.rotation);
        audioSrc.PlayOneShot(sonido);
        }
    }
}
