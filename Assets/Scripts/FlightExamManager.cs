using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    public void EnterDangerZone()
    {
        statusText.text = "Entered a Dangerous Zone!";
    }

    public void ExitDangerZone()
    {
        statusText.text = "";
    }
}