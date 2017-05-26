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
            if (_isPlayback)
                return;


        }

    }
}
