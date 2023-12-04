using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float distance = 5f; // Расстояние перемещения от начальной точки
    public float speed = 2f; // Скорость перемещения

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Вычисляем текущую позицию платформы
        float newPos = Mathf.PingPong(Time.time * speed, distance * 2) - distance;
        transform.position = new Vector3(startPos.x + newPos, startPos.y, startPos.z);

        // Изменяем направление движения, если достигли крайних точек
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
