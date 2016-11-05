using System.Collections.Generic;


    public interface IRegister<Tkey, Tval>
    {
        Dictionary<Tkey, List<Tval>> register { get; }
        bool RegisterObject(Tkey key, Tval value);
        bool UnregisterObject(Tkey key, Tval value);
    }
