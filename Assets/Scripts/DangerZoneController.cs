using UnityEngine;
using System.Collections;
public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider collision)
    {
    if (collision.CompareTag("Player"))
    {
        Debug.Log("Player entered danger zone");
        examManager.EnterDangerZone();

        if (activeCountdown == null)
        {
            activeCountdown = StartCoroutine(MissileCountdown());
        }
    }
}
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player exited danger zone");
            examManager.ExitDangerZone();

            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
            }
        }
    }

    private IEnumerator MissileCountdown()
    {
        yield return new WaitForSeconds(missileDelay);
        Debug.Log("MISSILE SHOULD LAUNCH NIW");
        activeCountdown = null;
    }
}