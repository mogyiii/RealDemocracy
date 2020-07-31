using Dec.Shared.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dec.Shared.DTOs
{
    public class VoteSuperVisorDTO : DTOBase
    {
        public int? ApplySuperViserId { get; set; }
        public ApplySuperVisorDTO ApplySuperVisor { get; set; }
        public string HashedKey { get; set; }
    }
}
