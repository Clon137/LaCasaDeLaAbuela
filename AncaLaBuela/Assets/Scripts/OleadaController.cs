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
    [SerializeField] TMP_Text Oleada, puntos, radio;
    [SerializeField] GameObject radioPanel;
    [SerializeField] GameObject puerta;
    public static int Puntos = 0;
    int radioCount = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EContenedor = GameObject.Find("EnemyControl");
        EC = EContenedor.GetComponent<EnemyController>();        
        Oleada.text = "Oleada " + oleadaCount;
        puntos.text = Puntos + " puntos";        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            RadioText();
        }
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
                puerta.SetActive(false);
            }
            restTime -= Time.deltaTime;
            Oleada.text = "Prepárate " + restTime.ToString("0");
            if (restTime <= 0) { StartOleada(); }
        }
        if (oleadaTime <= 0)
        {
            EndOleada();
            oleadaCount += 1;
            if (oleadaCount == 7)
            {
                radioCount = 6;
            }
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

    void RadioText()
    {

        if (radioCount == 10)
        {
            radio.text = "Escucha, tienes poco tiempo.";
            radioCount = 0;
        }
        if (radioCount == 0)
        {
            radio.text = "Ya estan viniendo y tienes que estar preparado";
            radioCount++;
        }
        else if (radioCount == 1)
        {
            radio.text = "Asomate a las ventanas y NO dejes que se acerquen";
            radioCount++;
        }
        else if (radioCount == 2)
        {
            radio.text = "Veo que tienes una caja de municion, usala bien";
            radioCount++;
        }
        else if (radioCount == 3)
        {
            radio.text = "Aguanta, tendras un mensaje mio cuando sea seguro salir";
            radioCount++;
        }
        else if (radioCount == 4)
        {            
            radioPanel.SetActive(false);
            radioCount++;
        }
        else if (radioCount == 6)
        {            
            radioPanel.SetActive(true);
            radio.text = "Oye, sal de ahi cagando leches";
            radioCount++;
        }
        else if (radioCount == 7)
        {            
            radio.text = "Ha llegado la hora, nos largamos";
            radioCount++;
        }
        else if (radioCount == 8)
        {            
            radioPanel.SetActive(false);
            radioCount++;
        }
    }
}
