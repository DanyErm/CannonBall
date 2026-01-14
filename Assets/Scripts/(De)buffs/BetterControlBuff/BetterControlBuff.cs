using UnityEngine;

public class BetterControlBuff : MonoBehaviour
{
    private PlayerController originalController;
    private TempPlayerController tempController;

    private void Start()
    {
        originalController = GetComponent<PlayerController>();
        originalController.enabled = true;

        tempController = GetComponent<TempPlayerController>();
        tempController.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision works");
        if (other.gameObject.CompareTag("BetterControlBuff"))
        {
            Debug.Log("Player is detected");
            ChangePlayerController();
            Debug.Log("Function worked");
        }
    }

    private void ChangePlayerController()
    {
        originalController.enabled = false;
        tempController.enabled = true;
    }
}