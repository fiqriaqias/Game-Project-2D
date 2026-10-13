using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Rb;
    private Animator animator;

    public float ms = 5f;   // Kecepatan gerak (Move Speed)
    public float jf = 300f; // Kekuatan lompat (Jump Force)

    private bool isGrounded = true;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 1. Gerakan Horizontal
        float horiz = Input.GetAxisRaw("Horizontal");
        Rb.linearVelocity = new Vector2(ms * horiz, Rb.linearVelocityY);

        // Membalik arah hadap karakter (Flip Sprite)
        if (horiz > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horiz < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // 2. Logika Lompat (hanya bisa lompat jika menyentuh tanah)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Rb.AddForce(new Vector2(0, jf));
            isGrounded = false;
        }

        // 3. Update parameter Animator
        animator.SetFloat("Speed", Mathf.Abs(horiz));
        animator.SetBool("isGrounded", isGrounded);
    }

    // 4. Deteksi saat karakter mendarat di tanah/platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Pastikan GameObject lantai diberi Tag "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}