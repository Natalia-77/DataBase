using Microsoft.EntityFrameworkCore;
using Roles.DAL;
using System.Linq;


namespace FormRoles.Service
{
    public class UserSearchService
    {
        public static UserListModel SearchUser(MyContext context, SearchUser search)
        {
            UserListModel listModel = new UserListModel();
            int showlist = search.CountPage;
            var query = context.UserRoles.Include(u => u.User).Include(rol => rol.Role).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.User.Name.Contains(search.Name));
            }

            if (!string.IsNullOrEmpty(search.Surname))
            {
                query = query.Where(x => x.User.Surname.Contains(search.Surname));
            }

            if (!string.IsNullOrEmpty(search.Position))
            {
                query = query.Where(x => x.Role.Name.Contains(search.Position));
            }

            int page = search.Page - 1;

            //Загальна кількість отриманих Users дорівнює кількості елементів,отриманих в квері.
            listModel.CountRows = query.Count();

            listModel.Users = query
               .OrderBy(x => x.UserId)
               .Skip(page * showlist)
               .Take(showlist)
               .Select(x => new UsersView
               {                   
                   Id=x.User.Id,
                   Name = x.User.Name,
                   Surname=x.User.Surname,
                   Position=x.Role.Name                                     

               }).ToList();

            return listModel;
        }

    }
}
