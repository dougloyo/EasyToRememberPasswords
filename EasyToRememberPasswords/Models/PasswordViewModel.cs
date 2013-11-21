using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyToRememberPasswords.Models
{
    public class PasswordViewModel
    {
        public List<int> AvailableCharacterCount { get; set; }
        public int SelectedCharacterCount { get; set; }
        public string OriginalWord { get; set; }
        public string Password { get; set; }
    }
}