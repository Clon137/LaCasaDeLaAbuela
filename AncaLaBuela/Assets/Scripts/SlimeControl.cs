using UnityEngine;

public class SlimeControl : MonoBehaviour
{
    [SerializeField] float health = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage()
    {
        health -= 1;
        if (health < 1)
        {
            Destroy(gameObject);
        }
    }
}
