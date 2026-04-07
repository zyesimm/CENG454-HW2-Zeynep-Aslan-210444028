using UnityEngine;

public class MissileHoming:MonoBehaviour
{
    [SerializeField] private float moveSpeed = 14f;
    [SerializeField] private float turnSpeed = 3f;


    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target=newTarget;
    }

    void Update()
    {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

    }
}