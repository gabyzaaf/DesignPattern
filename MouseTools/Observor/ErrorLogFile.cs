using System;

namespace MouseTools.Observor
{
    public class ErrorLogFile : Observer
    {
       
        public ErrorLogFile(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }

        public override void Write(string message)
        {
            string errorsValue = String.Format("{0} Error : {1} ",DateTime.Now.ToString(),message);
            Log log = Wrapper.GetLogPath("mouse");
            log.WriteContent(errorsValue);
        }
    }
}
