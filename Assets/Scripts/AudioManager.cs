using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] public AudioClips audioClips;
    [SerializeField] private AudioSource MusicSource, EffectsSource, EffectsSourceLooped1, EffectsSourceLooped2, EffectsSourceLooped3;
    private float defaultPitch;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        defaultPitch = MusicSource.pitch;
       // MusicSource = GetComponentInChildren<AudioSource>();
        //EffectsSource = GetComponentInChildren<AudioSource>();

    }
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play(0);
        MusicSource.loop = true;
    }

    public void PlaySound(AudioClip clip)
    {
        EffectsSource.PlayOneShot(clip);
    }

    public void PlaySoundLooped1(AudioClip clip)
    {
        if (EffectsSourceLooped1.clip == null)
        {
            EffectsSourceLooped1.clip = clip;
            EffectsSourceLooped1.PlayOneShot(clip);
        }     
    }

    public void PlaySoundLooped2(AudioClip clip)
    {
        if (EffectsSourceLooped2.clip == null)
        {
            EffectsSourceLooped2.clip = clip;
            EffectsSourceLooped2.PlayOneShot(clip);
        }
    }

    public void PlaySoundLooped3(AudioClip clip)
    {
        if (EffectsSourceLooped3.clip == null)
        {
            EffectsSourceLooped3.clip = clip;
            EffectsSourceLooped3.PlayOneShot(clip);
        }
    }

    public void PlaySoundLoopedStop1()
    {
        EffectsSourceLooped1.Stop();
        EffectsSourceLooped1.clip = null;
    }

    public void PlaySoundLoopedStop2()
    {
        EffectsSourceLooped2.Stop();
        EffectsSourceLooped2.clip = null;
    }

    public void PlaySoundLoopedStop3()
    {
        EffectsSourceLooped3.Stop();
        EffectsSourceLooped3.clip = null;
    }

    public void PlaySoundDelayed(AudioClip clip, float delay)
    {
        EffectsSource.clip = clip;
        EffectsSource.PlayDelayed(delay);
    }

    public void MasterVolumeControl(float volumeLevel)
    {
        AudioListener.volume = volumeLevel;
    }

    public void ToggleMusic()
    {
        MusicSource.mute = !MusicSource.mute;
    }

    public void ToggleEffects()
    {
        EffectsSource.mute = !EffectsSource.mute;
    }

    public void MusicOn()
    {
        MusicSource.mute = false;
    }

    public void MusicOff()
    {
        MusicSource.mute = true;
    }

    public void ChangeMusicVolume(float volume)
    {
        MusicSource.volume = volume;
    }

    public void ChangeMusicPitch(float pitch)
    {        
        MusicSource.pitch = pitch;       
    }
}

