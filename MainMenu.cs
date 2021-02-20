using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenü;
    public GameObject Weltauswahl;
    public GameObject Welt1lvl;

    public void Welten()
    {
        MainMenü.SetActive(false);
        Weltauswahl.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Welt1()
    {
        Weltauswahl.SetActive(false);
        Welt1lvl.SetActive(true);
    }
    public void Back()
    {
        Welt1lvl.SetActive(false);
        Weltauswahl.SetActive(true);
    }
    public void Lvl1()
    {
        SceneManager.LoadScene("Level-01");
    }
    public void Lvl2()
    {
        SceneManager.LoadScene("Level-02");
    }
}
