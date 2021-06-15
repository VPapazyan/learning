using System;
using System.Runtime.InteropServices;

namespace OtherGCFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryPressureDemo(0); // 0 causes infrequent GCs
            MemoryPressureDemo(10 * 1024 * 1024); // 10MB causes frequent GCs
            HandleCollectorDemo();
        }

        private static void MemoryPressureDemo(Int32 size)
        {
            Console.WriteLine();
            Console.WriteLine("MemoryPressureDemo, size={0}", size);
            // Create a bunch of objects specifying their logical size
            for (Int32 count = 0; count < 15; count++)
            {
                new BigNativeResource(size);
            }
            // For demo purposes, force everything to be cleaned-up
            GC.Collect();
        }

        private static void HandleCollectorDemo()
        {
            Console.WriteLine();
            Console.WriteLine("HandleCollectorDemo");
            for (Int32 count = 0; count < 10; count++) new LimitedResource();
            // For demo purposes, force everything to be cleaned-up
            GC.Collect();
        }
        private sealed class LimitedResource
        {
            // Create a HandleCollector telling it that collections should
            // occur when two or more of these objects exist in the heap
            private static readonly HandleCollector s_hc = new HandleCollector("LimitedResource", 2);
            public LimitedResource()
            {
                // Tell the HandleCollector a LimitedResource has been added to the heap
                s_hc.Add();
                Console.WriteLine("LimitedResource create. Count={0}", s_hc.Count);
            }
            ~LimitedResource()
            {
                // Tell the HandleCollector a LimitedResource has been removed from the heap
                s_hc.Remove();
                Console.WriteLine("LimitedResource destroy. Count={0}", s_hc.Count);
            }
        }


    }
}

