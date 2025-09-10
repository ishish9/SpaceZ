using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float speed;
    public Vector3 offset;
    [SerializeField] private bool justLook;

    void Update()
    {
        if (target != null && !justLook)
        {
            Vector3 desiredp = target.position + offset;
            Vector3 smoothedp = Vector3.Lerp(transform.position, desiredp, speed * Time.deltaTime);
            transform.position = smoothedp;
        }
        if (justLook)
        {
            Quaternion lookDirection = Quaternion.LookRotation(target.position - transform.position);
            lookDirection = Quaternion.Euler(0, lookDirection.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, speed * Time.deltaTime);
        }
    }

    void OnEnable()
    {
        //Manager.changeCamera +=  UpdateCameraFollow;
    }

    void OnDisable()
    {
        //Manager.changeCamera -=  UpdateCameraFollow;
    }

    public void UpdateCameraTarget(Transform newObjectInstance)
    {
        target = newObjectInstance;
    }
}
