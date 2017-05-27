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
using Microsoft.VisualBasic;
using System.Threading;

namespace VirtualIoT
{
    public class AudioWrite
    {
        private bool _isPlayback = false;
        private BufferedWaveProvider _bufferedWaveProvider;
        
        public void StartPlayback(SslStream sslStream)
        {
            if (_isPlayback)
                return;
            
            ThreadPool.QueueUserWorkItem(StreamMp3, sslStream);
        }

        public void StreamMp3(object sslStream)
        {
            IWavePlayer waveOut = new WaveOut();

            var sslClient = (SslStream)sslStream;
            var buffer = new byte[16384 * 4];

            IMp3FrameDecompressor decompressor = null;
            try
            {
                do
                {
                    if (IsBufferNearlyFull)
                    {
                        if (waveOut.PlaybackState != PlaybackState.Playing)
                        {
                            waveOut.Play();
                        }
                        Thread.Sleep(100);
                    }
                    else
                    {
                        var readFullyStream = new ReadFullyStream(sslClient);

                        Mp3Frame frame = null;
                        try
                        {
                            frame = Mp3Frame.LoadFromStream(readFullyStream);
                        }
                        catch (EndOfStreamException)
                        {
                            Console.WriteLine("reached the end of the stream?");
                        }
                        if (decompressor == null)
                        {
                            decompressor = CreateFrameDecompressor(frame);
                            _bufferedWaveProvider = new BufferedWaveProvider(decompressor.OutputFormat);
                            _bufferedWaveProvider.BufferDuration = TimeSpan.FromSeconds(1);
                        }
                        int decompressed = decompressor.DecompressFrame(frame, buffer, 0);
                        _bufferedWaveProvider.AddSamples(buffer, 0, decompressed);
                    }
                } while (true);
            }
            finally
            {
                if (decompressor != null)
                    decompressor.Dispose();
            }
        }

        private static IMp3FrameDecompressor CreateFrameDecompressor(Mp3Frame frame)
        {
            WaveFormat waveFormat = new Mp3WaveFormat(frame.SampleRate, frame.ChannelMode == ChannelMode.Mono ? 1 : 2,
                frame.FrameLength, frame.BitRate);
            return new AcmMp3FrameDecompressor(waveFormat);
        }

        private bool IsBufferNearlyFull
        {
            get
            {
                return _bufferedWaveProvider != null &&
                       _bufferedWaveProvider.BufferLength - _bufferedWaveProvider.BufferedBytes
                       < _bufferedWaveProvider.WaveFormat.AverageBytesPerSecond / 4;
            }
        }
    }
}
