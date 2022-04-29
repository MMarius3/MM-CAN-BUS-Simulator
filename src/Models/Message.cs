using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAN_Project.Models
{
    public class Message
    {
        public bool SOF { get; set; }
        public List<bool> Identifier { get; set; }
        public bool RTR { get; set; }
        public List<bool> DLC { get; set; }
        public List<bool> Data { get; set; }
        public bool ACK { get; set; }
        public List<bool> EOF { get; set; }
        public bool Done { get; set; }

        public Message(bool sof, List<bool> identifier, bool rtr, List<bool> dlc, List<bool> data, bool ack, List<bool> eof, bool done)
        {
            this.SOF = sof;
            this.Identifier = identifier;
            this.RTR = rtr;
            this.DLC = dlc;
            this.Data = data;
            this.ACK = ack;
            this.EOF = eof;
            this.Done = done;
        }

        public Message()
        {
        }
    }
}
