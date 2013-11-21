using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EasyToRememberPasswords.Models;

namespace EasyToRememberPasswords.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new PasswordViewModel{};

            prepareModel(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(PasswordViewModel model)
        {
            prepareModel(model);

            List<string> wordsWithSelectedCharacterCount;

            using (var db = new PasswordGeneratorContext())
            {
                wordsWithSelectedCharacterCount = (from w in db.WordsLists
                                                      where w.Word.Length == model.SelectedCharacterCount
                                                      select w.Word).ToList();
            }

            var random = new Random();
            var randomIndex = random.Next(wordsWithSelectedCharacterCount.Count);
            var randomWord = wordsWithSelectedCharacterCount.ElementAt(randomIndex);

            model.OriginalWord = randomWord;
            model.Password = MakeSecurePassword(randomWord);

            return View(model);
        }

        private void prepareModel(PasswordViewModel model)
        {
            using (var db = new PasswordGeneratorContext())
            {
                var query = from w in db.WordsLists
                            group w by w.Word.Length
                            into g
                            orderby g.Key
                            select g.Key;

                model.AvailableCharacterCount = query.ToList();

            }
        }

        private string MakeSecurePassword(string word)
        {
            var password = word.ToLower().ReplaceFirst("a", "@")
                           .ReplaceFirst("s", "$")
                           .ReplaceFirst("i","1")
                           .ReplaceFirst("e", "3")
                           .ReplaceFirst("o", "0")
                           ;

            //TODO: change for a recursive function so that it does not change special characters to UPPER (Which doesnt make sense).
            var random = new Random();
            var randomIndex = random.Next(word.Length);
            var character = password[randomIndex];
            password = password.ReplaceFirst(character.ToString(), character.ToString().ToUpper());

            return password;
        }

        
    }

    public static class StringExtensions
    {
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}
