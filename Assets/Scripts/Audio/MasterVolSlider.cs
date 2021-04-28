using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolSlider : MonoBehaviour
{
    private AudioManagerStats stats;
    public void Awake()
    {
        stats = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().audioStats;
        gameObject.GetComponent<Slider>().value = stats.masterVolume;
    }
    private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().saveStats(stats);
    }
}
