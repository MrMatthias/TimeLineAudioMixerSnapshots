using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Audio;


[TrackColor(0.855f, 0.8623f, 0.87f)]
[TrackClipType(typeof(AudioMixerSnapshotClip))]
[TrackBindingType(typeof(AudioMixer))]
public class AudioMixerSnapshotTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<AudioMixerSnapshotMixerBehaviour>.Create (graph, inputCount);
    }
}
