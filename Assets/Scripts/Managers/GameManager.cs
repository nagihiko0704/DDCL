using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public Player player;

    void Awake()
    {
        player = new Player();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
