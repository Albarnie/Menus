using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

namespace Albarnie.Menus
{
    public class AudioSettingsManager : BaseMenu
    {
        [SerializeField]
        Slider volumeSlider;

        [SerializeField]
        Slider ambientVolumeSlider;

        [SerializeField]
        AudioMixer mixer = null;

        [SerializeField]
        float minVolume = -50f, maxvolume = 20f;

        public void SetVolume(float level)
        {
            mixer.SetFloat("Master Volume", Mathf.Lerp(minVolume, maxvolume, level));
        }

        public void SetAmbientVolume(float level)
        {
            mixer.SetFloat("Ambient Volume", Mathf.Lerp(minVolume, maxvolume, level));
        }

        private void OnEnable()
        {
            float masterVolume;
            mixer.GetFloat("Master Volume", out masterVolume);
            volumeSlider.value = Mathf.InverseLerp(minVolume, maxvolume, masterVolume);

            float ambientVolume;
            mixer.GetFloat("Ambient Volume", out ambientVolume);
            ambientVolumeSlider.value = Mathf.InverseLerp(minVolume, maxvolume, ambientVolume);
        }
    }
}