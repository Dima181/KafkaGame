using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float distance = 5f; // ���������� ����������� �� ��������� �����
    public float speed = 2f; // �������� �����������

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // ��������� ������� ������� ���������
        float newPos = Mathf.PingPong(Time.time * speed, distance * 2) - distance;
        transform.position = new Vector3(startPos.x + newPos, startPos.y, startPos.z);

        // �������� ����������� ��������, ���� �������� ������� �����
        if (newPos >= distance)
        {
            movingRight = false;
        }
        else if (newPos <= -distance)
        {
            movingRight = true;
        }
    }
}
