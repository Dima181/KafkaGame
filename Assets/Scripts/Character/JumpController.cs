using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private LayerMask groundLayer = 0;
    [SerializeField] private Transform footPosition;
    [SerializeField] private bool canJump = false;
    private bool isGrounded;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

     private void Update()
     {
         // Проверяем, находится ли персонаж на земле
         isGrounded = Physics2D.OverlapCircle(footPosition.position, 0.5f, groundLayer);

         // Прыжок
         if (isGrounded && Input.GetKeyDown(KeyCode.Space) && canJump)
         {
             rb.AddForce(new Vector2(0f, jumpForce));
         }
     }

}
