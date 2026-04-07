using UnityEngine;

public class LandingZone : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {

        Transform root = other.transform.root;

        if (!root.CompareTag("Player"))
            return;
        
            
        if (examManager == null)
        {
            Debug.LogError("[LandingZone] FlightExamManager reference is missing.", this);
            return;
        }


        if (examManager.CanLand())
        {
                
            examManager.CompleteMission();
        }
        else
        {
               
            examManager.RejectLanding();
        }
        
    }
}