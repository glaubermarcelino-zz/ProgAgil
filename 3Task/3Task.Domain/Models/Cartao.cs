using System;
using System.Collections.Generic;
using System.Text;

namespace _3Task.Domain.Models
{
    public class Cartao
    {
            public string id { get; set; }
            public object checkItemStates { get; set; }
            public bool closed { get; set; }
            public DateTime dateLastActivity { get; set; }
            public string desc { get; set; }
            public object descData { get; set; }
            public object dueReminder { get; set; }
            public string idBoard { get; set; }
            public string idList { get; set; }
            public object[] idMembersVoted { get; set; }
            public int idShort { get; set; }
            public object idAttachmentCover { get; set; }
            public string[] idLabels { get; set; }
            public bool manualCoverAttachment { get; set; }
            public string name { get; set; }
            public int pos { get; set; }
            public string shortLink { get; set; }
            public bool isTemplate { get; set; }
            public Badges badges { get; set; }
            public bool dueComplete { get; set; }
            public object due { get; set; }
            public object[] idChecklists { get; set; }
            public string[] idMembers { get; set; }
            public Etiqueta[] Etiquetas { get; set; }
            public string shortUrl { get; set; }
            public bool subscribed { get; set; }
            public string url { get; set; }
            public Capa Capa { get; set; }
        
    }
}
