using System;
using System.Collections.Generic;

namespace EasyToRememberPasswords.Models
{
    public partial class WordsList
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public int LetterCount { get; set; }
    }
}
