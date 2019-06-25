using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schedule : MonoBehaviour
{
    public Task[,] taskArray = new Task[6, 7];

    public Schedule()
    {
        for(int row = 0; row < 6; row++)
        {
            for(int col = 0; col < 7; col++)
            {
                this.taskArray[row, col] = new Rest((0, 0));
            }
        }
    }
}
