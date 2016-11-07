using System.Collections.Generic;


    public class Register<Tkey, Tval> : IRegister<Tkey, Tval>
    {

        public Dictionary<Tkey, List<Tval>> register { get; private set; }

        public Register()
        {
            register = new Dictionary<Tkey, List<Tval>>();
        }

        public bool RegisterObject(Tkey key, Tval value)
        {
            if (!register.ContainsKey(key))
            {
                List<Tval> list = new List<Tval>() { value };
                register.Add(key, list);
                return true;
            }

            if (register[key].Contains(value))
                return false;

            register[key].Add(value);
            return true;
        }

        public bool UnregisterObject(Tkey key, Tval value)
        {
            if (!register.ContainsKey(key))
                return false;
            bool success = register[key].Remove(value);

            if (register[key].Count == 0)
                register.Remove(key);

            return success;
        }
    }


