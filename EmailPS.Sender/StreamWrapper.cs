using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailPS.Sender {
    public class StreamWrapper {
        public Stream Stream { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
