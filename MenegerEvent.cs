
namespace CacheBrowser
{
 
    public class MenegerEvent
    {
        public static MenegerEvent instance = new MenegerEvent();
        private MenegerEvent()
        {
        }
        public static MenegerEvent getInstance()
        {
            if (instance == null)
                instance = new MenegerEvent();
            return instance;
        }
        public MessegTask Mess;
        public delegate void OperationDelegate(string messeg);
        public event OperationDelegate Event_Messeg;

        public void SetEvent(string messeg)
        {
            Mess = new MessegTask(messeg);
            Event_Messeg.Invoke(messeg);
        }
    }

}
