using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1
{
    public class FamilyApp
    {

        public List<Person> People;
        public string WelcomeMessage = "Kongehuset Norge";
        public string CommandPrompt = "Skriv en kommando(hjelp, liste, vis <tall> \n";

        public FamilyApp(params Person[] family)
        {
            People = new List<Person>(family);
        }

        public string commandPromt(string input)
        {

            if (input == "hjelp")
            {
                return HelpText();

            }
            else if (input == "liste")
            {
                return ShowList(People);
            }
            else if (input.Contains("vis "))
            {
                return GetPersonById(People, input);

            }
            else
            {
                return  "hjelp => viser en hjelpetekst som forklarer alle kommandoene. \r\n"+
                        "liste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert. \r\n"+ 
                        "vis<id> => viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem).";
            }
        }

        private static string GetPersonById(List<Person> People, string input)
        {
            int personId = Int32.Parse(input.Substring(input.IndexOf(" ") + 1));
            string text = "";

            List<string> children = new List<string>();

            for (int i = 0; i < People.Count; i++)
            {
                if (People[i].Id == personId)
                {
                    text += People[i].GetDescription() + "\n";

                }

                if (People[i].Mother != null)
                {
                    if (People[i].Mother.Id == personId)
                    {
                        children.Add(People[i].FirstName + " (Id=" + People[i].Id + ") Født: " + People[i].BirthYear);
                    }
                }

                if (People[i].Father != null)
                {
                    if (People[i].Father.Id == personId)
                    {
                        children.Add(People[i].FirstName + " (Id=" + People[i].Id + ") Født: " + People[i].BirthYear);
                    }
                }
            }

            if (children.Count == 0)
            {
                return text;
            }

            else
            {

                text += " " + " Barn:\n";
                for (int i = 0; i < children.Count; i++)
                {
                    if (i == children.Count - 1)
                    {
                        text += "    " + children[i] + "\n";
                    }
                    else
                    {
                        text += "    " + children[i] + "\n";
                    }
                }
            }

            return text;
        }



        public static string ShowList(List<Person> People)
        {
            var listText = "";

            for (int i = 0; i < People.Count; i++)
            {
                listText += People[i].GetDescription() + "\n";
            }
            return listText;
        }


        public static string HelpText()
        {
            return @"
        Kommandoer:
            liste
            vis <id>";
        }
    }

}
