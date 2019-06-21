using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Audio;


public class AudioMixerSnapshotMixerBehaviour : PlayableBehaviour
{
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    private AudioMixerSnapshot[] _snapshots;
    private float[] _weights;
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        AudioMixer trackBinding = playerData as AudioMixer;

        if (!trackBinding)
            return;

        int inputCount = playable.GetInputCount ();
        if (_snapshots == null || _snapshots.Length != inputCount)
        {
            _weights = new float[inputCount];
            _snapshots = new AudioMixerSnapshot[inputCount];
        }

        for (int i = 0; i < inputCount; i++)
        {
            
            _weights[i] = playable.GetInputWeight(i);
            ScriptPlayable<AudioMixerSnapshotBehaviour> inputPlayable = (ScriptPlayable<AudioMixerSnapshotBehaviour>)playable.GetInput(i);
            AudioMixerSnapshotBehaviour input = inputPlayable.GetBehaviour ();
            _snapshots[i] = input.Snapshot;
        }

        trackBinding.TransitionToSnapshots(_snapshots, _weights, 0);
    }
}
