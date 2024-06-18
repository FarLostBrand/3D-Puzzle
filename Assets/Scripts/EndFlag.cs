using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    //==============================
    //PUBLIC VARIABLES

    //names of levels
    public string nextSceneName;
    //to know if it's the last level
    public bool lastLevel;
    //==============================

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().SetInt(other.GetComponent<PlayerController>().scoreSaver, other.GetComponent<PlayerController>().score);
            if(lastLevel)
            {
                SceneManager.LoadScene(13);
            }
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
