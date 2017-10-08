using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialtoLevel1 : MonoBehaviour
{
    public static int health;

    void Start()
    {
        health = GameDecider.health;
    }

    void Update()
    {

        health = GameDecider.health;
        if (health <= 0)
        {
            GameObject [] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            foreach (GameObject t in Enemies)
            {
                Destroy(t);
            }
            //foreach (GameObject t in Bullets)
            //{
            //    Destroy(t);
            //}
            Destroy(Player);

            SceneManager.LoadScene("Loser...");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            GameObject Playeroptions = GameObject.FindGameObjectWithTag("Playeroptions"); 
            foreach (GameObject t in Enemies)
            {
                Destroy(t);
            }
            Destroy(Playeroptions);
            //foreach (GameObject t in Bullets)
            //{
            //    Destroy(t);
            //}
            Destroy(Player);

            SceneManager.LoadScene("TScene");
        }

    }

}


