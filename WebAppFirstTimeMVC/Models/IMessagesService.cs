using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFirstTimeMVC.Models
{
    public interface IMessagesService    /* Interface with general functionality for messages */
    {
        bool Save(string name, string email, string message); /* Is the message saved? */
        List<string[]>GetAll(); /* All messages are stored in a list array */

    }
}
