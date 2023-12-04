using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithStatues : MonoBehaviour
{
    [SerializeField] private List<string> interactiveStatues = null;
    [SerializeField] private Text tipText = null;

    [SerializeField] private SwitcherPlayer switcherPlayer = null;
    private int isPlayerNear = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == interactiveStatues[0])
        {
            tipText.text = "press R";
            tipText.color = Color.green;
            tipText.gameObject.SetActive(true);
            isPlayerNear = 1;
        }
        else if(collision.gameObject.tag == interactiveStatues[1])
        {
            tipText.text = "press R";
            tipText.color = Color.green;
            tipText.gameObject.SetActive(true);
            isPlayerNear = 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == interactiveStatues[0])
        {
            isPlayerNear = 0;
        }
        else if (collision.gameObject.tag == interactiveStatues[1])
        {
            isPlayerNear = 0;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            switch (isPlayerNear)
            {
                case 1:
                    switcherPlayer.SwitchPlayer(1);
                    break;
                case 2:
                    switcherPlayer.SwitchPlayer(2);
                    break;
            }
        }
    }
}
