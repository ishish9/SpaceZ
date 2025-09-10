using TMPro;
using UnityEngine;

public class StatDisplayer : MonoBehaviour
{
    [SerializeField] private AudioClips audioClip;
    [SerializeField] private Transform distanceRefrenceStart, distanceRefrenceRocket;
    [SerializeField] private TextMeshProUGUI speedDisplay;
    [SerializeField] private TextMeshProUGUI distanceDisplay;
    private Rigidbody rb;


    void Start()
    {
        speedDisplay.text = "Speed ";
        rb = distanceRefrenceRocket.gameObject.GetComponent<Rigidbody>();

    }

    void OnEnable()
    {
        Manager.OnUpdateRefrence +=  UpdateRefrence;
    }

    void OnDisable()
    {
        Manager.OnUpdateRefrence -=  UpdateRefrence;
    }

    void Update()
    {
        float dist = Vector3.Distance(distanceRefrenceStart.position, distanceRefrenceRocket.position);
        float speed = rb.linearVelocity.magnitude;
        TravelDistance(dist);
        RocketSpeed(speed);
    }

    private void TravelDistance(float distance)
    {
        distanceDisplay.text = "Distance " + distance.ToString("0");
    }

    private void RocketSpeed(float speed)
    {
        speedDisplay.text = "Speed " + speed.ToString("0.0");
    }

    public void UpdateRefrence(Transform t, Rigidbody r)
    {
        rb = r;
        distanceRefrenceRocket = t;
    }
}
