using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StarThrower.WcfProviders.Contract
{
    [DataContract]
    public class BinaryProfileItem : ProfileItem
    {
        [DataMember]
        public byte[] Value { get; set; }
    }
}
