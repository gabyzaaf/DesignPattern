using System.Collections.Generic;

namespace MouseTools.Observor
{
    public class Subject
    {
        public List<Observer> ListeObserver { get; private set; }
        private string message;

        public Subject(string sMessage)
        {
            ListeObserver = new List<Observer>();
            message = sMessage;
        }

        public void Attach(Observer observer)
        {
            ListeObserver.Add(observer);
        }

        public void NotifyAllObservers()
        {
            foreach (Observer observer in ListeObserver)
            {
                observer.Write(message);
            }
        }
    }
}
