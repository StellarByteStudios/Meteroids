using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SoundVolSlider : MonoBehaviour
{
    private AudioManagerStats stats;
    public void Awake()
    {
        //AudioManagerStats stats = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerStats>();
        stats = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().audioStats;
        gameObject.GetComponent<Slider>().value = stats.soundeffectsVolume;
    }
    private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().saveStats(stats);
    }
}
