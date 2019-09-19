using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulbCatch : MiniGame
{
    public Transform bulb;
    public Button buttonStop;

    public float bulbSpeed = 500f;
    public float direction = 1f;

    public float[] bulbMiniGameScore = new float[3];

    public int bulbGameNum = 0;
    
    void Update()
    {
        if (bulb.localPosition.x > 350f
            || bulb.localPosition.x < -350f)
        {
            direction *= -1;
        }

        bulb.Translate(Vector3.right * direction * bulbSpeed * Time.deltaTime);
    }

    public void OnStopButtonClick()
    {
        bulbGameNum++;

        Debug.Log("bulbGameNum: " + bulbGameNum);

        if (bulbGameNum <= 3)
        {
            if (bulb.localPosition.x >= -60 && bulb.localPosition.x <= 60)
            {
                bulbMiniGameScore[bulbGameNum - 1] = 4f;
            }
            else if (bulb.localPosition.x >= -160 && bulb.localPosition.x <= 160)
            {
                bulbMiniGameScore[bulbGameNum - 1] = 2f;
            }
            else
            {
                bulbMiniGameScore[bulbGameNum - 1] = 0f;
            }

            if (bulbGameNum == 3)
            {
                float score = 0;

                for (int i = 0; i < 3; i++)
                {
                    score += bulbMiniGameScore[i];
                }

                int result = 0;
                if (score >= 10)
                {
                    result = 0;
                }
                else if (score >= 8)
                {
                    result = 1;
                }
                else
                {
                    result = 2;
                }

                EndMinigame(result);
            }
        }

        if (bulbGameNum <= 2)
        {
            Vector2 bulbPosition = bulb.localPosition;
            bulbPosition.x = -350;
            bulb.localPosition = bulbPosition;
            direction = 1f;
        }
    }
}
