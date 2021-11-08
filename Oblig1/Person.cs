﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }
        // (id 17, firstname= Ola, lastName= Nordmann, birthYears= 2000, deathYear= 3000) 

        public string GetDescription()
        {
            var text = "";
            if (FirstName != null)  text += FirstName + " ";
            if (LastName != null)   text += LastName + " ";
            text += $"(Id={Id}) "; 
            if (BirthYear != null) text += $"Født: {BirthYear} ";
            if (DeathYear != null) text += $"Død: {DeathYear} ";
            if (Father != null)
            {
                text += "Far: ";
                text += GetParentInformation();
            }
            if (Mother != null)
            {
                text += "Mor: ";
                text += GetParentInformation(false);
            }
            
            return text.Trim();
        }
        

        public string GetParentInformation(bool isFather = true)
        {
            var parent = isFather ? Father : Mother;
            var text = "";
            text += $"{parent.FirstName} ";
            text += $"(Id={parent.Id}) ";
            
            return text;
        }
     
            
    }




}

