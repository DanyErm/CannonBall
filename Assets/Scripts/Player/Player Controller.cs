using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    [SerializeField] private float moveForce = 100;
    public float MoveForce
    {
        get { return moveForce; }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        rb.AddForce(direction * moveForce * Time.fixedDeltaTime, ForceMode.Acceleration);
    }
}