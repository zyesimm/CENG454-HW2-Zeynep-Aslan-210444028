// FlightController.cs
// CENG454 - HW1: Sky-High Prototype
// Author: Zeynep Aslan | Student ID: 210444028


using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 10f;
    [SerializeField] private float pitchSpeed = 45f;
    [SerializeField] private float yawSpeed = 60f;
    [SerializeField] private float rollSpeed = 80f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb!= null)
        {
            rb.freezeRotation = true;
        }
    }



    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        float pitchInput = 0f;
        float yawInput = 0f;
        float rollInput = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
            pitchInput = -1f;
        else if (Input.GetKey(KeyCode.DownArrow))
            pitchInput = 1f;
        transform.Rotate(Vector3.right * pitchInput * pitchSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            yawInput = -1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            yawInput = 1f;
        transform.Rotate(Vector3.up * yawInput * yawSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
            rollInput = 1f;
        else if (Input.GetKey(KeyCode.E))
            rollInput = -1f;
        transform.Rotate(Vector3.forward * rollInput * rollSpeed * Time.deltaTime);


    }

    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }

    }



}