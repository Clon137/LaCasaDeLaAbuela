using System.IO.Compression;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FPS : MonoBehaviour
{
    
    [SerializeField] CharacterController Controlador;
    [SerializeField] float velocity = 15f;
    public static int lives = 3;

    void Start()
    {
        
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 mover = transform.right * x + transform.forward * z;
        Controlador.Move(mover * velocity * Time.deltaTime);
        
    }
    public void Damage(){
        lives --;
        print("auch");
        if (lives <= 0){
            SceneManager.LoadScene("MainMenu");
        }
    }
    void OnTriggerEnter (Collider other){
        if (other.gameObject.tag == "Finish"){
            SceneManager.LoadScene("Camino");
        }
    }
    
}
