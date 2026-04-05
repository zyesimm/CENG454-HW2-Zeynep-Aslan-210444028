using UnityEngine;

public class LandingZone : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered landing zone: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered landing zone");
            if (examManager == null)
            {
                Debug.LogError("Exam manager is NULL!");
                return;
            }


            if (examManager.CanLand())
            {
                Debug.Log("CAN LAND = TRUE");
                examManager.CompleteMission();
            }
            else
            {
                Debug.Log("CAN LAND = FALSE");
                examManager.RejectLanding();
            }
        }
    }
}