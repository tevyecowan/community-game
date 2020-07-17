﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{

    public float displayTime = 4.0f;
    public GameObject dialogueBox;
    float timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogueBox.SetActive(false);
            }
        }
    }

    public void DisplayDialogue()
    {
        timerDisplay = displayTime;
        dialogueBox.SetActive(true);
    }
}
