using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditorInternal;
using UnityEngine;

public class Gegner_KI : MonoBehaviour
{
    bool idle;
    bool walking;
    bool turn;
    bool attacking;
    bool player_in_range;
    public bool flipX;

    Rigidbody2D gegnerRB;
    float wait_between_action_min;
    float wait_between_action_max;
    public float speed;
    public float speedl;
    float huntSpeed;
    float minTime;
    float timer;
    public float times = 0f;
    public float cooldown = 3f;

    int chance_to_get_idle;
    int chance_to_leave_idle;
    int chance_to_keep_direction;
    int chance_to_turn;

    public Transform player;
    public SpriteRenderer rend;
    public GameObject gegner;

    //Die Angriffdinger#################
    public Transform Bulletspawn;
    public Transform Bulletspawnl;
    Rigidbody2D clone;
    public Rigidbody2D bulletPrefap;
    public float bulletSpeed = 100f;
    public float bulletSpeedl = -100f;
    //###################################

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>();
        rend = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Awake()
    {
        chance_to_get_idle = 5;
        chance_to_leave_idle = 10;
        chance_to_turn = 40;
        chance_to_keep_direction = 45;

        wait_between_action_min = 1f;
        wait_between_action_max = 5f;

        speed = 1f;
        huntSpeed = 0.5f;
    }
    private void Update()
    {
        //start idle###################################################################################################################
        if (idle == false && turn == false && player_in_range == false && player_in_range == false && (int)UnityEngine.Random.Range(0, 101) <= chance_to_get_idle && timer >= minTime)
        {
            idle = true;
            timer = 0f;
            minTime = (float)UnityEngine.Random.Range(wait_between_action_min, wait_between_action_max);
        }
        else if (idle == true && (int)UnityEngine.Random.Range(0, 101) <= chance_to_leave_idle && timer >= minTime && turn == false)
        {
            idle = false;
            timer = 0f;
            minTime = (float)UnityEngine.Random.Range(wait_between_action_min, wait_between_action_max);
        }
        //Ende idle#####################################################################################################################

        //Start Laufen##################################################################################################################

        if(idle == false && attacking == false && walking == false || idle == false && attacking == true && walking == false)
        {
            walking = true;
        }
        if(walking == true)
        {
            var moveAmount = speed * Time.deltaTime;
            transform.localPosition += transform.right * moveAmount;
        }
        times += Time.deltaTime;
    }

    //Spieler sehen#####################################################
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if(player.transform.position.x < gegner.transform.position.x)
            {
                rend.flipX = true;
                speed = speedl;
                flipX = true;
            }
            else if(player.transform.position.x > gegner.transform.position.x && speed > 0)
            {
                rend.flipX = false;
                flipX = false;
            }
            else if(player.transform.position.x > gegner.transform.position.x && speed < 0)
            {
                rend.flipX = false;
                speed = speed * -1;
                flipX = false;
            }

            //Bereit zum Angriff#######################################

            if (attacking == false)
            {
                player_in_range = true;
                attacking = true;
            }


            if (attacking == true && flipX == false)
            {
                Attack();
            }
            if(attacking == true && flipX == true)
            {
                Attackl();
            }

            //Bereit zum Angriff#######################################

        }
        
    }
    //Spieler sehen ende################################################

    //Start Hindernisse sehen###########################################

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Wandl")
        {
            var cd = gegnerRB.velocity;

            cd.x = speed * -1;
            rend.flipX = false;
        }
    }

    //Spieler verlieren#################################################

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            attacking = false;
        }
    }

    //Spieler angreifen#################################################
    public void Attack()
    {
        if(times > 1f)
        {
            clone = Instantiate(bulletPrefap, Bulletspawn.position, Bulletspawn.rotation);
            clone.AddForce(Bulletspawn.transform.right * bulletSpeed);
            times = 0f;
        }  
    }              //Je nachdem in welcher Richtung sich der Spieler zum Gegner befindet
    public void Attackl()
    {
        if(times > 1.5f)
        {
            clone = Instantiate(bulletPrefap, Bulletspawnl.position, Bulletspawnl.rotation);
            clone.AddForce(Bulletspawnl.transform.right * bulletSpeedl);
            times = 0f;
        }
    }

    //Spieler angreifen ende############################################
}
