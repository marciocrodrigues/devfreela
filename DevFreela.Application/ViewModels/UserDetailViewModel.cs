using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class UserDetailViewModel
    {
        public UserDetailViewModel(string fullName, string email, DateTime birthDate, DateTime cratedAt, bool active)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            CratedAt = cratedAt;
            Active = active;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CratedAt { get; private set; }
        public bool Active { get; private set; }
    }
}
