using UnityEngine;

public class OleadaController : MonoBehaviour
{
    public EnemyController EC;
    public GameObject EContenedor;
    int oleadaCount = 1;
    float oleadaTime = 120;
    bool oleadaGoing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EContenedor = GameObject.Find("EnemyControl");
        EC = EContenedor.GetComponent<EnemyController>();
        Invoke("StartOleada", 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (oleadaGoing) {oleadaTime -= Time.deltaTime;}
        if (oleadaTime <= 0)
        {
            EndOleada();
            oleadaCount += 1;
            oleadaTime = 120;
        }
    }

    void StartOleada()
    {
        oleadaGoing = true;        
        if (oleadaCount == 2) {EC.cooldownMax = 12;}
    }

    void EndOleada()
    {
        oleadaGoing = false;
        Invoke("StartOleada", 30);
    }
}
