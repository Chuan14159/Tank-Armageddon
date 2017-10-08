using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//please remember to put all Scenes into the Build Settings
public class ButtonManager : MonoBehaviour {

    public void Start()
    {

    }
    public void Pausing()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            return;
        }
        Time.timeScale = 0;
        return;
    } 
    public void NewGameButton(){
        Time.timeScale = 1;
        GameDecider.score = 0;
        GameDecider.health = 3;
        SceneManager.LoadScene ("GameMenu");
	}
    public void StartGame()
    {
        SceneManager.LoadScene("TransitionT");

    }
    public void ResetGame()
    {
        SceneManager.LoadScene("TScene");

    }

}
