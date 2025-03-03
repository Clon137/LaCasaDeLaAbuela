using UnityEngine;
using UnityEngine.SceneManagement;

[SerializeField]
class ProjectileControl : MonoBehaviour
{
    public float lifeTime = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Destruction", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy1")
        {
            EnemyPersonalControl enemyVar = other.gameObject.GetComponent<EnemyPersonalControl>();
            if (enemyVar == null)
            {
                enemyVar = other.gameObject.GetComponentInParent<EnemyPersonalControl>();
            }
            enemyVar.Damage();
            Destroy(gameObject);
            OleadaController.sumarPuntos();
        }
        if (other.gameObject.tag == "Enemy2")
        {
            SlimeControl slimeVar = other.gameObject.GetComponent<SlimeControl>();
            slimeVar.Damage();
            Destroy(gameObject);
            OleadaController.sumarPuntos();
        }
        if (other.gameObject.tag == "EnemyPan")
        {
            PanController panVar = other.gameObject.GetComponent<PanController>();
            panVar.Damage();
            Destroy(gameObject);
            OleadaController.sumarPuntos();
        }
        if (other.gameObject.tag == "Ciervo")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void Destruction()
    {
        Destroy(gameObject);
    }
}
