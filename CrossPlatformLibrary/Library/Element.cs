using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.Library
{
    public class BaseElement
    {
        public string Id { get; internal set; }

        public BaseElement()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
