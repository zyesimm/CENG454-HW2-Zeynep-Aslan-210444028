using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    [Header("Audio")]
    [SerializeField] private AudioSource successAudioSource;

    private bool hasTakenOff = false;
    private bool hasEnteredDangerZone = false;
    private bool threatCleared = false;
    private bool missionComplete = false;
    private bool missionFailed = false;

    private void Start()
    {
        UpdateUI();
    }

    public void TakeOff()
    {
        if (hasTakenOff) return;

        hasTakenOff = true;
        UpdateUI();
        
    }

    public void EnterDangerZone()
    {
        if (missionComplete || missionFailed) return;

        hasEnteredDangerZone = true;

        if (statusText != null)
        {
            statusText.text = "Entered a Dangerous Zone!";
        }

        if (missionText != null)
        {
            missionText.text = "Objective: Survive the missile threat and escape the zone.";
        }

        
    }

    public void ExitDangerZone()
    {
        if (missionComplete || missionFailed) return;

        if (hasEnteredDangerZone)
        {
            threatCleared = true;
        }

        if (statusText != null)
        {
            statusText.text = "Threat cleared. Return to the landing area.";
        }

        if (missionText != null)
        {
            missionText.text = "Objective: Return and land safely.";
        }

        
    }

    public bool CanLand()
    {
        return hasTakenOff && hasEnteredDangerZone && threatCleared && !missionComplete && !missionFailed;


    }

    public void CompleteMission()
    {
        if (!CanLand()) return;

        missionComplete = true;

        if (missionText != null)
        {
            missionText.text = "Mission Complete!";
        }

        if (statusText != null)
        {
            statusText.text = "Safe landing successful.";
        }

        if (successAudioSource != null)
        {
            successAudioSource.Play();
        }

       
    }

    public void RejectLanding()
    {
        if (missionComplete || missionFailed) return;

        if (!hasTakenOff)
        {
            if (missionText != null)
            {
                missionText.text = "You must take off first.";
            }

            if (statusText != null)
            {
                statusText.text = "Landing rejected.";
            }
        }
        else if (!hasEnteredDangerZone)
        {
            if (missionText != null)
            {
                missionText.text = "You must enter the danger zone first.";
            }

            if (statusText != null)
            {
                statusText.text = "Landing rejected.";
            }
        }
        else if (!threatCleared)
        {
            if (missionText != null)
            {
                missionText.text = "Escape the threat before landing.";
            }

            if (statusText != null)
            {
                statusText.text = "Landing rejected.";
            }
        }

      
    }

    public void FailMission()
    {
        if (missionComplete || missionFailed) return;

        missionFailed = true;

        if (missionText != null)
        {
            missionText.text = "Mission Failed! Missile hit detected.";
        }

        if (statusText != null)
        {
            statusText.text = "Return to base and try again.";
        }

        
    }

    private void UpdateUI()
    {
        if (missionComplete)
        {
            if (missionText != null) missionText.text = "Mission Complete!";
            if (statusText != null) statusText.text = "Safe landing successful.";
            return;
        }

        if (missionFailed)
        {
            if (missionText != null) missionText.text = "Mission Failed! Missile hit detected.";
            if (statusText != null) statusText.text = "Return to base and try again.";
            return;
        }

        if (!hasTakenOff)
        {
            if (missionText != null) missionText.text = "Objective: Take off and fly toward the corridor.";
            if (statusText != null) statusText.text = "Ready for takeoff.";
            return;
        }

        if (hasTakenOff && !hasEnteredDangerZone)
        {
            if (missionText != null) missionText.text = "Objective: Enter the danger zone.";
            if (statusText != null) statusText.text = "Proceed to the corridor.";
            return;
        }

        if (hasEnteredDangerZone && !threatCleared)
        {
            if (missionText != null) missionText.text = "Objective: Survive the missile threat and escape the zone.";
            if (statusText != null) statusText.text = "Entered a Dangerous Zone!";
            return;
        }

        if (threatCleared)
        {
            if (missionText != null) missionText.text = "Objective: Return and land safely.";
            if (statusText != null) statusText.text = "Threat cleared.";
        }
    }
}