using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 _cameraOffset;

    private void Start()
    {
        _cameraOffset = transform.position - playerTransform.position;
    }
    private void Update()
    {
        transform.position = playerTransform.position + _cameraOffset;
    }
}