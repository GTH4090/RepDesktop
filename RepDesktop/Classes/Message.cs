using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepDesktop.Models
{
    public partial class Message
    {
        public string Floor1 { get
            {
                return string.Join(", ", Floor1ForMessage.Select(el => el.Light));
            } }
        public string Floor2
        {
            get
            {
                return string.Join(", ", Flooor2ForMessage.Select(el => el.Light));
            }
        }
        public string Floor3
        {
            get
            {
                return string.Join(", ", Floor3forMessage.Select(el => el.Light));
            }
        }
        public string Floor4
        {
            get
            {
                return string.Join(", ", Flor4ForMessage.Select(el => el.Light));
            }
        }

        public string windowsForRoom { get
            {
                return string.Join(", ", this.WindowsForRoom.Select(el => el.Count));
            } }
    }
}
