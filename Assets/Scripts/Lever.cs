using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door; // —сылка на дверь, которую нужно открыть
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
        // »зменить угол поворота рычага
        transform.rotation = isLeverActive ? Quaternion.Euler(0, 0, 45) : Quaternion.Euler(0, 0, -45);
        transform.position = isLeverActive ? new Vector3(transform.position.x, 6.67f, transform.position.z) : new Vector3(transform.position.x, 7.44f, transform.position.z);
    }
}
