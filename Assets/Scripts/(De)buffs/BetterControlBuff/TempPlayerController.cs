using UnityEngine;

public class TempPlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float moveSpeed = 15f;

    private float betterControlBuffTime;
    private PlayerController originalController;

    private void OnEnable()
    {
        betterControlBuffTime = GetComponent<BuffStats>().BetterControlBuffTime;
        _rb = GetComponent<PlayerController>().rb;
        originalController = GetComponent<PlayerController>();
    }

    //private void Start()
    //{
    //    _rb = GetComponent<Rigidbody>();
    //    originalController = GetComponent<PlayerController>();
    //}

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        _rb.linearVelocity = direction * moveSpeed * Time.fixedDeltaTime;

        betterControlBuffTime -= Time.fixedDeltaTime;

        if (betterControlBuffTime <= 0)
        {
            originalController.enabled = true;
            this.enabled = false;
        }
    }
}