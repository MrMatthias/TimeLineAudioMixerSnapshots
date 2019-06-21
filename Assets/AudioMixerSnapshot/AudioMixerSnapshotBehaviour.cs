using System;
using UnityEngine.Playables;
using UnityEngine.Audio;


[Serializable]
public class AudioMixerSnapshotBehaviour : PlayableBehaviour
{
    public AudioMixerSnapshot Snapshot;
    public override void OnPlayableCreate (Playable playable)
    {
        
    }
}
