using UnityEngine;

public class BetterViewBuff : MonoBehaviour
{
    [SerializeField] private float motionSpeed = 5f;
    [SerializeField] private float waitingTime = 3f;
    [SerializeField] private Vector3 originalPos;
    [SerializeField] private Camera mainCamera;
    private Vector3 betterViewPos;
    private bool isCamInBetterViewPos;

    private void Start()
    {
        //originalPos = GetComponent<Transform>().position;
        betterViewPos = CalculateBetterViewPos();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BetterViewBuff"))
        {
            TurnCharMovement(false);
            TurnCameraController(false);
            MoveConstantlyFromAToB();
        }
    }

    private void Update()
    {
        if (isCamInBetterViewPos)
        {
            if(Input.anyKeyDown)
            {
                waitingTime = 0;
            }
            if (waitingTime <= 0)
            {
                //CalculateBetterViewPos()  Ќазад на прежнее место
            }
        }
    }


    private Vector3 CalculateBetterViewPos()    // ”знать, как найти Y местоположени€ камеры, с которого будет виден весь лабиринт
    {
        float cameraFieldOfView = mainCamera.fieldOfView;
        return Vector3.zero;
    }

    void TurnCharMovement(bool willBeTurnedOn)
    {

    }

    void TurnCameraController(bool willBeTurnedOn)
    {

    }

    private void MoveConstantlyFromAToB()
    {

    }
}