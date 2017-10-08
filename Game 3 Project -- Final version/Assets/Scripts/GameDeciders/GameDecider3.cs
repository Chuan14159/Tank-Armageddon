using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDecider3 : MonoBehaviour {
	public Text countText;
	public Text timeText;
    public Text enemiesRemainingText;
    // Use this for initialization
    public GameObject[] Enemies;
    private int next_level3 = 0;

    void Start () {
		setCountText ();
        next_level3 = GameDecider.score;
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameDecider.currentTime = 0;
        foreach (GameObject t in Enemies)
        {
            Destroy(t);
        }

    }
	// indicators for w readability  clean sphere
    // Update is called once per frame
    void Update () {
		setCountText ();
		GameDecider.currentTime +=  1*Time.deltaTime;
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (GameDecider.health <= 0 || GameDecider.currentTime >=25)
        {
            foreach (GameObject t in Enemies)
            {
                Destroy(t);
            }
            //Destroy(Player);
            SceneManager.LoadScene("Loser...");
        }
        if ((GameDecider.score -next_level3) >= 15)
        {
            foreach (GameObject t in Enemies)
            {
                Destroy(t);
            }
            //Destroy(Player);
            SceneManager.LoadScene("Winner!");
        }
	}
	void setCountText(){
		countText.text = "Score :" + (GameDecider.score).ToString ();
        timeText.text = "Time: " + (25 - GameDecider.currentTime).ToString();
        enemiesRemainingText.text = "Enemies Remaining: " + (15- (GameDecider.score - next_level3)).ToString();
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
