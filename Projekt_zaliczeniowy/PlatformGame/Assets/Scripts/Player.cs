using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Ustawienia Ruchu")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float maxJumpCharge = 20f;
    [SerializeField] private float chargeSpeed = 25f;
    [SerializeField] private LayerMask groundMask;

    [Header("Audio")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip bounceClip;

    [Header("Status")]
     public bool isGrounded;
    [SerializeField] private bool canJump = true;
    [SerializeField] private float jumpValue;
    
    private Rigidbody2D _rb;
    private AudioSource _audioSource;
    private Vector2 _lastVelocity;
    private float _movementBlockTimer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    [Obsolete("Obsolete")]
    void Update()
    {
        _lastVelocity = _rb.velocity;
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (_movementBlockTimer > 0)
        {
            _movementBlockTimer -= Time.deltaTime;
        }

        isGrounded = Physics2D.OverlapBox(
            new Vector2(transform.position.x, transform.position.y - 0.5f),
            new Vector2(0.9f, 0.4f), 
            0f, 
            groundMask
        );
        
        if (moveInput > 0) transform.localScale = Vector3.one;
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);
        
        if (jumpValue == 0.0f && isGrounded && _movementBlockTimer <= 0)
        {
            _rb.velocity = new Vector2(moveInput * walkSpeed, _rb.velocity.y);
        }
        
        if (Input.GetKey("space") && isGrounded && canJump)
        {
            jumpValue += chargeSpeed * Time.deltaTime;
            _rb.velocity = new Vector2(0.0f, _rb.velocity.y);
        }
        
        if (jumpValue >= maxJumpCharge && isGrounded)
        {
            PerformJump(moveInput, maxJumpCharge);
            jumpValue = 0.0f;
            canJump = false;
        }
        
        if (Input.GetKeyUp("space"))
        {
            if (isGrounded && jumpValue > 0)
            {
                PerformJump(moveInput, jumpValue);
                jumpValue = 0.0f;
            }
            canJump = true;
            jumpValue = 0.0f;
        }
    }

    [Obsolete("Obsolete")]
    void PerformJump(float inputDirection, float power)
    {
        _rb.velocity = new Vector2(inputDirection * walkSpeed, power);
        _movementBlockTimer = 0.2f;
        PlaySfx(jumpClip);
    }

    [Obsolete("Obsolete")]
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGrounded)
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (Mathf.Abs(contact.normal.x) > 0.5f)
                {
                    float speed = _lastVelocity.magnitude;
                    var direction = Vector3.Reflect(_lastVelocity.normalized, contact.normal);
                    _rb.velocity = direction * Mathf.Max(speed, 0f);
                    PlaySfx(bounceClip);
                    return;
                }
            }
        }
    }

    private void PlaySfx(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.5f), new Vector2(0.9f, 0.4f));
    }
}