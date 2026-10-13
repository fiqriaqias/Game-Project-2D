using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect; // Nilai 1 = diam ikut layar, < 1 = ada efek kedalaman

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        // Jika kamera sudah melewati ujung background, geser posisi dasarnya
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}