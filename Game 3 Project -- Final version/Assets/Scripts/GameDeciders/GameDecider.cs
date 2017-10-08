using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDecider : MonoBehaviour {
	public static int score = 0;
    public static int health = 3;
    public Text countText;
    public Text timeText;
    public Text enemiesRemainingText;
    public static float currentTime;
    void Start(){
		currentTime = 0;
        score = 0;
        setCountText();

    }

    void Update () {
        setCountText();
        currentTime += 1*Time.deltaTime;
        GameObject[] Enemies;
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject t = GameObject.FindGameObjectWithTag("Pause");
            t.BroadcastMessage("Pausing");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject t = GameObject.FindGameObjectWithTag("Reset");
            t.BroadcastMessage("NewGameButton");

        }
        if (health <= 0 || currentTime >= 35)
        {
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject t in Enemies)
            {
                Destroy(t);
            }
            SceneManager.LoadScene("Loser...");
        }
        if (score >= 10)
        {
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject t in Enemies)
            {
                Destroy(t);
            }

            SceneManager.LoadScene("TransitionL2");
        }

    }

    void setCountText()
    {
        timeText.text = "Time :" + (35 - currentTime).ToString();
        countText.text = "Score :" + score.ToString();
        enemiesRemainingText.text = "Enemies Remaining: " + (10 - score).ToString();
        if(currentTime >= 10 && timeText.color != Color.yellow)
        {
            timeText.color = Color.yellow;
            countText.color = Color.yellow;
        }
        if (currentTime >= 20 && timeText.color != Color.red)
        {
            timeText.color = Color.red;
            countText.color = Color.red;
        }
    }

}


