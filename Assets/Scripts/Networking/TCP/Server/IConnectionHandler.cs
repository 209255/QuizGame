using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public interface IConnectionHandler
    {
    void Start();
    void RemoveClient(ushort id);
    Action<ushort> NewConnection { get; set; }

    }

