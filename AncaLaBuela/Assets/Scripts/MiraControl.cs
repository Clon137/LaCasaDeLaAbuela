using UnityEngine;

public class MiraControl : MonoBehaviour
{
    public Camera firstCamera;
    public Camera secondCamera;
    public Camera thirdCamera;
    public float distanceFromCamera = 50f; // Distancia fija donde estará la mira

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoverMira();
    }

    void MoverMira()
    {
        if (PlayerController.camara1)
        {
            Ray ray = firstCamera.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.GetPoint(distanceFromCamera); // Calcula un punto en la dirección del rayo
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (PlayerController.camara2)
        {
            Ray ray = secondCamera.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.GetPoint(distanceFromCamera); // Calcula un punto en la dirección del rayo
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (PlayerController.camara3)
        {
            Ray ray = thirdCamera.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.GetPoint(distanceFromCamera); // Calcula un punto en la dirección del rayo
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
