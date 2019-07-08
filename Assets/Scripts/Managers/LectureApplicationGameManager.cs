using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LectureApplicationGameManager : MonoBehaviour
{

    //TODO: count number as button clicked, and go result scene if game ends
    //1. fill AddApplicationCount method
    //2. fill ApplicationEnd method
    //3. if all goes right, delete this
    //4. **add your own annotaiton about variables and methods**


    //you need to add button
    //at lecture application game manager
    //inspector window
    public Button buttonApplication;

    public const int GAME_TIME = 30;
    public float countTime = GAME_TIME;

    private int _clickCount;

    // Start is called before the first frame update
    void Start()
    {
        
        buttonApplication.onClick.AddListener(AddApplicationCount);

    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
        countTime -= time;
        //Debug.Log(countTime);
        if (countTime <= 0)
        {
            Debug.Log(countTime+"   "+_clickCount);
            
            ApplicationEnd();
        }
    }

    private void AddApplicationCount()
    {
        _clickCount++;
        Debug.Log("clickCount:" + _clickCount);

    }
    


    private void ApplicationEnd()
    {
        //if game time is over, go lecture result scene
        //and save score in GameManage

        GameManager.Inst.lectureApplicationScore = _clickCount;
        SceneManager.LoadScene(3);
    }
}
 