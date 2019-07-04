using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public Player player;

    //for acheivement
    public List<int> eventLog = new List<int>();
    public List<Task> taskLog = new List<Task>();


    //for lecture choice score
    public int lectureChoiceScore;

    void Awake()
    {
        player = new Player();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
