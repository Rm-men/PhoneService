using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary
{
    public partial class PositionInOrder
    {
        public int IdPosition { get; set; }
        public int IdPushareAgreement { get; set; }
        public string IdProduct { get; set; }
        public int? CountStaf { get; set; }

        public virtual Product IdProductNavigation { get; set; }
        public virtual PushareAgreement IdPushareAgreementNavigation { get; set; }
    }
}
