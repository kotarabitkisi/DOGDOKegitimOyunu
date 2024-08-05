using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool canJump, canmove;
    public Rigidbody rb;
    public GameObject cam;
    public float speed, jumpForce, sensivity;
    public float InputZ, InputY, InputX;
    public float RotY, RotX;
    private void Start()
    {
        //farenin gözükmemesi için
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }
    void Update()
    {
        if (canmove)
        {
            #region FPC
            RotY += Input.GetAxisRaw("Mouse X") * sensivity;
            RotX += Input.GetAxisRaw("Mouse Y") * sensivity;
            RotX = Mathf.Clamp(RotX, -90, 90);
            transform.rotation = Quaternion.Euler(0, RotY, 0);
            cam.transform.localRotation = Quaternion.Euler(-RotX, 0, 0);
            #endregion
            InputZ = Input.GetAxisRaw("Vertical");//ileri-geri hareket
            InputX = Input.GetAxisRaw("Horizontal");//sað-sol hareket
            #region Zýplama
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                rb.velocity = jumpForce * Vector3.up;
                canJump = false;
            }
            #endregion

            rb.velocity =
                +rb.velocity.y * Vector3.up +
                transform.forward * speed * InputZ +
                transform.right * speed * InputX;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
}
