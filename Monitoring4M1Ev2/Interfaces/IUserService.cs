using Monitoring4M1Ev2.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Interfaces
{
    public interface IUserService
    {
        List<UserDetail> GetAllUserDetails();
        UserDetail GetUserDetailById(int userDetailId);
        void AddUser(UserDetailDto dto, int currentUser);
        void AddNewLineForUser(int userDetailId, string[] Lines);
        void UpdatePassword(int userDetailId, string updatedPassword);

        UserDetail LoginUser(LoginUser user);
        bool CheckPassword(LoginUser user);
        string[] GetAvailLines();
        void AddNewLine(Lines line);
    }
}
