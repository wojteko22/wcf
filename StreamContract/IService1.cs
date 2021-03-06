﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StreamContract
{
    [ServiceContract]
    public interface IStrumien {
        [OperationContract]
        System.IO.Stream getStream(string nazwa);

        [OperationContract]
        ResponseFileMessage getMStream(RequestFileMessage request);
    }

    [MessageContract]
    public class RequestFileMessage
    {
        [MessageBodyMember]
        public string nazwa1;
    }
    [MessageContract]
    public class ResponseFileMessage
    {
        [MessageHeader]
        public string nazwa2;
        [MessageHeader]
        public long rozmiar;
        [MessageBodyMember]
        public Stream dane;
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "StreamContract.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
