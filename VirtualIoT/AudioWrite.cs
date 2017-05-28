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
using System.Threading;

namespace VirtualIoT
{
    public class AudioWrite
    {
        private MemoryStream _inStream = null;

        private Stream ms = new MemoryStream();
        public void StreamMp3(object unused)
        {
            new Thread(delegate (object o)
            {
                byte[] buffer = new byte[65536]; // 64KB chunks
                int read;
                _inStream.Position = 0;
                while ((read = _inStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    var pos = ms.Position;
                    ms.Position = ms.Length;
                    ms.Write(buffer, 0, read);
                    ms.Position = pos;
                }
                _inStream.Position = 0;
            }).Start();

            // Pre-buffering some data to allow NAudio to start playing
            while (ms.Length < 200)
                Thread.Sleep(100);

            ms.Position = 0;
            using (WaveStream blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms))))
            {
                using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                {
                    waveOut.Init(blockAlignedStream);
                    waveOut.Play();
                    while (waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(100);
                    }
                }
            }
        }

        public MemoryStream StartPlayback()
        {
            if (_inStream != null)
                return _inStream;

            _inStream = new MemoryStream();
            ThreadPool.QueueUserWorkItem(StreamMp3);
            return _inStream;
        }
    }
}
