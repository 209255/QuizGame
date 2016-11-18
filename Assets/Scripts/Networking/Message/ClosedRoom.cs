using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class ClosedRoom:Message
    {
      
        public ClosedRoom()
        {
            this.subject = MessageSubject.ClosedRoom;
        }
        public ClosedRoom(IMessage msg)
        {
            this.subject = msg.subject;
            this.raw = msg.raw;
            string[] data = raw[1].Split(MessageSeparators.dataSeparator);
            

        }
    
    }

