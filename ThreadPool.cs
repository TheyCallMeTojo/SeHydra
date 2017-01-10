using System.Collections.Generic;
using System.Threading;

namespace SeHydra
{
    class ThreadPool
    {
        public static readonly Queue<string> Queue = new Queue<string>();
        private static readonly AutoResetEvent NewItemEvent = new AutoResetEvent(false);

        /// <summary>
        /// Fast clear the que to stop all work
        /// </summary>
        public static void ClearQeue()
        {
            Queue.Clear();
        }

        /// <summary>
        /// Adds URI into queue and signals about new item
        /// </summary>
        /// <param name="uri"></param>
        public static void Enqueue(string uri)
        {
            lock (Queue)
            {
                Queue.Enqueue(uri);
                NewItemEvent.Set();
            }
        }

        /// <summary>
        /// Get an URI from the queue if one exists. If no URI queued, the thread 
        /// is blocked until new URI is available
        /// </summary>
        /// <returns></returns>
        public static string Dequeue()
        {
            // Check if there is an URI queued. If the queue is empty,
            // wait for new URI to be  added. Otherwise give it away for processing.
            while (true)
            {
                // Accessing queue must be synchronized.
                Monitor.Enter(NewItemEvent);

                if (Queue.Count > 0)
                {
                    // At least one URI exists. Dequeue it and return to a caller.
                    var uri = Queue.Dequeue();
                    Monitor.Exit(NewItemEvent);
                    return uri;
                }
                // No URI is available. Wait for new URI to be queued.
                //LblReady.Text = "Done"; ?
                Monitor.Exit(NewItemEvent);
                NewItemEvent.WaitOne();
            }
        }
    }
}
