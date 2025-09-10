using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Manager : MonoBehaviour
{
    public cameraFollow camera;
    [SerializeField] private Transform Player;
    //[SerializeField] private Rigidbody rb;
    [SerializeField] private Transform restartPosition;
    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject restart;
    [SerializeField] private GameObject menuCamera;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject ui;
    [SerializeField] private PostProcessEffectRenderer f;
    public delegate void SendTransform(Transform t, Rigidbody r);
    public static event SendTransform OnUpdateRefrence;
    public delegate void ResetFuel();
    public static event ResetFuel OnResetFuel;

    void Start()

    {
        
    }

    public void Launch()
    {
        AudioManager.instance.MusicOff();
        menuCamera.SetActive(false);
        mainCamera.SetActive(true);
        ui.SetActive(true);
    }

    public void Death()
    {
        restart.SetActive(true);
    }

    public void Restart()
    {
        OnResetFuel();
        GameObject FracturesContainer = GameObject.Find("ROCKET - Fracture Root");
        Destroy(FracturesContainer);
        GameObject newObject = Instantiate(playerObj, restartPosition.position, Quaternion.identity);
        Transform newObjectTransform = newObject.transform;
        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        camera.UpdateCameraTarget(newObjectTransform);
        OnUpdateRefrence(newObjectTransform, rb);
        Player = newObjectTransform;
    }
}
