using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HomeManager : MonoBehaviour
{
    /****
     * 0: setting
     * 1: new character
     * 2: existing character
     * 3: achievement
     ****/
    public GameObject[] button = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnclickBuccon0()
    {
        //??????
    }

    void OnclickButton1()
    {
        //scence load "new character" scene.
        //SceneManager.LoadScene();
    }

    void OnClickButton2()
    {
        //scence load main scene???
    }

    void OnClickButton3()
    {
        //scence load "achievement" scene.
        //SceneManager.LoadSecne();
    }
}
