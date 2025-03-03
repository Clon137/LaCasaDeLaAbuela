using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Transform mira;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] Camera wichCamera;
    public float distanceFromCamera = 5f;    
    [SerializeField] GameObject pistolObject;
    [SerializeField] GameObject fusilObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pistolObject.SetActive(true);
        fusilObject.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
        if (!OleadaController.pistol)
        {
            pistolObject.SetActive(false);
            fusilObject.SetActive(true);
        }
    }

    void AimWeapon()
    {
        Ray ray = wichCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 direction = ray.GetPoint(distanceFromCamera);

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        targetRotation *= Quaternion.Euler(90, 0, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
