using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void OnTriggerEnter()
    {
        Debug.Log("Hello");
        //transform.position = target.position + offset;
        Vector3 desiredp = target.position + offset;
        Vector3 smoothedp = Vector3.Lerp(transform.position, desiredp, smoothSpeed * Time.deltaTime);
        transform.position = smoothedp;
    }
}
