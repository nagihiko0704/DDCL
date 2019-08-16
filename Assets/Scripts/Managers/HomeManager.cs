using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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

    public void OnclickBuccon0()
    {
        //??????
    }

    public void OnclickButton1()
    {
        //scence load "new character" scene.
        //SceneManager.LoadScene();
    }

    public void OnClickButton2()
    {
        //scence load main scene???
    }

    public void OnClickButton3()
    {
        //scence load "achievement" scene.
        //SceneManager.LoadSecne();
    }
}
