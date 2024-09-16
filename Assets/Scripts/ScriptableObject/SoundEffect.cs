using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using static Unity.VisualScripting.Member;
using Random = UnityEngine.Random;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewSoundEffect", menuName = "Audio/New Sound Effect")]
    public class SoundEffect : ScriptableObject
    {        
        [Header("Settings")]
        [SerializeField] private AudioClip[] clips;
        //Volume
        [Header("Volume")]
        [Range(0.0f, 1.0f)]
        public float volumeMin = 0.5f;
        [Range(0.0f, 1.0f)]
        public float volumeMax = 0.5f;

        //Pitch
        [Header("Pitch")]
        [Range(-10.0f, 10.0f)]
        public float pitchMin = 1f;
        [Range(-10.0f, 10.0f)]
        public float pitchMax = 1f;

        //AudioMixer
        [Header("Audio mixer")]
        [SerializeField] private AudioMixerGroup group;

        //PlayOrder
        [Header("Play order")]
        [SerializeField] private SoundClipPlayOrder playOrder;

        [SerializeField]
        private int playIndex = 0;

        private AudioClip GetAudioClip()
        {
            //Get current clip
            var clip = clips[playIndex >= clips.Length ? 0 : playIndex];

            //Find next clip
            switch (playOrder)
            {
                case SoundClipPlayOrder.in_order:
                    playIndex = (playIndex + 1) % clips.Length;
                    break;
                case SoundClipPlayOrder.random:
                    playIndex = Random.Range(0, clips.Length);
                    break;
                case SoundClipPlayOrder.reverse:
                    playIndex = (playIndex + clips.Length - 1) % clips.Length;
                    break;
            }

            //Return clip
            return clip;
        }

        public AudioSource Play(AudioSource audioSourceParam = null)
        {
            if (clips.Length == 0)
            {
                Debug.Log($"Missing sound clips for {name}");
                return null;
            }

            AudioSource source = ConfigAudioSource(audioSourceParam);
            source.Play();
            return source;
        }

        private AudioSource ConfigAudioSource(AudioSource audioSourceParam = null)
        {
            AudioSource source = audioSourceParam;

            bool destroyAfterCreation = false;            
            if (source == null)
            {
                GameObject obj = new GameObject("Sound", typeof(AudioSource));
                source = obj.GetComponent<AudioSource>();
                destroyAfterCreation = true;
            }

            //Set source config:
            source.clip = GetAudioClip();
            source.outputAudioMixerGroup = group;
            source.volume = Random.Range(volumeMin, volumeMax);
            source.pitch = Random.Range(pitchMin, pitchMax);

            if(destroyAfterCreation) Destroy(source.gameObject, source.clip.length / source.pitch);
            return source;

        }

        enum SoundClipPlayOrder
        {
            random,
            in_order,
            reverse
        }
    }
}