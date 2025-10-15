using UnityEngine;

public class TempPlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float betterControlBuffTime = 10f;
    private float _tempBetterControlBuffTime = 10f;

    private Rigidbody _rb;
    private PlayerController _originalController;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _originalController = GetComponent<PlayerController>();
    }


    private void OnEnable()
    {
        _tempBetterControlBuffTime = betterControlBuffTime;
    }


    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        _rb.linearVelocity = direction * moveSpeed * Time.fixedDeltaTime;

        _tempBetterControlBuffTime -= Time.fixedDeltaTime;

        if (_tempBetterControlBuffTime <= 0)
        {
            _originalController.enabled = true;
            this.enabled = false;
        }
    }
}