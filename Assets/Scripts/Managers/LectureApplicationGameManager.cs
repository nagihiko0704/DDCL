using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    private int _clickCount;

    // Start is called before the first frame update
    void Start()
    {
        //add listener here
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    private void AddApplicationCount()
    {
        //use private variable
    }

    private void ApplicationEnd()
    {
        //if game time is over, go lecture result scene
        //and save score in GameManager
    }
}
