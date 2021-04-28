using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolSlider : MonoBehaviour
{
    private AudioManagerStats stats;
    public void Awake()
    {
        //AudioManagerStats stats = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerStats>();
        stats = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().audioStats;
        gameObject.GetComponent<Slider>().value = stats.musicVolume;
    }
    private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().saveStats(stats);
    }
}
