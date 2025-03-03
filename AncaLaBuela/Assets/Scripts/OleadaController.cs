using UnityEngine;
using TMPro;

public class OleadaController : MonoBehaviour
{
    public EnemyController EC;
    public GameObject EContenedor;
    [SerializeField] int oleadaCount = 1;
    float oleadaTime = 120;
    public bool oleadaGoing = false;
    float restTime = 30;
    [SerializeField] TMP_Text Oleada, puntos;
    [SerializeField] GameObject puerta;
    public static int Puntos = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EContenedor = GameObject.Find("EnemyControl");
        EC = EContenedor.GetComponent<EnemyController>();
        Invoke("StartOleada", 10);
        Oleada.text = "Oleada " + oleadaCount;
        puntos.text = Puntos + " puntos";
    }

    // Update is called once per frame
    void Update()
    {
        if (oleadaGoing)
        {
            oleadaTime -= Time.deltaTime;
            Oleada.text = "Oleada " + oleadaCount + " Tiempo: " + oleadaTime.ToString("0");
        }
        else if (oleadaCount >= 2)
        {
            if (oleadaCount > 6)
            {
                Oleada.text = "Nivel Completado";
                puerta.transform.rotation *= Quaternion.Euler(0, 135, 0);
            }
            restTime -= Time.deltaTime;
            Oleada.text = "Prepárate " + restTime.ToString("0");
            if (restTime <= 0) { StartOleada(); }
        }
        if (oleadaTime <= 0)
        {
            EndOleada();
            oleadaCount += 1;
            oleadaTime = 120;
        }
        puntos.text = Puntos + " puntos";
    }

    void StartOleada()
    {
        restTime = 30;
        oleadaGoing = true;
        if (oleadaCount == 2)
        {
            EC.cooldownMax = 12;
            EC.maxRandom = 4;
        }
        if (oleadaCount == 3)
        {
            EC.cooldownMax = 10;
            EC.maxRandom = 5;            
        }
        if (oleadaCount == 4)
        {
            EC.cooldownMax = 8;
            EC.maxRandom = 6;            
        }
        if (oleadaCount == 5)
        {
            EC.cooldownMax = 8;
            EC.maxRandom = 7;            
        }
        if (oleadaCount == 6)
        {
            EC.cooldownMax = 8;
            // EC.maxRandom = 8;            
        }
    }

    void EndOleada()
    {
        oleadaGoing = false;
    }
    public static void sumarPuntos(){
        Puntos += 10;
    }
}
