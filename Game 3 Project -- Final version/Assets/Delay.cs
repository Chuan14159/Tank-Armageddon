using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delay : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(waitSpawner());

    }

    IEnumerator waitSpawner()
    {

        if (SceneManager.GetActiveScene().name == "TransitionT")
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Tutorial");
        }
        if (SceneManager.GetActiveScene().name == "TScene")
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("GameScene");

        }
        if (SceneManager.GetActiveScene().name == "TransitionL2")
        {
            yield return new WaitForSeconds(1f);

            SceneManager.LoadScene("GameSceneLevel2");
        }
        if (SceneManager.GetActiveScene().name == "TransitionL3")
        {
            yield return new WaitForSeconds(1f);

            SceneManager.LoadScene("GameSceneLevel3");
        }

    }
}