using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    protected void EndMinigame(int result)
    {
        EventManager.Inst.miniGameResult = result;
        EventManager.Inst.eventPopUpWindow.GetComponent<EventPopUp>().InitResult();
        Destroy(gameObject);
    }
}
