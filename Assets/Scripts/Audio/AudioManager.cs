using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class AudioManager : MonoBehaviour
{
    /*[Range(0, 100)]
    public int masterVolume;
    [Range(0, 100)]
    public int musicVolume;
    [Range(0, 100)]
    public int soundeffectsVolume;*/

    public Sound[] sounds;
    public AudioManagerStats audioStats;
    private string SavePathAudiosettings => $"{Application.persistentDataPath}/Audiosettings(Release 1.0).json";

    void Awake()
    {
        GameObject[] otherManager = null;
        otherManager = GameObject.FindGameObjectsWithTag("AudioManager");

        if (otherManager.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume / 100;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.playing = false;

        }
        DontDestroyOnLoad(transform.gameObject);
    }

    public void Start()
    {
        audioStats = getSavedStats();

        Play("Track 1 Remix Intro");   
    }

    private void Update()
    {
        GameObject masterSlider;
        GameObject musicSlider;
        GameObject soundeffectsSlider;

        //AudioManagerStats stats = gameObject.GetComponent<AudioManagerStats>();

        GameObject[] settingsMenus = GameObject.FindGameObjectsWithTag("MenuSettings");

        if (settingsMenus.Length == 1)
        {
            Debug.Log("settingsMenus.Length == 1");
            masterSlider = GameObject.FindGameObjectWithTag("MenuSettings").transform.GetChild(1).gameObject;
            musicSlider = GameObject.FindGameObjectWithTag("MenuSettings").transform.GetChild(3).gameObject;
            soundeffectsSlider = GameObject.FindGameObjectWithTag("MenuSettings").transform.GetChild(5).gameObject;

            /*stats.masterVolume = (int)masterSlider.GetComponent<Slider>().value;
            stats.musicVolume = (int)musicSlider.GetComponent<Slider>().value;
            stats.soundeffectsVolume = (int)soundeffectsSlider.GetComponent<Slider>().value;*/

            audioStats.masterVolume = (int)masterSlider.GetComponent<Slider>().value;
            audioStats.musicVolume = (int)musicSlider.GetComponent<Slider>().value;
            audioStats.soundeffectsVolume = (int)soundeffectsSlider.GetComponent<Slider>().value;
        }
        
        foreach (Sound s in sounds)
        {
            //Live Lautstärkeanpassung
            //Lautstärke Music
            if (s.type == "Music")
            {
                changeVolume(s.name, (((s.volume / 100) * audioStats.musicVolume) * (s.volume / 100) * audioStats.masterVolume));
            }
            //Lautstärke Soundeffects
            if (s.type == "Sound")
            {
                changeVolume(s.name, (((s.volume / 100) * audioStats.soundeffectsVolume) * (s.volume / 100) * audioStats.masterVolume));
            }

            //Hintergrund Loop Checken
            if (s.name == "Track 1 Remix Intro")
            {
                if (!s.source.isPlaying)
                {
                    Play("Track 1 Remix Loop");
                }
            }
        }
    }

    public void changeVolume(string name, float vol)
    {
        foreach (Sound s in sounds) 
        {
            if (s.name == name)
            {
                s.source.volume = vol;
            }
        }
    }
    public void Play(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                if (s.loop)
                {
                    if (s.playing)
                    {
                        return;
                    }
                    else
                    {
                        s.source.Play();
                        s.playing = true;
                        return;
                    }
                }
                s.source.Play();
            } 
        } 
    }
    
    public void Stop(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.Stop();
                s.playing = false;
                return;
            }
        }
    }

    public AudioManagerStats getSavedStats()
    {
        if (!File.Exists(SavePathAudiosettings))
        {
            File.Create(SavePathAudiosettings).Dispose();
            AudioManagerStats stats = new AudioManagerStats();
            saveStats(stats);            
        }
        
        using (StreamReader stream = new StreamReader(SavePathAudiosettings))
        {
            string json = stream.ReadToEnd();

            return JsonUtility.FromJson<AudioManagerStats>(json);
        }
    }

    public void saveStats(AudioManagerStats statsToSave)
    {
        using (StreamWriter stream = new StreamWriter(SavePathAudiosettings))
        {
            string json = JsonUtility.ToJson(statsToSave, true);
            stream.Write(json);
        }
    }
}
