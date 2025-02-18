using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsControl : MonoBehaviour
{
    public Slider SFX;
    public Slider BGM;
    private static SoundsControl instance;
    private AudioSource audioSource;
    private AudioSource BgmSource;
    public AudioClip[] audioClips;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponents<AudioSource>()[0];
            BgmSource = GetComponents<AudioSource>()[1];
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    public void ChangeSFX()
    {
        float value = SFX.value;
        audioSource.volume = value;
    }

    public void ChangeBGM()
    {
        float value = BGM.value;
        BgmSource.volume = value;
    }

    public static void CantMove()
    {
        instance.audioSource.PlayOneShot(instance.audioClips[0]);
    }

    public static void Click()
    {
        instance.audioSource.PlayOneShot(instance.audioClips[1]);
    }

    public static void Drawing()
    {
        int randomIndex = Random.Range(2, 4);
        instance.audioSource.Stop();
        instance.audioSource.PlayOneShot(instance.audioClips[randomIndex]);
    }

    public static void OnMenu()
    {
        instance.audioSource.PlayOneShot(instance.audioClips[5]);
    }

    public static void GameOver()
    {
        instance.audioSource.PlayOneShot(instance.audioClips[6]);
    }
}
