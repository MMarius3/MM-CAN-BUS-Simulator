using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAN_Project.Models
{
    public class Node
    {
        public int Length { get; set; }
        public int Identifier { get; set; }

        public List<Message> Messages{ get; set; }

        public Node(int length, int identifier, List<Message> messages)
        {
            this.Length = length;
            this.Identifier = identifier;
            this.Messages = messages;
        }
    }
}