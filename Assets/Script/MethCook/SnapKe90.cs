using UnityEngine;

public class SnapKe90 : MonoBehaviour
{
    public float snapAngle = 0f;
    public float threshold = 2f; 
    public float snapSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float currentY = transform.localEulerAngles.y;
        if (Mathf.Abs(Mathf.DeltaAngle(currentY, snapAngle)) < threshold && rb.linearVelocity.magnitude < 0.1f)
        {
            
            transform.localEulerAngles = new Vector3(
                transform.localEulerAngles.x,
                transform.localEulerAngles.y,
                snapAngle
            );
            rb.angularVelocity = Vector3.zero;
        }
    }
}
