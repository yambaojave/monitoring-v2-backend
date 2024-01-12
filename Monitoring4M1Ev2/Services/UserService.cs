using Microsoft.EntityFrameworkCore;
using Monitoring4M1Ev2.Context;
using Monitoring4M1Ev2.Interfaces;
using Monitoring4M1Ev2.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring4M1Ev2.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<UserDetail> GetAllUserDetails() 
        {
            return _db.UserDetails.Include(e => e.UserLines).ToList();
        }

        public UserDetail GetUserDetailById(int userDetailId)
        {
            return _db.UserDetails.Include(e => e.UserLines).FirstOrDefault(e => e.UserDetailId == userDetailId);
        }

        public void AddUser(UserDetailDto dto, int currentUser)
        {
            var newUser = new UserDetail
            {
                Username = dto.Username,
                PasswordHash = HashPassword(dto.Password),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Role = dto.Role,
                OperatorEmployeeId = dto.OperatorEmployeeId,
                CreatedBy = currentUser
            };

            _db.UserDetails.Add(newUser);
            _db.SaveChanges();

            int userDetailId = newUser.UserDetailId;

            // Line will be a part of user account creation
            AddNewLineForUser(userDetailId, dto.Lines);
        }

        public void AddNewLineForUser(int userDetailId, string[] Lines)
        {
            // Adding a new set of Lines to user
            var linesToAdd = Lines.Select(line => new UserLine
            {
                Line = line,
                UserDetailId = userDetailId
            });

            _db.UserLines.AddRange(linesToAdd);
            _db.SaveChanges();
        }

        public void UpdatePassword(int userDetailId, string updatedPassword)
        {
            var existingUser = _db.UserDetails.Find(userDetailId);
            existingUser.PasswordHash = HashPassword(updatedPassword);
            _db.SaveChanges();
        }


        
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
