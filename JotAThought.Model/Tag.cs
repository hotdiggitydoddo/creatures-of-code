using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JotAThought.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Post> Posts { get; set; }
    }
}
