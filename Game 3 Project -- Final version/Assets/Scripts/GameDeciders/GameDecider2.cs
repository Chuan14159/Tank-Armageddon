using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDecider2 : MonoBehaviour {
	public Text countText;
	public Text timeText;
    public Text enemiesRemainingText;
    public GameObject[] Enemies;
    private int next_level = 0;
    void Start () {
		setCountText ();
        GameDecider.currentTime = 0;
        next_level = GameDecider.score;
    }
    // Update is called once per frame
    void Update () {
		setCountText ();
		GameDecider.currentTime +=  1*Time.deltaTime;
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (GameDecider.health <= 0 || GameDecider.currentTime >=30)
        {
            foreach (GameObject t in Enemies)
            {
                Destroy(t);
            }
            SceneManager.LoadScene("Loser...");
        }
        if ((GameDecider.score-next_level) >= 15)
        {
            foreach (GameObject t in Enemies)
            {
                Destroy(t);
            }
            SceneManager.LoadScene("TransitionL3");
        }
	}
	void setCountText(){
		countText.text = "Score :" + (GameDecider.score).ToString ();
        timeText.text = "Time: " + (30-GameDecider.currentTime).ToString();
        enemiesRemainingText.text = "Enemies Remaining: " + (15 - (GameDecider.score - next_level)).ToString();
        if (GameDecider.currentTime >= 10 && timeText.color != Color.yellow)
        {
            timeText.color = Color.yellow;
            countText.color = Color.yellow;
        }
        if (GameDecider.currentTime >= 20 && timeText.color != Color.red)
        {
            timeText.color = Color.red;
            countText.color = Color.red;
        }

    }
}