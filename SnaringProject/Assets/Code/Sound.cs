using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Animator Music;
    public Slider MusicSlide;
    public Animator SFX;
    public Slider SFXSlide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MusicSlide.value == 0)
        {
            Music.SetBool("Off", true);
        }
        else
        {
            Music.SetBool("Off", false);
        }
        if (SFXSlide.value == 0)
        {
            SFX.SetBool("Off", true);
        }
        else
        {
            SFX.SetBool("Off", false);
        }
    }
}
