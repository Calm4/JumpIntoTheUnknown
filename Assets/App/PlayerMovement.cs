using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    public event Action<bool> OnPlayerMove;
    
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        float movementDirectionX = Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(movementDirectionX * speed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = velocity;
        Debug.Log(_rigidbody2D.velocity.magnitude);
        if (_rigidbody2D.velocity.magnitude != 0)
        {
            OnPlayerMove?.Invoke(true);
            Flip(movementDirectionX);
        }
        else
        {
            OnPlayerMove?.Invoke(false);
        }
    }
    void Flip(float movementDirectionX)
    {
        if (movementDirectionX > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (movementDirectionX < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
