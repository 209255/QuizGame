using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Player
    {
        public bool isReady { get; set; }
        public bool isHost { get; set; }
        public int score { get;  set; }
        public ushort PlayerId { get; private set; }
    public Player(ushort id)
    {
        PlayerId = id;

    }
    }

