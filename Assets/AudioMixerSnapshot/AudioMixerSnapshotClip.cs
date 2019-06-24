using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class AudioMixerSnapshotClip : PlayableAsset, ITimelineClipAsset
{
    public AudioMixerSnapshotBehaviour template = new AudioMixerSnapshotBehaviour ();
    public ExposedReference<AudioMixerSnapshot> mixer;

    public ClipCaps clipCaps
    {
        get { return ClipCaps.ClipIn | ClipCaps.SpeedMultiplier | ClipCaps.Blending | ClipCaps.Extrapolation; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<AudioMixerSnapshotBehaviour>.Create (graph, template);
        AudioMixerSnapshotBehaviour clone = playable.GetBehaviour ();
        clone.Snapshot = mixer.Resolve (graph.GetResolver ());
        return playable;
    }
}
