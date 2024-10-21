using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    public void StartGame(){
        SceneManager.LoadScene(GameManager.instance.currentStage);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void VolumeMusic()
    {
        AudioManager.instance.VolumeMusic(musicSlider.value);
    }

    public void VolumeSFX()
    {
        AudioManager.instance.VolumeSFX(sfxSlider.value);
    }

    public void Settings(){
        if(settingsPanel.activeSelf == true){
            settingsPanel.SetActive(false);
        }else{
            settingsPanel.SetActive(true);
        }
    }

    public void NewGame(){
        GameManager.instance.NewGame();
    }

}
