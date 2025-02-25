using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveSpeed = 7;
    public float groundDrag = 4;
    public float airMultiplier = 0.4f;
    float horizontalInput;
    float verticalInput;
    bool canMove = true;

    [Header("Comprobar suelo")]
    public float playerHeight = 2;
    public LayerMask whatIsGround;
    bool grounded;
    public Transform orientation;
    Vector3 moveDirection;

    // Ventana
    [Header("Ventana")]
    [SerializeField] GameObject ventanaCanvas1;
    [SerializeField] GameObject ventanaCanvas2;
    [SerializeField] GameObject ventanaCanvas3;
    [SerializeField] GameObject ammoCanvas;

    [SerializeField] GameObject cameraMain;
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject camera2;
    [SerializeField] GameObject camera3;
    public static bool camara1 = false;
    public static bool camara2 = false;
    public static bool camara3 = false;
    bool ventana1 = false;
    bool ventana2 = false;
    bool ventana3 = false;

    [Header("Disparo")]
    [SerializeField] GameObject mira;
    [SerializeField] GameObject weapon1;
    [SerializeField] GameObject weapon2;
    [SerializeField] GameObject weapon3;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 40f;
    [SerializeField] Transform firePoint1;
    [SerializeField] Transform firePoint2;
    [SerializeField] Transform firePoint3;
    [SerializeField] float coolD = 1f;
    bool canShot = true;

    [SerializeField] int ammo = 5;
    string[] arma;
    int armaNum = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        ventanaCanvas1.SetActive(false);
        ventanaCanvas2.SetActive(false);
        ventanaCanvas3.SetActive(false);
        ammoCanvas.SetActive(false);

        cameraMain.SetActive(true);
        camera1.SetActive(false);
        camera2.SetActive(false);
        camera3.SetActive(false);
        camara1 = false;
        camara2 = false;
        camara3 = false;

        mira.SetActive(false);
        weapon1.SetActive(false);
        weapon2.SetActive(false);
        weapon3.SetActive(false);
        arma[0] = "pistola";
        arma[1] = "escopeta";
        arma[2] = "fusil";
        armaNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();

        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            MovePlayer();
        }
    }

    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!camara1 && ventana1)
            {
                camera1.SetActive(true);
                mira.SetActive(true);
                camara1 = true;
                weapon1.SetActive(true);
            }
            else if (!camara2 && ventana2)
            {
                camera2.SetActive(true);
                mira.SetActive(true);
                camara2 = true;
                weapon2.SetActive(true);
            }
            else if (!camara3 && ventana3)
            {
                camera3.SetActive(true);
                mira.SetActive(true);
                camara3 = true;
                weapon3.SetActive(true);
            }
            else
            {
                camera1.SetActive(false);
                camera2.SetActive(false);
                camera3.SetActive(false);
                camara1 = false;
                camara2 = false;
                camara3 = false;

                mira.SetActive(false);
                weapon1.SetActive(false);
                weapon2.SetActive(false);
                weapon3.SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(0)) // Detectar clic izquierdo
        {
            Shoot();
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "VentanaControl")
        {
            ventanaCanvas1.SetActive(true);
            ventana1 = true;
        }
        if (other.gameObject.tag == "VentanaControl2")
        {
            ventanaCanvas2.SetActive(true);
            ventana2 = true;
        }
        if (other.gameObject.tag == "VentanaControl3")
        {
            ventanaCanvas3.SetActive(true);
            ventana3 = true;
        }
        if (other.gameObject.tag == "Ammo")
        {
            ammoCanvas.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "VentanaControl")
        {
            ventanaCanvas1.SetActive(false);
            ventana1 = false;
        }
        if (other.gameObject.tag == "VentanaControl2")
        {
            ventanaCanvas2.SetActive(false);
            ventana2 = false;
        }
        if (other.gameObject.tag == "VentanaControl3")
        {
            ventanaCanvas3.SetActive(false);
            ventana3 = false;
        }
        if (other.gameObject.tag == "Ammo")
        {
            ammoCanvas.SetActive(false);
        }
    }

    void Shoot()
    {
        if (canShot && ammo > 0)
        {
            if (camara1)
            {
                // Instanciar el proyectil en el firePoint
                GameObject projectile = Instantiate(projectilePrefab, firePoint1.position, weapon1.transform.rotation);

                // Calcular dirección hacia la mira
                Vector3 direction = (mira.transform.position - firePoint1.position).normalized;

                // Aplicar velocidad al proyectil
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.linearVelocity = direction * projectileSpeed;
                canShot = false;
                Invoke("Cooldown", coolD);
                ammo -= 1;
            }
            else if (camara2)
            {
                // Instanciar el proyectil en el firePoint
                GameObject projectile = Instantiate(projectilePrefab, firePoint2.position, weapon2.transform.rotation);

                // Calcular dirección hacia la mira
                Vector3 direction = (mira.transform.position - firePoint2.position).normalized;

                // Aplicar velocidad al proyectil
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.linearVelocity = direction * projectileSpeed;
                canShot = false;
                Invoke("Cooldown", coolD);
                ammo -= 1;
            }
            else if (camara3)
            {
                // Instanciar el proyectil en el firePoint
                GameObject projectile = Instantiate(projectilePrefab, firePoint3.position, weapon3.transform.rotation);

                // Calcular dirección hacia la mira
                Vector3 direction = (mira.transform.position - firePoint3.position).normalized;

                // Aplicar velocidad al proyectil
                Rigidbody rb = projectile.GetComponent<Rigidbody>();
                rb.linearVelocity = direction * projectileSpeed;
                canShot = false;
                Invoke("Cooldown", coolD);
                ammo -= 1;
            }
        }
    }

    void Cooldown()
    {
        canShot = true;
    }
}
