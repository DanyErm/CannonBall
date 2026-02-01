using UnityEngine;

public class TempPlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private float betterControlBuffTime = 10f;
    [HideInInspector] public float _tempBetterControlBuffTime = 10f;        //Намётки для учёта прошедшего времени действия BetterControlBuff в других баффах

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
        var horizontal = 0f;
        var vertical = 0f;


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            vertical = 1f;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            vertical = -1f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            horizontal = 1f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            horizontal = -1f;


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