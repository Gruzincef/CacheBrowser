using System.Threading;

namespace WorkBrowser
{
    /// <summary>
    /// Description of Threaders.
    /// </summary>
    public class Threaders
    {
        public Threaders()
        {
        }
        private Thread WorkThreading;
        public delegate void FunctionThreadNonArg();
        public delegate void FunctionThreadArg(object ob);
        public Thread StartThead(FunctionThreadArg functionthreadarg, object ob)
        {
            WorkThreading = new Thread(new ParameterizedThreadStart(functionthreadarg));
            WorkThreading.Start(ob);
            WorkThreading.IsBackground = true;
            return WorkThreading;
        }
        public Thread StartThead(FunctionThreadNonArg functionthreadnonarg)
        {
            WorkThreading = new Thread(new ThreadStart(functionthreadnonarg));
            WorkThreading.Start();
            WorkThreading.IsBackground = true;
            return WorkThreading;
        }
        public void AbortThead(int tm)
        {
            if (WorkThreading.IsAlive) WorkThreading.Abort(tm);
        }
        public Thread GetTheard()
        {
            return WorkThreading;
        }

    }
}
