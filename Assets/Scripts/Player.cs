using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float climbSpeed;
    public float jumpForce;
    public bool isGrounded;
    public bool isJumping;
    public bool isClimbing;
    public bool isBossFight;

    public GameObject gameOver;
    public GameObject projectilePrefab;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startBtwShots;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator animator;

    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;
    public int health;

    private void Start()
    {
        gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        health = gameObject.GetComponent<Health>().health;
        if (health <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            Destroy(gameObject);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded) {
            isJumping = true;
        }

        Flip(rb.velocity.x);

        if (timeBtwShots <= 0)
        {
            if (Input.GetKeyDown(KeyCode.S) && Inventory.instance.nbInstru>=1)
            {
                Instantiate(projectilePrefab, shotPoint.position, transform.rotation);
                timeBtwShots = startBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
    }
    void FixedUpdate()
    {
        MovePlayer(horizontalMovement, verticalMovement);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);

    }
    void MovePlayer(float _horizontalMovement, float _verticalMovement) 
    {
        if (!isClimbing) //s'il ne monte pas il se déplace normalement
        {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.5f);

            if(isJumping == true)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        } else
        {
            Vector3 targetVelocity = new Vector2(0, _verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.5f);
        }
    }
    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;

        }
        else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position,groundCheckRadius);
    }
}
