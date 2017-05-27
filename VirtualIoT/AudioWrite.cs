using NAudio.Wave;
using NAudio.Lame;
using NAudio.MediaFoundation;
using System.Net.Security;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualIoT
{
    class AudioWrite
    {
        private bool _isPlayback = false;

        public void StartPlayback(FixedSizedQueue<byte[]> queue)
        {
            var waveOut = new WaveOutEvent();
            if (_isPlayback)
                return;

            using (Mp3FileReader mp3 = new Mp3FileReader(new QueueStream(queue)))
            {
                waveOut.Init(mp3);
                waveOut.Play();
            }
        }

    }
}
