using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndResult : MonoBehaviour
{
    public Text result;
    // Use this for initialization
    void Start()
    {
        string x = SceneManager.GetActiveScene().name;

        if (x == "Loser...")
        {
            result.text = "Game Over! Your final score is: " + (GameDecider.score).ToString();
        }
        else
        {
            result.text = "Congratulations! Your high score is: " + (GameDecider.score).ToString();
        }
    }


}
