using UnityEngine;

public class MiradaCamara : MonoBehaviour
{
    [SerializeField] float velocity = 100f;
    float RotacionX = 0f;

    public Transform Jugador;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float MauseX = Input.GetAxis("Mouse X") * velocity * Time.deltaTime;
        float MauseY = Input.GetAxis("Mouse Y") * velocity * Time.deltaTime;

        RotacionX -= MauseY;
        // Limite
        RotacionX = Mathf.Clamp(RotacionX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(RotacionX, 0f, 0f);
        Jugador.Rotate(Vector3.up * MauseX);
    }
}
