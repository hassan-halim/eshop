using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel
{
    public class KeyValuePairResource <Tid>
    {
        public Tid Id { get; set; }
        public string Name { get; set; }
    }
}
