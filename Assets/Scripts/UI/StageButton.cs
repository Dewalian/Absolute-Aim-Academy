using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    public bool isNext;
    public void ChangeScene(){
        if(isNext){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
