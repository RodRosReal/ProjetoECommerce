
using System;
using System.Runtime.Serialization;

namespace ECommerce.Application.Messages
{

	public partial class AdminModuleResponse
    {
        [DataMember]
        public bool Success
        {
            get
            {
                if (this.Exception != null)
                    return false;
                else
                    return true;
            }
        }

        [DataMember]
        public Exception Exception { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
