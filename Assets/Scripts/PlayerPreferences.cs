
using UnityEngine;
using UnityEngine.Audio;
using System.Linq;

namespace HackedDesign
{
    public class PlayerPreferences
    {
        public float sfxVolume;
        public float musicVolume;

        private AudioMixer mixer;

        public PlayerPreferences(AudioMixer mixer)
        {
            this.mixer = mixer;
        }


        public void Save()
        {

            PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);
            
        }

        public void Load()
        {
            Logger.Log("Player Preferences", "Loading...");
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0);
            musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0);
            SetPreferences();
        }

        public void SetPreferences()
        {
            this.mixer.SetFloat("SFXVolume", this.sfxVolume);
            this.mixer.SetFloat("MusicVolume", this.musicVolume);
        }
    }
}
