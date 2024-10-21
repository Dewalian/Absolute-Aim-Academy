using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("Level Select 1");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
