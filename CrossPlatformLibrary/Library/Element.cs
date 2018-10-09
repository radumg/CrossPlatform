using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.Library
{
    public class Element
    {
        public string Id { get; internal set; }

        public Element()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
