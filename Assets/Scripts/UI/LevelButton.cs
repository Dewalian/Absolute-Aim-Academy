using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int scene;

    public void ChangeScene(){
        SceneManager.LoadScene(scene);
        Debug.Log("test");
    }
}
