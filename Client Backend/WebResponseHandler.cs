using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client {
    public class WebResponseHandler {
        public delegate void WebResponseDelegate(WebResponseHandler sender);
        public event WebResponseDelegate OnResponseReceived;
        protected void SendResponseEvent() {
            OnResponseReceived(this);
        }
    }
}
