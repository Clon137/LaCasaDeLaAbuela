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
            Destroy(other.gameObject);
            Destroy(gameObject); // Destruir el proyectil al impactar
        }
    }

    void Destruction()
    {
        Destroy(gameObject);
    }
}
