using System.Collections.Generic;

namespace PhotoResize.Validator
{
    public class ValidatorResult
    {
        public ValidatorResult()
        {
            Errors = new List<string>();
        }

        public bool Valid { get; set; }
        public List<string> Errors { get; set; } 
    }
}
