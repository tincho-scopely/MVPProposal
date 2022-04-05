using System;

namespace MVVMFramework.Wiring
{
    public struct WireField
    {
        public string Field;
        public IDisposable Subscription;
        
        public static WireField Empty => new WireField();
    }
}