using UnityEngine;

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
            enemyVar.Damage();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy2")
        {
            SlimeControl slimeVar = other.gameObject.GetComponent<SlimeControl>();
            slimeVar.Damage();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "EnemyPan")
        {
            PanController panVar = other.gameObject.GetComponent<PanController>();
            panVar.Damage();
            Destroy(gameObject);
        }
    }

    void Destruction()
    {
        Destroy(gameObject);
    }
}
