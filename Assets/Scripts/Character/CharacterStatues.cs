using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatues : MonoBehaviour
{
    private SwitcherPlayer switcherPlayer = null;

    void Start()
    {
        switcherPlayer = FindObjectOfType<SwitcherPlayer>();   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            switcherPlayer.SwitchPlayer(0);
    }
}
