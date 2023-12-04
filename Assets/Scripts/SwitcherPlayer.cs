using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SwitcherPlayer : MonoBehaviour
{
    public UnityEvent SwitchedPlayer;

    [SerializeField] private List<CharacterMovement> players = null;

    [SerializeField] private CharacterMovement activePlayer = null;

    [SerializeField] private Text tipText = null;
    public void SwitchPlayer(int sequence)
    {
        if (activePlayer != null)
        {
            activePlayer.GetComponent<CharacterMovement>().enabled = false;
            activePlayer.GetComponent<BoxCollider2D>().enabled = false;
            activePlayer.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }

        players[sequence].GetComponent<CharacterMovement>().enabled = true;
        players[sequence].GetComponent<BoxCollider2D>().enabled = true;
        players[sequence].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;


        activePlayer = players[sequence];

        if (activePlayer.GetComponent<CharacterStatues>())
        {
            tipText.text = "press Q";
            tipText.color = Color.red;
            tipText.gameObject.SetActive(true);
        }
        else
        {
            tipText.gameObject.SetActive(false);
        }

        SwitchedPlayer?.Invoke();
    }
}
