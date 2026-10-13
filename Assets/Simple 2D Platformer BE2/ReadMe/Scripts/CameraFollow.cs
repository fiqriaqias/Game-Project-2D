using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;          // Objek yang diikuti (Player)

    [Header("Pengaturan Kamera")]
    [SerializeField] private float smoothSpeed = 0.125f; // Kecepatan redaman (semakin kecil semakin halus)
    [SerializeField] private float offsetX = 0f;        // Geser posisi kamera ke kiri/kanan (tidak tepat di tengah Player)
    [SerializeField] private float offsetY = 0f;        // Geser posisi kamera ke atas/bawah
    [SerializeField] private float zPosition = -10f;    // Posisi Z tetap terkunci (kamera tidak maju-mundur)

    void LateUpdate()
    {
        // LateUpdate dipanggil setelah Update selesai, sehingga kamera tidak bergetar (jittering)

        if (target == null)
            return;

        // 1. Buat posisi tujuan kamera = posisi Player + offset, dengan Z tetap terkunci
        Vector3 desiredPosition = new Vector3(
            target.position.x + offsetX,
            target.position.y + offsetY,
            zPosition
        );

        // 2. Lerp menghaluskan pergerakan kamera dari posisi sekarang menuju posisi tujuan
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed
        );

        // 3. Terapkan posisi kamera yang sudah dihaluskan
        transform.position = smoothedPosition;
    }
}