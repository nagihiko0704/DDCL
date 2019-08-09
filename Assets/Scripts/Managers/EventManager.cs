using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : SingletonBehaviour<EventManager>
{
    public GameObject CanvasEventPopUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InsertEvent()
    {

    }


    public void ApplyEventEffect(string methodName)
    {
        Invoke(methodName, 0f);
    }

    //Event method

    public void MiniGameBulbCatch()
    {
        
    }
}
