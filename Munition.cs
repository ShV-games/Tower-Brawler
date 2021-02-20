using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Munition : MonoBehaviour
{

    public GameObject Player;
    public Canvas GameOver;
    public GameObject Munitions;




    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.collider.name == "Player")
        {
            Player.SetActive(false);
            GameOver.gameObject.SetActive(true);
            Munitions.SetActive(false);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
