using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Bewegung : MonoBehaviour
{
    public int speed = 5;
    public int sprunghöhe = 10;
    public Rigidbody2D myRB;
    private bool Jump = false;
    public Animator animations;
    public SpriteRenderer renderern;
    public GameObject Katana1;
    private float lifespan = 0f;
    public float maxLifespan = 0.5f;
    public float runspeed = 0f;
    public Canvas gameOver;
    public GameObject Player;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>();

        renderern = gameObject.GetComponent<SpriteRenderer>();
    }
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

        if (myRB.velocity.x < -0.1)
        {
            renderern.flipX = true;
            //Zum Angreifen mit dem Katana auf der einen Seite
           
        }
        else
        {
            renderern.flipX = false;
        }
  

        
        var velocity = myRB.velocity;
        if (Input.GetButton("horizontel"))
        {
            velocity.x = speed * Input.GetAxisRaw("horizontel");
            animations.SetFloat("runspeed", Mathf.Abs(velocity.x));
            
        }
        if (Input.GetButton("jump"))
        {
            if (Jump == true)
            {
                velocity.y = sprunghöhe;
                Jump = false;
                animations.SetBool("isjumping", true);
            }
        }
        myRB.velocity = velocity;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Jump = true;
        animations.SetBool("isjumping", false);
       // if(other.gameObject.name == "Gegner")
       // {
      //      Player.SetActive(false);
       //     gameOver.gameObject.SetActive(true);
       // }
    }

}