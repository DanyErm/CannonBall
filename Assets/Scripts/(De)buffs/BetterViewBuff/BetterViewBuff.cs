using UnityEngine;

public class BetterViewBuff : MonoBehaviour
{
    public float movementTimer = 3f;
    public float standingStillTimer = 3f;

    private PlayerController _playerController;
    private TempPlayerController _tempPlayerController;
    private Rigidbody _rb;

    [SerializeField] private Camera mainCamera;
    private CameraController _cameraController;
    private TempCameraController _tempCameraController;

    [HideInInspector] public bool isTempPlayerControllerTurnedOn = false;


    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _tempPlayerController = GetComponent<TempPlayerController>();
        _rb = GetComponent<Rigidbody>();

        _cameraController = mainCamera.GetComponent<CameraController>();
        _tempCameraController = mainCamera.GetComponent<TempCameraController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BetterViewBuff"))
        {
            if (_playerController.isActiveAndEnabled && !_tempPlayerController.isActiveAndEnabled)
            {
                isTempPlayerControllerTurnedOn = false;
            }
            else if (!_playerController.isActiveAndEnabled && _tempPlayerController.isActiveAndEnabled)
            {
                isTempPlayerControllerTurnedOn = true;
            }

            _playerController.enabled = false;
            _tempPlayerController.enabled = false;

            _rb.linearVelocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            _rb.Sleep();
            _rb.WakeUp();

            _cameraController.enabled = false;

            _tempCameraController.enabled = true;
        } 
    }
}