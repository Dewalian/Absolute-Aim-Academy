using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoaderCam : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    private float xOffset;
    private float yOffset;

    private void Awake()
    {
        if(GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        Time.timeScale = 1;
    }

    void Start()
    {
        xOffset = LevelManager.instance.columns / 2 - 0.5f;
        yOffset = LevelManager.instance.rows / 2 - 0.5f;

        transform.position = new Vector3(xOffset, yOffset, -10);
    }

    void Update()
    {
        if(GameManager.instance.camState == GameManager.CamState.Top){
            Debug.Log("top");
            CamMove(12);
        }else if(GameManager.instance.camState == GameManager.CamState.Mid){
            CamMove(0);
        }else if(GameManager.instance.camState == GameManager.CamState.Bot){
            CamMove(-12);
        }
    }

    void CamMove(float y){
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(xOffset, yOffset + y, -10), GameManager.instance.transitionTime * Time.deltaTime);
    }
}
