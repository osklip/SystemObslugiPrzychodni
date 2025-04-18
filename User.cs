using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SystemObslugiPrzychodni
{
    public class User
    {
        public int? User_id
        { get; set; }

         public string Login
        { get; set; }

        public string Password {get; set;}
        //  private string name;
        public string Name
        { get; set; }

      //  private string surname;
        public string Surname
        { get; set; }

      //  private string city;
        public string City
        { get; set; }

      //  private string post_code;
        public string Post_Code
        { get; set; }

     //   private string street;
        public string? Street
        { get; set; }

      //  private string street_number;
        public string Street_number
        { get; set; }

     //   private string? apartment_number;
        public string? Apartment_number
        { get; set; }

      //  private string pesel;
        public string Pesel
        { get; set; }

      //  private DateOnly date_of_birth;
        public string DateOfBirth
        { get; set; }

      //  private string sex;
        public string Sex
        { get; set; }

      //  private string email;
        public string Email
        { get; set; }

      //  private string phone;
        public string Phone
        { get; set; }

     //   private int role_id;
        public int Role_id
        { get; set; }

    //  private bool is_active;
        public bool Is_active
        { get; set; }

        public User(int user_id, string login, string password, string name, string surname, string city, string post_code, string? street, string street_number, string? apartment_number, 
                    string pesel, string date_of_birth, string sex, string email, string phone, int role_id, bool is_active)
        {
            User_id = user_id;
            Login = login;
            Password = password;
            Name = name;
            Surname = surname;
            City = city;
            Post_Code = post_code;
            Street = street;
            Street_number = street_number;
            Apartment_number = apartment_number;
            Pesel = pesel;
            Sex = sex;
            DateOfBirth = date_of_birth;
            Email = email;
            Phone = phone;
            Role_id = role_id;
            Is_active = is_active;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {Pesel}";
        }
    }
}
