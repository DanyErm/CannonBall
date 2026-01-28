using UnityEngine;

public class TempCameraController : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 betterPosition;
    private float movementTimer = 3f;
    private float standingStillTimer = 3f;
    private float elapsedTime;
    private float percentageComplete;


    private bool wasCamInBetterViewPos;
    [SerializeField] private GameObject playableCharacter;

    private BetterViewBuff linkBetterViewBuff;
    private bool wasTempPlayerControllerTurnedOn;


    private CameraController cameraController;

    private PlayerController playerController;
    private TempPlayerController tempPlayerController;


    [SerializeField] private MazeSpawner mazeSpawner;
    [SerializeField] private GameObject wall;


    private void Awake()
    {
        betterPosition = CalculateBetterViewPos();

        cameraController = GetComponent<CameraController>();
        playerController = playableCharacter.GetComponent<PlayerController>();
        tempPlayerController = playableCharacter.GetComponent<TempPlayerController>();


        linkBetterViewBuff = playableCharacter.GetComponent<BetterViewBuff>();
    }

    private void OnEnable()
    {
        startPosition = transform.position;
        endPosition = betterPosition;
        wasCamInBetterViewPos = false;

        wasTempPlayerControllerTurnedOn = linkBetterViewBuff.isTempPlayerControllerTurnedOn;
        movementTimer = linkBetterViewBuff.movementTimer;
        standingStillTimer = linkBetterViewBuff.standingStillTimer;

        elapsedTime = 0f;
    }


    private void Update()
    {
        elapsedTime += Time.deltaTime;
        percentageComplete = elapsedTime / movementTimer;
        transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

        if (elapsedTime - movementTimer > standingStillTimer)
        {
            (startPosition, endPosition) = (endPosition, startPosition);

            elapsedTime = 0;
            wasCamInBetterViewPos = true;
        }

        if (elapsedTime > movementTimer && wasCamInBetterViewPos)
        {
            cameraController.enabled = true;

            if (wasTempPlayerControllerTurnedOn)
            {
                tempPlayerController.enabled = true;
            }
            else
            {
                playerController.enabled = true;
            }

            this.enabled = false;
        }
    }


    private Vector3 CalculateBetterViewPos()
    {
        float x = (mazeSpawner.CellSize.x * mazeSpawner.mazeWidth) / 2;


        float z = (mazeSpawner.CellSize.z * mazeSpawner.mazeHeight) / 2;


        float cameraFieldOfView = GetComponent<Camera>().fieldOfView;
        float wallHeight = wall.transform.localScale.z;

        //float y = wallHeight + (Mathf.Sin(90 - (cameraFieldOfView / 2)) / Mathf.Sin(cameraFieldOfView / 2));

        float halfMazeHeight = (mazeSpawner.CellSize.z * mazeSpawner.mazeHeight) / 2f;
        float y = halfMazeHeight / Mathf.Tan(cameraFieldOfView * 0.5f * Mathf.Deg2Rad) + wallHeight * 2;


        return new Vector3(x, y, z);
    }
}