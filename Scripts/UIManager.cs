using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Score Text")]
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private Transform player;
    [SerializeField] private float distanceMultiplayer = 10;

    [HideInInspector] public int distance;

    public void Update()
    {
        if(player != null)
        {
            distance = Mathf.RoundToInt(player.position.x * distanceMultiplayer);
            if (distance < 0) { distance = 0; }

            distanceText.text = distance.ToString() + "m";
        }
    }
}
