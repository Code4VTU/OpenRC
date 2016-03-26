using System;

namespace Betino.Messages
{
    public class MessageInt : EventArgs
    {
        public int Value { get; private set; }

        public MessageInt(int value)
        {
            this.Value = value;
        }
    }
}
