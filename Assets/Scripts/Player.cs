using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Character playerCharacter;
    public Schedule[] schedules = new Schedule[16];
    
    public Player()
    {
        this.playerCharacter = new Newbie();
        for(int week = 0; week < 16; week++)
        {
            schedules[0] = new Schedule();
        }

        
    }
}
