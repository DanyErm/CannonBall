using UnityEngine;

public class BetterControlBuff : MonoBehaviour
{
    private PlayerController _originalController;
    private TempPlayerController tempController;

    private void Start()
    {
        _originalController = GetComponent<PlayerController>();
        _originalController.enabled = true;

        tempController = GetComponent<TempPlayerController>();
        tempController.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BetterControlBuff"))
        {
            ChangePlayerController();
        }
    }

    private void ChangePlayerController()
    {
        _originalController.enabled = false;
        tempController.enabled = true;
    }
}