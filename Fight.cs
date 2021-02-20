using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public GameObject Katana1;
    public GameObject Gegner;
    public float lifespan = 0f;
    public float maxLifespan = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Katana1.SetActive(true);
        }
        if (lifespan >= maxLifespan)
        {
            Katana1.SetActive(false);
            lifespan = 0f;
        }
        if (Katana1.activeInHierarchy)
        {
            lifespan += Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Gegner")
        {
            Gegner.SetActive(false);
        }
    }
}
