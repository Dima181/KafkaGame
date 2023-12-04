using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float offset = 10f;
    [SerializeField] private float speed = 10f;
    private Vector3 openPosition;
    private Vector3 closedPosition;
    private bool isOpening = false;

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = new Vector3(closedPosition.x, closedPosition.y + offset, closedPosition.z); // Высота открытия двери
    }

    public void OpenDoor(bool open)
    {
        if (open && !isOpening)
        {
            StartCoroutine(Open());
        }
        else if (!open && isOpening)
        {
            StartCoroutine(Close());
        }
    }

    private IEnumerator Open()
    {
        isOpening = true;
        while (transform.position != openPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, Time.deltaTime * speed);
            yield return null;
        }
    }

    private IEnumerator Close()
    {
        while (transform.position != closedPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, Time.deltaTime * speed);
            yield return null;
        }
        isOpening = false;
    }
}
