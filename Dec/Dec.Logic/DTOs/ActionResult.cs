using System.Collections.Generic;

namespace Dec.Logic.DTOs
{
    public class ActionResult
    {
        public bool Suceeded { get; set; }

        public IList<string> ErrorMessages { get; set; } = new List<string>();
    }
}
