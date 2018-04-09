using Microsoft.AspNet.Identity.EntityFramework;
using MujZavod.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MujZavod.Code.Extensions
{
    public static class AuthoriseExtensions
    {
        public static Authoriser Can(this IPrincipal principal)
        {
            return new Authoriser(principal);
        }


        public class Authoriser
        {


            IPrincipal _Principal;
            IdentityUser _Identity;

            Data.Identity.ApplicationUser _CurrentUser;

            public Authoriser(IPrincipal principal)
            {
                _Principal = principal;
                _Identity = principal.Identity as IdentityUser;
                _CurrentUser = new Repository.ApplicationUserRepository().GetActAu();
            }

            public bool EditCategory(RaceCategory raceCategory)
            {
                return EditRace(raceCategory.Race ?? new Repository.RaceRepository().GetById(raceCategory.RaceId));
            }

            public bool EditRace(Race race)
            {
                if (race != null)
                    return race.Organizer.Organizers.Where(x=>x.Id == _CurrentUser.Id).Count() > 0;
                return false;
            }

            public bool EditSubCategory(RaceSubCategory raceSubCategory)
            {
                return EditCategory(raceSubCategory?.RaceCategory);
            }


            public void ThrowIfCant(BaseEntity entity, Func<BaseEntity,bool> fnc)
            {
                if (!fnc(entity))
                    throw new Code.Exceptions.MzSecurityException();
            }
        }
    }
}
