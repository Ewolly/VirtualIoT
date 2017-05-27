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

        public void StartRecording(FixedSizedQueue<byte[]> queue)
        {
            if (_isRecording)
                return;

            _waveIn = new WasapiLoopbackCapture();
            _writer = new LameMP3FileWriter(new QueueStream(queue), _waveIn.WaveFormat, 320);
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
    public class QueueStream : Stream
    {
        private FixedSizedQueue<byte[]> _queue;
        public QueueStream(FixedSizedQueue<byte[]> queue)
        {
            _queue = queue;
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override long Length { get { throw new NotImplementedException(); } }

        public override long Position
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _queue.TryDequeue(out buffer) ? buffer.Length : 0;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _queue.Enqueue(buffer);
        }
    }
}
