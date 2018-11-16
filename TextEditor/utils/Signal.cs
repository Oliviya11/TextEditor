using System;
using System.Collections.Generic;

namespace TextEditor.utils
{
    public class Signal
    {
        Dictionary<string, Delegate> listeners;
        public Signal()
        {
            listeners = new Dictionary<string, System.Delegate>();
        }

        public void AddListener(Delegate func)
        {
            string name = getFullFuncName(func);
            listeners.Add(name, func);
        }

        public void RemoveListener(Delegate func)
        {
            string name = getFullFuncName(func);
            listeners.Remove(name);
        }

        public void Invoke()
        {
            foreach(Delegate func in listeners.Values)
            {
                func.DynamicInvoke();
            }
        }

        string getFullFuncName(Delegate func)
        {
            var methodInfo = func.Method;
            var fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name;
            return fullName;
        }
    }
}
