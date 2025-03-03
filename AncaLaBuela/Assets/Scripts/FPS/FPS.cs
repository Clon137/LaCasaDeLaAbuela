using System.IO.Compression;
using UnityEngine;

public class FPS : MonoBehaviour
{
    // AudioSource audioSrc;
    // [SerializeField] AudioClip sonido;
    [SerializeField] CharacterController Controlador;
    [SerializeField] float velocity = 15f;

    void Start()
    {
        
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 mover = transform.right * x + transform.forward * z;
        Controlador.Move(mover * velocity * Time.deltaTime);
        // audioSrc.PlayOneShot(sonido);
    }
}
