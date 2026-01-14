using UnityEngine;

public class BuffStats : MonoBehaviour
{
    [SerializeField] private float betterControlBuffTime;
    public float BetterControlBuffTime
    {
        get { return betterControlBuffTime; }
    }
}