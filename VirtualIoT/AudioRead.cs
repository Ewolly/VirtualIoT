using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using NAudio.Lame;
using NAudio.MediaFoundation;
using System.Net.Security;
using System.IO;

namespace VirtualIoT
{
    public class AudioRead
    {
        private IWaveIn _waveIn;
        private LameMP3FileWriter _writer;
        private bool _isRecording = false;

        public void StartRecording()
        {
            if (_isRecording)
                return;

            _waveIn = new WasapiLoopbackCapture();
            _writer = new LameMP3FileWriter(new MemoryStream(), _waveIn.WaveFormat, 320);
            _waveIn.DataAvailable += OnDataAvailable;
            _waveIn.RecordingStopped += OnRecordingStopped;
            _waveIn.StartRecording();
            _isRecording = true;

        }

        void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            _writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private string _filename = "";
        public string Filename
        {
            get
            {
                return _filename;
            }
        }

        void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            if (_writer != null)
            {
                _writer.Close();
                _writer = null;
            }
            if (_waveIn != null)
            {
                _waveIn.Dispose();
                _waveIn = null;
            }
            _isRecording = false;
            if (e.Exception != null)
                throw e.Exception;
        }

        public void StopRecording()
        {
            if (_waveIn == null)
            {
                return;
            }
            _waveIn.StopRecording();
        }
    }
}