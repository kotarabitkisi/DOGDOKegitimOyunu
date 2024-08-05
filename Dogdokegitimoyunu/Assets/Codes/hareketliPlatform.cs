using UnityEngine;

public class hareketliPlatform : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    void Update()
    {
        transform.position = Vector3.Lerp(pos1.position, pos2.position, (Mathf.Sin(Time.time * speed) + 1) / 2);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform, true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform, false);
        }
    }
}
