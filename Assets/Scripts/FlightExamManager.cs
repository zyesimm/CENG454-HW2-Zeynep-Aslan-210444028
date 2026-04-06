using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    private bool hasTakenOff = false;
    private bool hasEnteredDangerZone = false;
    private bool threatCleared = false;
    private bool missionComplete = false;

    public void EnterDangerZone()
    {
        hasEnteredDangerZone = true;
        statusText.text = "Entered a Dangerous Zone!";
    }

    public void ExitDangerZone()
    {
        threatCleared = true;
        statusText.text = "";
    }

    public void TakeOff()
    {
        hasTakenOff = true;
        if (missionText != null)
        {
            missionText.text = "Objective: Enter the danger zone and survive.";
        }
    }

    public bool CanLand()
    {
        Debug.Log("hasTakenOff: " + hasTakenOff);
        Debug.Log("hasEnteredDangerZone: " + hasEnteredDangerZone);
        Debug.Log("threatCleared:" + threatCleared);
        Debug.Log("missionComplete:" + missionComplete);
        return hasTakenOff && hasEnteredDangerZone && threatCleared && !missionComplete;

    }

    public void CompleteMission()
    {
        missionComplete = true;

        if (missionText != null)
        {
            missionText.text = "MissionComplete!";
        }

        if (statusText != null)
        {
            statusText.text = "Safe Landing Successful.";
        }
        Debug.Log("MISSION COMPLETE");
    }

    public void RejectLanding()
    {
        if (missionText != null)
        {
            missionText.text = "You cannot land yet!";
        }
        Debug.Log("Landing rejected: conditions not met.");
    }

    public void FailMission()
    {
        if (missionText != null)
        {
            missionText.text = "Mission Failed! Missile Hit.";
        }
        if (statusText != null)
        {
            statusText.text = "Return and try again.";
        }
        Debug.Log("MISSION FAILED");
    }




}