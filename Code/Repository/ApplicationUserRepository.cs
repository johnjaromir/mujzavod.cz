using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MujZavod.Data;
using MujZavod.Data.Identity;

namespace MujZavod.Code.Repository
{
    //xx
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>
    {
        protected override string dbSetContextName => "Users";


        protected override Expression<Func<ApplicationUser, bool>> ByIdExpression(object id)
        {
            ParameterExpression argParam = Expression.Parameter(typeof(ApplicationUser), "x");
            Expression nameProperty = Expression.Property(argParam, "Id");
            ConstantExpression val = Expression.Constant(id);
            Expression expression = Expression.Equal(nameProperty, val);

            return Expression.Lambda<Func<ApplicationUser, bool>>(expression, argParam);
        }

        public ApplicationUser GetActAu()
        {
            return GetById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        }

        

        public void Create(ApplicationUser entity, string[] roles)
        {
            var userManager = new MujZavod.Data.Identity.ApplicationUserManager(
                new Microsoft.AspNet.Identity.EntityFramework.UserStore<MujZavod.Data.Identity.ApplicationUser>(Context));




            var result = userManager.Create(entity);
            result = userManager.SetLockoutEnabled(entity.Id, false);



            var rolesForUser = userManager.GetRoles(entity.Id);

            foreach (string role in roles)
            {
                if (!rolesForUser.Contains(role))
                {
                    var res = userManager.AddToRole(entity.Id, role);
                }
            }
        }


        public override void Remove(ApplicationUser entity, bool saveChanges)
        {
            var userManager = new MujZavod.Data.Identity.ApplicationUserManager(
                new Microsoft.AspNet.Identity.EntityFramework.UserStore<MujZavod.Data.Identity.ApplicationUser>(Context));

            /*
            userManager.SetLockoutEnabled(entity.Id, true);
            userManager.SetLockoutEndDate(entity.Id, new DateTime(3000, 1, 1));
            */

            userManager.Delete(entity);
        }

        public override IQueryable<ApplicationUser> GetAll()
        {
            return base.GetAll().Where(x => !x.LockoutEndDateUtc.HasValue || x.LockoutEndDateUtc < new DateTime(2999, 1, 1)).OrderBy(u => u.LastName).ThenBy(u => u.FirstName);
        }


        public void enableAccount(ApplicationUser entity)
        {
            var userManager = new MujZavod.Data.Identity.ApplicationUserManager(
                new Microsoft.AspNet.Identity.EntityFramework.UserStore<MujZavod.Data.Identity.ApplicationUser>(Context));

            userManager.SetLockoutEnabled(entity.Id, false);

        }


        public bool isUsernameFree(string userName)
        {
            return base.GetAll().Where(x => x.UserName == userName).Count() == 0;
        }

        public static string GetFullName(ApplicationUser user)
        {
            if (user == null)
                return string.Empty;
            return user.FirstName + " " + user.LastName;
        }

        

        

        
    }
}
