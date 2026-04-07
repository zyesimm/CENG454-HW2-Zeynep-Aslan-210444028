using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;
    private bool playerInsideZone = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (playerInsideZone) return;

        playerInsideZone = true;

        if (examManager != null)
        {
            examManager.EnterDangerZone();
        }

        if (activeCountdown == null && missileLauncher != null)
        {
            activeCountdown = StartCoroutine(MissileCountdown(collision.transform));
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (!playerInsideZone) return;

        playerInsideZone = false;

        if (examManager != null)
        {
            examManager.ExitDangerZone();
        }

        if (activeCountdown != null)
        {
            StopCoroutine(activeCountdown);
            activeCountdown = null;
        }

        if (missileLauncher != null)
        {
            missileLauncher.DestroyActiveMissile();
        }
    }

    private IEnumerator MissileCountdown(Transform target)
    {
        yield return new WaitForSeconds(missileDelay);

        if (playerInsideZone && missileLauncher != null)
        {
            missileLauncher.Launch(target);
        }

        activeCountdown = null;
    }
}