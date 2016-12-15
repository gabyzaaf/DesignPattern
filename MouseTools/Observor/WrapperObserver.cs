using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseTools.Observor
{
    public class WrapperObserver
    {
        public WrapperObserver(string message)
        {
            Subject subject = new Subject(message);
            ErrorLogFile error = new ErrorLogFile(subject);
            subject.NotifyAllObservers();
        }
    }
}
