using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePlayerScript : MonoBehaviour
{
    float horizontalView = 0f;
    float verticalView = 0f;
    float runSpeed = 0.05f;

    NavMeshAgent agent;
    Transform cameraTransform;

    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cameraTransform = Camera.main.transform;
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalView = joystick.Horizontal;
        verticalView = joystick.Vertical;

        var cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
         
        Vector3 movement = transform.forward * runSpeed;
        Vector3 direction = cameraForward * verticalView + cameraTransform.right * horizontalView;

        transform.rotation = Quaternion.LookRotation(direction);
        if(Mathf.Abs(horizontalView) > 0 || Mathf.Abs(verticalView) > 0)
        {
            agent.Move(movement);
        }
    }
}
