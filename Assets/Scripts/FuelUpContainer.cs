using UnityEngine;

public class FuelUpContainer : MonoBehaviour
{
    [SerializeField] private int fuelAmount;
    [SerializeField] private ParticleSystem FuelCollectedEffect;
    public delegate void FuelUp (float fuelAmount);
    public static event FuelUp OnFuelup;

    private void OnTriggerEnter()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.FuelCollect);      
        FuelCollectedEffect.transform.position = transform.position;
        FuelCollectedEffect.Play();
        OnFuelup(fuelAmount);
        gameObject.SetActive(false);
    }
}
