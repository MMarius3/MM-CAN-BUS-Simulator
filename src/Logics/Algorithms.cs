using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAN_Project.Models;

namespace CAN_Project.Logics
{
    public class Algorithms
    {
        public List<Message> InputToNodes(List<string> listOfStrings)
        {
            var listOfMessages = new List<Message>();
            foreach (string bits in listOfStrings)
            {
                bool SOFM;
            var IdentifierM = new List<bool>();
            bool RTRM;
            var DLCM = new List<bool>();
            var DataM = new List<bool>();
            bool ACKM;
            var EOFM = new List<bool>();
                if (bits[0] == '1')
                {
                    SOFM = true;
                    }
                else
                {
                    SOFM = false;
                }
                for (int i = 1; i < 12 && i < bits.Length; i++)
                {
                    if (bits[i] == '1')
                    {
                        IdentifierM.Add(true);
                    } 
                    else
                    {
                        IdentifierM.Add(false);
                    }
                }
                if (bits[12] == '1' && 12 < bits.Length)
                {
                    RTRM = true;
                }
                else
                {
                    RTRM = false;
                }
                for (int i = 13; i < 17 && i < bits.Length; i++)
                {
                    if (bits[i] == '1')
                    {
                        DLCM.Add(true);
                    }
                    else
                    {
                        DLCM.Add(false);
                    }
                }
                for (int i = 17; i < 25 && i < bits.Length; i++)
                {
                    if (bits[i] == '1')
                    {
                        DataM.Add(true);
                    }
                    else
                    {
                        DataM.Add(false);
                    }
                }
                if (bits[25] == '1' && 25 < bits.Length)
                {
                    ACKM = true;
                }
                else
                {
                    ACKM = false;
                }
                for (int i = 26; i < 33 && i < bits.Length; i++)
                {
                    if (bits[i] == '1')
                    {
                        EOFM.Add(true);
                    }
                    else
                    {
                        EOFM.Add(false);
                    }
                }
                var newMessage = new Message(SOFM, IdentifierM, RTRM, DLCM, DataM, ACKM, EOFM, false);
                listOfMessages.Add(newMessage);
            }
            return listOfMessages;
        }
        public List<bool> BUSResult(List<Message> myMessageList)
        {
            var bus = new List<bool>();
            for (int i = 0; i < 11; i++)
            {
                bool isZero = false;
                foreach (Message message in myMessageList)
                {
                    var messageIdentifier = BUSOutput(message.Identifier);
                    if (i < messageIdentifier.Length)
                    {
                        if (messageIdentifier[i] == '0' && !message.Done)
                        {
                            isZero = true;
                        }
                    }
                }
                if (isZero)
                {
                    foreach (Message message in myMessageList)
                    {
                        var messageIdentifier = BUSOutput(message.Identifier);
                        if (i < messageIdentifier.Length)
                        {
                            if (messageIdentifier[i] == '1')
                            {
                                message.Done = true;
                            }
                        }
                    }
                }
            }
            foreach (Message message in myMessageList)
            {
                if (!message.Done)
                {
                    bus = message.Data;
                }
            }
            return bus;
        }
        public string BUSOutput(List<bool> boolList)
        {
            var busString = "";
            foreach (bool boolean in boolList)
            {
                if (boolean)
                {
                    busString += "1";
                }
                else
                {
                    busString += "0";
                }
            }
            return busString;
        }
    }
}
