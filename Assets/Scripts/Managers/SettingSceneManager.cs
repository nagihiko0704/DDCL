using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingSceneManager : MonoBehaviour
{
    //0: setting 1: creator
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickHomeButton()
    {
        SceneManager.LoadScene(7);
    }

    public void OnClickCreatorButton()
    {
        canvas.SetActive(true);
    }

    public void OnClickBackButton()
    {
        //????!!!!
    }

    public void OnClickCreatorBackButton()
    {
        canvas.SetActive(false);
    }
}
