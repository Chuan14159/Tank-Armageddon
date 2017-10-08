using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mapcontrol : MonoBehaviour {
    public GameObject player;
    public int stage;

    //instructions
    //public Image ptrqbg;
    //public Image pbrqbg;
    public Text player1;
    public Text player2;
    public Text welcome;
    //stage1
    public GameObject stage1blocknext;
    public GameObject stage1blockself;
    public GameObject stage1finish;

    //stage2
    public GameObject stage2blocknext;
    public GameObject stage2blockself;
    public GameObject stage2finish;

    //stage3
    public GameObject stage3blocknext;
    public GameObject stage3blockself;
    public GameObject stage3finish;

    //stage4
    public GameObject stage4blocknext;
    public GameObject stage4blockself;
    public GameObject stage4finish;
    public GameObject stage4enemy;
    public GameObject stage4enemy2;
    public GameObject stage4enemy3;
    //public GameObject stage4enemyplane;
    public GameObject png1;
    public GameObject png2;
    bool flag = false;
    private GameObject[] Enemies;
    void Start () {
        stage = 1;
        stage4enemy.SetActive(false);
        stage4enemy2.SetActive(false);
        stage4enemy3.SetActive(false);
        //stage4enemyplane.SetActive(false);

        stage4finish.SetActive(false);
	}
	
	void FixedUpdate () {
		if (stage == 1)
        {
            //setblocks
            stage1blocknext.SetActive(true);
            stage1blockself.SetActive(false);
            //setrequests
            player1.text = "Press R to skip tutorial and head to the first level";
            player1.color = Color.red;
            player2.text = "Player 2:HOLD ↑ Up Down  ↓ to move tank forwards and backwards\n\n";
            player2.text += "Player 2:HOLD 0 and ↑ or ↓ key to accelerate \n .(period)to brake \n Touch the goal with the tank to progress";
            //pbrqtxt.fontSize = 8;
            //ptrqtxt.fontSize = 8;
            //isfinish
            if (stage1finish.activeSelf == false)
            {
                stage1blocknext.SetActive(false);
                stage1blockself.SetActive(true);
                //player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                stage += 1;
            }
        }
        if(stage == 2)
        {
            welcome.text = "";
            //setblocks

            stage2blocknext.SetActive(true);
            stage2blockself.SetActive(false);
            player1.color = Color.white;
            player1.text = "Player 1: A and D to rotate turrent left and right";
            player2.text = "Player 2: Use <- -> arrows to rotate tank direction";

            //pbrqtxt.fontSize = 4;
            //ptrqtxt.fontSize = 4;

            //isfinish
            if (stage2finish.activeSelf == false)
            {
                stage2blocknext.SetActive(false);
                stage2blockself.SetActive(true);
                //player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                stage += 1;
            }
        }
        if (stage == 3)
        {
            //setblocks
            stage3blocknext.SetActive(true);
            stage3blockself.SetActive(false);

            //setrequests
            //ptrqbg.enabled = false;
            //pbrqbg.enabled = true;
            //ptrqtxt.text = "";
            player1.text = " Player 1: Press spacebar rapidly to shoot\n";
            player1.text += "Press Q to use shotgun";
            player2.text = "Player 2: Remember to HOLD 0 to accelerate backwards or forwards depending on up down arrow keys\n";
            player2.text+= "\nHOLD.(period) to brake (velocity = 0) \n";

            //isfinish
            if (stage3finish.activeSelf == false)
            {
                stage3blocknext.SetActive(false);
                stage3blockself.SetActive(true);
                //player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                stage += 1;
            }
        }
        if (stage == 4)
        {
            //setblocks


            //setrequests
            player1.text = "Player 1: Aim up and down with W and S keys to kill the plane enemies";
            player1.text += "\nPress Q to use shotgun :) ";
            player2.text = "Kill all enemies to proceed";
            //isfinish
            if (!flag)
            {

                    stage4enemy.SetActive(true);
                    stage4enemy2.SetActive(true);
                    stage4enemy3.SetActive(true);
                    //stage4enemyplane.SetActive(true);
                    stage4finish.SetActive(true);
                    flag = true;
            }
            else
            {
                Enemies =GameObject.FindGameObjectsWithTag("Enemy");
                if (Enemies.Length == 0)
                {

                    //player.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    stage += 1;
                }
            }
        }
        if(stage == 5)
        {
            player1.text = "Congratulations! Head to the goal to start the game \n";
            player1.text += "Once you touch the goal, GET READY!";
            player2.text = "";
            png2.SetActive(false);
            //player1.color = Color.yellow;
            stage4blocknext.SetActive(true);
            stage4blockself.SetActive(false);
            if(stage4finish.activeSelf == false)
            {
                //GameObject Playeroptions = GameObject.FindGameObjectWithTag("Playeroptions");
                //GameObject Player = GameObject.FindGameObjectWithTag("Player");
                //Destroy(Player);
                //Destroy(Playeroptions);
                GameDecider.health = 3;
                SceneManager.LoadScene("Tscene");
            }
        }
	}
}
