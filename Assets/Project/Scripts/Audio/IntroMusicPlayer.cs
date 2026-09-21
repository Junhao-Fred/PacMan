using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class IntroMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip intro;
    [SerializeField] private AudioClip normal;

    private IEnumerator Start()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.spatialBlend = 0f;
        if (intro == null || normal == null)
        {
            Debug.LogError("Assign both intro and normal music clips.", this);
            yield break;
        }

        source.loop = false;
        source.clip = intro;
        source.Play();
        yield return new WaitForSecondsRealtime(Mathf.Min(3f, intro.length));
        source.clip = normal;
        source.loop = true;
        source.Play();
    }
}
