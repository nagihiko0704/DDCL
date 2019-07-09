using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LectureList
{
    public Dictionary<string, Task> lectureList = new Dictionary<string, Task>();

    public LectureList()
    {
        //add lecture list: name, type, grade

        this.lectureList.Add("S", new Study("암벽등반", Type.Sport, "S"));
    }
}
