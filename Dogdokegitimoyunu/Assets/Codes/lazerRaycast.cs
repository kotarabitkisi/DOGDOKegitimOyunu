using UnityEngine;

public class lazerRaycast : MonoBehaviour
{
    public Stats PlayerScr;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                PlayerScr.Lose();
            }
        }

    }
}
