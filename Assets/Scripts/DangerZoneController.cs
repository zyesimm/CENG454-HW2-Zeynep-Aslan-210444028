using UnityEngine;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Bir şey zone'a girdi: " + collision.name);
        if (collision.CompareTag("Player"))
        {
            examManager.EnterDangerZone();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            examManager.ExitDangerZone();
        }
    }
}