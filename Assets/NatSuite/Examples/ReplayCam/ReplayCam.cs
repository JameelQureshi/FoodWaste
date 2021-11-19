/* 
*   NatCorder
*   Copyright (c) 2020 Yusuf Olokoba
*/

namespace NatSuite.Examples {

    using UnityEngine;
    using System.Collections;
    using Recorders;
    using Recorders.Clocks;
    using Recorders.Inputs;
    using System.IO;
    using System;
    using NatSuite.Sharing;

    public class ReplayCam : MonoBehaviour {

        [Header("Recording")]
        private int videoWidth;
        private int videoHeight;
        public bool recordMicrophone;

        private IMediaRecorder recorder;
        private CameraInput cameraInput;
        private AudioInput audioInput;
        private AudioSource microphoneSource;
        public AudioListener audioListener;
        private string path;  
      

        private IEnumerator Start () {
            // Start microphone
            microphoneSource = gameObject.AddComponent<AudioSource>();
            microphoneSource.mute =
            microphoneSource.loop = true;
            microphoneSource.bypassEffects =
            microphoneSource.bypassListenerEffects = false;
            microphoneSource.clip = Microphone.Start(null, true, 10, AudioSettings.outputSampleRate);
            yield return new WaitUntil(() => Microphone.GetPosition(null) > 0);
            microphoneSource.Play();

            // Video Size according to screen

            videoWidth  = Screen.width;
            videoHeight = Screen.height;

        }

        private void OnDestroy () {
            // Stop microphone
            microphoneSource.Stop();
            Microphone.End(null);
        }

        public void StartRecording () {
            // Start recording
            var frameRate = 30;
            var sampleRate = recordMicrophone ? AudioSettings.outputSampleRate : 0;
            var channelCount = recordMicrophone ? (int)AudioSettings.speakerMode : 0;
            var clock = new RealtimeClock();
            recorder = new MP4Recorder(videoWidth, videoHeight, frameRate, sampleRate, channelCount);
            // Create recording inputs
            cameraInput = new CameraInput(recorder, clock, Camera.main);
            audioInput = new AudioInput(recorder,clock,audioListener);

        }

        

        public async void StopRecording () {
            audioInput?.Dispose();
            cameraInput.Dispose();

            path = await recorder.FinishWriting();

            byte[] bytes = File.ReadAllBytes(path);
            string destination = Application.persistentDataPath +"capture"+ ".mp4";
            File.WriteAllBytes(destination, bytes);
            Debug.Log("Video Saved at: "+destination);

            try
            {
                var sharepayload = new SavePayload();
                sharepayload.AddMedia(path);
                await sharepayload.Commit();
            }
            catch
            {

            }
            
        }

        
       
    }
}