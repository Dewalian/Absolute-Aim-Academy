using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject audioManager;

    void Awake()
    {
        if(GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        if(AudioManager.instance == null){
            Instantiate(audioManager);
        }

        Time.timeScale = 1;
    }
}
