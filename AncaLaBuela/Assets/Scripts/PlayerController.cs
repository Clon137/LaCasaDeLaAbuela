using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameObject player;
    [SerializeField] float moveSpeed = 7;
    [SerializeField] Camera cam;
    private Vector3 CamForward;
    private Vector3 CamRight;
    private Vector3 MoverPlayer;
    private Vector3 playerInput;
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
    [SerializeField] GameObject weaponCont;
    [SerializeField] int precioCompra = 400;
    [SerializeField] GameObject weaponCanvas;
    bool weaponS = false;
    [SerializeField] GameObject vidaCanvas;
    bool vidaT = false;
    [SerializeField] int precioVida = 50;

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
    [SerializeField] Transform firePointf1;
    [SerializeField] Transform firePointf2;
    [SerializeField] Transform firePointf3;
    [SerializeField] float coolD = 1f;
    bool canShot = true;

    public static int ammo = 5;
    string[] arma;
    int armaNum = 0;

    [Header("HUD")]
    [SerializeField] GameObject vidaON1;
    [SerializeField] GameObject vidaON2;
    [SerializeField] GameObject vidaON3;
    [SerializeField] GameObject vidaON4;
    [SerializeField] GameObject vidaON5;
    [SerializeField] GameObject vidaOFF1;
    [SerializeField] GameObject vidaOFF2;
    [SerializeField] GameObject vidaOFF3;
    [SerializeField] GameObject vidaOFF4;
    [SerializeField] GameObject vidaOFF5;
    int vidas = 5;
    [SerializeField] GameObject MunicionON1;
    [SerializeField] GameObject MunicionON2;
    [SerializeField] GameObject MunicionON3;
    [SerializeField] GameObject MunicionON4;
    [SerializeField] GameObject MunicionON5;
    [SerializeField] GameObject MunicionOFF1;
    [SerializeField] GameObject MunicionOFF2;
    [SerializeField] GameObject MunicionOFF3;
    [SerializeField] GameObject MunicionOFF4;
    [SerializeField] GameObject MunicionOFF5;
    [SerializeField] GameObject MunTextCont;
    [SerializeField] TMP_Text MunText;
    [Header("Sonidos")]
    AudioSource Recarga;
    [SerializeField] AudioClip sndInteract, sndReload, sndShoot, sndDamage, sndPickup, sndLight, sndradio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Recarga = GetComponent<AudioSource>();

        ventanaCanvas1.SetActive(false);
        ventanaCanvas2.SetActive(false);
        ventanaCanvas3.SetActive(false);
        ammoCanvas.SetActive(false);
        weaponCanvas.SetActive(false);
        vidaCanvas.SetActive(false);

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
        MunTextCont.SetActive(false);
        // arma[0] = "pistola";
        // arma[1] = "escopeta";
        // arma[2] = "fusil";
        armaNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);


        MyInput();
        SpeedControl();
        CamDirection();

        MoverPlayer = playerInput.x * CamRight + playerInput.z * CamForward;
        player.transform.LookAt(player.transform.position + MoverPlayer);

        HUDf();

        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;

    }

    void CamDirection()
    {
        CamForward = cam.transform.forward;
        CamRight = cam.transform.right;
        CamForward.y = 0;
        CamRight.y = 0;
        CamForward = CamForward.normalized;
        CamRight = CamRight.normalized;
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
                player.SetActive(false);
            }
            else if (!camara2 && ventana2)
            {
                camera2.SetActive(true);
                mira.SetActive(true);
                camara2 = true;
                weapon2.SetActive(true);
                player.SetActive(false);
            }
            else if (!camara3 && ventana3)
            {
                camera3.SetActive(true);
                mira.SetActive(true);
                camara3 = true;
                weapon3.SetActive(true);
                player.SetActive(false);
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
                player.SetActive(true);
            }
        }
        //Recargar
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (ammoCanvas)
            {
                if (OleadaController.pistol)
                {
                    ammo = 5;
                }
                else
                {
                    ammo = 30;
                }
                Recarga.Play();
            }
            if (weaponS)
            {
                if (OleadaController.Puntos >= precioCompra)
                {
                    OleadaController.Puntos -= precioCompra;
                    ammo = 30;
                    OleadaController.pistol = false;
                    Destroy(weaponCont);
                    MunTextCont.SetActive(true);
                    HUDf();
                    weaponS = false;
                }
            }
            if (vidaT)
            {
                if (OleadaController.Puntos >= precioVida)
                {
                    OleadaController.Puntos -= precioCompra;
                    vidas++;                    
                    Vida();                    
                }
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
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

            // if (moveDirection != Vector3.zero)
            // { 
            //     // rb.freezeRotation = false; 
            //     Quaternion deltaRotation = Quaternion.Euler(moveDirection * 100 * Time.deltaTime);
            //     rb.MoveRotation(rb.rotation * deltaRotation);
            //     // rb.freezeRotation = true; 
            // }

        }

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
            Recarga.PlayOneShot(sndInteract);

        }
        if (other.gameObject.tag == "ArmaCompra")
        {
            weaponCanvas.SetActive(true);
            weaponS = true;
            Recarga.PlayOneShot(sndPickup);

        }
        if (other.gameObject.tag == "Vida")
        {
            vidaCanvas.SetActive(true);
            vidaT = true;
        }
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Level2");
        }
    }
    //aparecen los interactuadores
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
        if (other.gameObject.tag == "ArmaCompra")
        {
            weaponCanvas.SetActive(false);
            weaponS = false;
        }
        if (other.gameObject.tag == "Vida")
        {
            vidaCanvas.SetActive(false);
            vidaT = false;
        }
    }

    void Shoot()
    {
        if (canShot && ammo > 0)
        {
            if (camara1)
            {
                if (OleadaController.pistol)
                {
                    Recarga.PlayOneShot(sndShoot);

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
                else
                {
                    Recarga.PlayOneShot(sndShoot);

                    // Instanciar el proyectil en el firePoint
                    GameObject projectile = Instantiate(projectilePrefab, firePointf1.position, weapon1.transform.rotation);

                    // Calcular dirección hacia la mira
                    Vector3 direction = (mira.transform.position - firePointf1.position).normalized;

                    // Aplicar velocidad al proyectil
                    Rigidbody rb = projectile.GetComponent<Rigidbody>();
                    rb.linearVelocity = direction * projectileSpeed;
                    canShot = false;
                    Invoke("Cooldown", coolD);
                    ammo -= 1;
                }
            }
            else if (camara2)
            {
                if (OleadaController.pistol)
                {
                    Recarga.PlayOneShot(sndShoot);

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
                else
                {
                    Recarga.PlayOneShot(sndShoot);

                    // Instanciar el proyectil en el firePoint
                    GameObject projectile = Instantiate(projectilePrefab, firePointf2.position, weapon2.transform.rotation);

                    // Calcular dirección hacia la mira
                    Vector3 direction = (mira.transform.position - firePointf2.position).normalized;

                    // Aplicar velocidad al proyectil
                    Rigidbody rb = projectile.GetComponent<Rigidbody>();
                    rb.linearVelocity = direction * projectileSpeed;
                    canShot = false;
                    Invoke("Cooldown", coolD);
                    ammo -= 1;
                }
            }
            else if (camara3)
            {
                if (OleadaController.pistol)
                {
                    Recarga.PlayOneShot(sndShoot);

                    // Instanciar el proyectil en el firePoint
                    GameObject projectile = Instantiate(projectilePrefab, firePoint3.position, weapon3.transform.rotation);

                    // Calcular direccion hacia la mira
                    Vector3 direction = (mira.transform.position - firePoint3.position).normalized;

                    // Aplicar velocidad al proyectil
                    Rigidbody rb = projectile.GetComponent<Rigidbody>();
                    rb.linearVelocity = direction * projectileSpeed;
                    canShot = false;
                    Invoke("Cooldown", coolD);
                    ammo -= 1;
                }
                else
                {
                    Recarga.PlayOneShot(sndShoot);

                    // Instanciar el proyectil en el firePoint
                    GameObject projectile = Instantiate(projectilePrefab, firePointf3.position, weapon3.transform.rotation);

                    // Calcular direccion hacia la mira
                    Vector3 direction = (mira.transform.position - firePointf3.position).normalized;

                    // Aplicar velocidad al proyectil
                    Rigidbody rb = projectile.GetComponent<Rigidbody>();
                    rb.linearVelocity = direction * projectileSpeed;
                    canShot = false;
                    Invoke("Cooldown", coolD);
                    ammo -= 1;
                }
            }
        }
    }

    void Cooldown()
    {
        canShot = true;
    }

    //Las balas encendiendose y apagandose
    void HUDf()
    {
        if (OleadaController.pistol)
        {
            if (ammo == 5)
            {
                MunicionON1.SetActive(true);
                MunicionON2.SetActive(true);
                MunicionON3.SetActive(true);
                MunicionON4.SetActive(true);
                MunicionON5.SetActive(true);
                MunicionOFF1.SetActive(false);
                MunicionOFF2.SetActive(false);
                MunicionOFF3.SetActive(false);
                MunicionOFF4.SetActive(false);
                MunicionOFF5.SetActive(false);
            }
            else if (ammo == 4)
            {
                MunicionON1.SetActive(true);
                MunicionON2.SetActive(true);
                MunicionON3.SetActive(true);
                MunicionON4.SetActive(true);
                MunicionON5.SetActive(false);
                MunicionOFF1.SetActive(false);
                MunicionOFF2.SetActive(false);
                MunicionOFF3.SetActive(false);
                MunicionOFF4.SetActive(false);
                MunicionOFF5.SetActive(true);
            }
            else if (ammo == 3)
            {
                MunicionON1.SetActive(true);
                MunicionON2.SetActive(true);
                MunicionON3.SetActive(true);
                MunicionON4.SetActive(false);
                MunicionON5.SetActive(false);
                MunicionOFF1.SetActive(false);
                MunicionOFF2.SetActive(false);
                MunicionOFF3.SetActive(false);
                MunicionOFF4.SetActive(true);
                MunicionOFF5.SetActive(true);
            }
            else if (ammo == 2)
            {
                MunicionON1.SetActive(true);
                MunicionON2.SetActive(true);
                MunicionON3.SetActive(false);
                MunicionON4.SetActive(false);
                MunicionON5.SetActive(false);
                MunicionOFF1.SetActive(false);
                MunicionOFF2.SetActive(false);
                MunicionOFF3.SetActive(true);
                MunicionOFF4.SetActive(true);
                MunicionOFF5.SetActive(true);
            }
            else if (ammo == 1)
            {
                MunicionON1.SetActive(true);
                MunicionON2.SetActive(false);
                MunicionON3.SetActive(false);
                MunicionON4.SetActive(false);
                MunicionON5.SetActive(false);
                MunicionOFF1.SetActive(false);
                MunicionOFF2.SetActive(true);
                MunicionOFF3.SetActive(true);
                MunicionOFF4.SetActive(true);
                MunicionOFF5.SetActive(true);
            }
            else if (ammo <= 0)
            {
                MunicionON1.SetActive(false);
                MunicionON2.SetActive(false);
                MunicionON3.SetActive(false);
                MunicionON4.SetActive(false);
                MunicionON5.SetActive(false);
                MunicionOFF1.SetActive(true);
                MunicionOFF2.SetActive(true);
                MunicionOFF3.SetActive(true);
                MunicionOFF4.SetActive(true);
                MunicionOFF5.SetActive(true);
            }
        }
        else
        {
            MunicionON1.SetActive(true);
            MunicionON2.SetActive(false);
            MunicionON3.SetActive(false);
            MunicionON4.SetActive(false);
            MunicionON5.SetActive(false);
            MunicionOFF1.SetActive(false);
            MunicionOFF2.SetActive(false);
            MunicionOFF3.SetActive(false);
            MunicionOFF4.SetActive(false);
            MunicionOFF5.SetActive(false);
            MunTextCont.SetActive(true);
            MunText.text = "x " + ammo;
        }
    }

    public void Damage()
    {
        Recarga.PlayOneShot(sndDamage);
        vidas--;
        Vida();
        if (vidas < 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void Vida()
    {
        if (vidas == 5)
        {
            vidaON1.SetActive(true);
            vidaON2.SetActive(true);
            vidaON3.SetActive(true);
            vidaON4.SetActive(true);
            vidaON5.SetActive(true);
            vidaOFF1.SetActive(false);
            vidaOFF2.SetActive(false);
            vidaOFF3.SetActive(false);
            vidaOFF4.SetActive(false);
            vidaOFF5.SetActive(false);
        }
        else if (vidas == 4)
        {
            vidaON1.SetActive(true);
            vidaON2.SetActive(true);
            vidaON3.SetActive(true);
            vidaON4.SetActive(true);
            vidaON5.SetActive(false);
            vidaOFF1.SetActive(false);
            vidaOFF2.SetActive(false);
            vidaOFF3.SetActive(false);
            vidaOFF4.SetActive(false);
            vidaOFF5.SetActive(true);
        }
        else if (vidas == 3)
        {
            vidaON1.SetActive(true);
            vidaON2.SetActive(true);
            vidaON3.SetActive(true);
            vidaON4.SetActive(false);
            vidaON5.SetActive(false);
            vidaOFF1.SetActive(false);
            vidaOFF2.SetActive(false);
            vidaOFF3.SetActive(false);
            vidaOFF4.SetActive(true);
            vidaOFF5.SetActive(true);
        }
        else if (vidas == 2)
        {
            vidaON1.SetActive(true);
            vidaON2.SetActive(true);
            vidaON3.SetActive(false);
            vidaON4.SetActive(false);
            vidaON5.SetActive(false);
            vidaOFF1.SetActive(false);
            vidaOFF2.SetActive(false);
            vidaOFF3.SetActive(true);
            vidaOFF4.SetActive(true);
            vidaOFF5.SetActive(true);
        }
        else if (vidas == 1)
        {
            vidaON1.SetActive(true);
            vidaON2.SetActive(false);
            vidaON3.SetActive(false);
            vidaON4.SetActive(false);
            vidaON5.SetActive(false);
            vidaOFF1.SetActive(false);
            vidaOFF2.SetActive(true);
            vidaOFF3.SetActive(true);
            vidaOFF4.SetActive(true);
            vidaOFF5.SetActive(true);
        }
        else
        {
            vidaON1.SetActive(false);
            vidaON2.SetActive(false);
            vidaON3.SetActive(false);
            vidaON4.SetActive(false);
            vidaON5.SetActive(false);
            vidaOFF1.SetActive(true);
            vidaOFF2.SetActive(true);
            vidaOFF3.SetActive(true);
            vidaOFF4.SetActive(true);
            vidaOFF5.SetActive(true);
        }
    }
}
