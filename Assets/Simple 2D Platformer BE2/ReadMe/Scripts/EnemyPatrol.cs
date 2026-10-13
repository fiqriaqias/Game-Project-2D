using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyPatrol : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool movingRight = true;

    [Header("Detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkDistance = 0.5f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float groundCheckOffsetX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // Simpan jarak relatif groundCheck terhadap badan musuh
        if (groundCheck != null)
        {
            groundCheckOffsetX = Mathf.Abs(groundCheck.localPosition.x);
        }

        // Terapkan arah awal
        UpdateFacing();
    }

    void FixedUpdate()
    {
        // 1. Gerakkan musuh secara horizontal
        rb.linearVelocity = new Vector2((movingRight ? 1 : -1) * speed, rb.linearVelocity.y);

        // 2. Deteksi tanah di bawah sensor
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, checkDistance, groundLayer);

        // 3. Deteksi dinding di depan arah jalan
        Vector2 wallDir = movingRight ? Vector2.right : Vector2.left;
        RaycastHit2D wallInfo = Physics2D.Raycast(groundCheck.position, wallDir, 0.2f, groundLayer);

        // Jika tidak ada tanah atau membentur tembok, putar arah
        if (!groundInfo.collider || wallInfo.collider)
        {
            Flip();
        }
    }

    private void Flip()
    {
        movingRight = !movingRight;
        UpdateFacing();
    }

    private void UpdateFacing()
    {
        // Karena sprite asli menghadap ke KIRI:
        // Saat movingRight = true, kita balik sprite-nya (flipX = true)
        // Saat movingRight = false, biarkan normal (flipX = false)
        if (sr != null)
        {
            sr.flipX = movingRight;
        }

        // Pindahkan posisi sensor groundCheck agar selalu berada di depan arah jalan
        if (groundCheck != null)
        {
            float posX = movingRight ? groundCheckOffsetX : -groundCheckOffsetX;
            groundCheck.localPosition = new Vector3(posX, groundCheck.localPosition.y, groundCheck.localPosition.z);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * checkDistance);
    }
}