using System.Collections.Generic;
using System.Web.Http;
using DeusVultOnline.Characters;
using DeusVultOnline.Models;

namespace DeusVultOnline.Controllers
{
    [RoutePrefix("api/characters")]
    public class CharacterController : BaseController
    {
        [Route("you")]
        [HttpGet]
        public Character GetMySelf()
        {
            var attribute = new Attribute{ 
                Base = 10,
                Gen = 3,
                Edu = 23,
                Faith = 2,
                Lifest = 23,
                Temp = 12,
                Bonus = 21,
                Skill = 23,
                Equip = 2
                };
            var character =  new Character
            {
                Name = "Roynr",
                Gender = Gender.Tree,
                Marshall = attribute,
                Diplomacy = attribute,
                Stewardship = attribute,
                Intrigue = attribute,
                Learning = attribute,
                Arts = attribute,
                Magic = attribute,
                Attraction = attribute,
                Combat = attribute,
                Health = attribute,
                Attack = attribute,
                Dualwield = attribute,
                Technique = attribute,
                Armor = attribute
            };

            character.SetReligion(ReligionProvider.Religions[0], 1);

            return character;
            //return new Formation[] {new TurtleFormation()};
        }
    }
}