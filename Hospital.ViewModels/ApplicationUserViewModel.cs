﻿using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class ApplicationUserViewModel
    {
        public List<ApplicationUser> Doctors { get; set; } = new List<ApplicationUser>();
        public string Name { get; set; }
        public string UserName { get; set; }
        public string City { get; set; }
        public bool IsDoctor { get; set; }
        public string Specialist { get; set; }
        public Gender Gender { get; set; }

        public ApplicationUserViewModel()
        {
        }

        public ApplicationUserViewModel(ApplicationUser user)
        {
            Name = user.Name;
            City = user.City;
            IsDoctor = user.IsDoctor;
            Specialist = user.Specialist;
            UserName = user.UserName;
        }

        public ApplicationUser ConvertViewModelToModel(ApplicationUserViewModel user)
        {
            return new ApplicationUser
            {
                Name = user.Name,
                City = user.City,
                IsDoctor = user.IsDoctor,
                Specialist = user.Specialist,
                Gender = user.Gender,
                UserName = user.UserName
            };
        }
    }
}