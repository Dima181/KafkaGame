using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door; // ������ �� �����, ������� ����� �������
    private bool isPlayerNear = false;
    private bool isLeverActive = false;

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            isLeverActive = !isLeverActive;
            RotateLever();
            door.GetComponent<Door>().OpenDoor(isLeverActive);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void RotateLever()
    {
        // �������� ���� �������� ������
        transform.rotation = isLeverActive ? Quaternion.Euler(0, 0, -45) : Quaternion.identity;
    }
}
