using UnityEngine;

public class FPSShot : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
        Instantiate(projectile, transform.position, transform.rotation);
        }
    }
}
