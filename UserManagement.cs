using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Diagnostics.Eventing.Reader;
using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.Logging;
using System.IO;
using System.Collections;

namespace SystemObslugiPrzychodni
{
    public class UserManagement
    {
        public static List<User> users = new List<User>();
        public static string dbpath = "C:\\Users\\lipsk\\Source\\Repos\\SystemObslugiPrzychodni-main\\database.db";

        private static int lastUserId = 0;

        public class ForgottenUserInfo
        {
            public int UserId { get; set; }
            public string ForgottenName { get; set; }
            public string ForgottenSurname { get; set; }
            public string ForgottenDate { get; set; }
            public int AdminId { get; set; }
        }

        public static List<ForgottenUserInfo> GetForgottenUsers()
        {
            List<ForgottenUserInfo> forgotten = new List<ForgottenUserInfo>();

            using (var connection = new SqliteConnection("Data Source=" + dbpath))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
            SELECT *
            FROM tbl_user
            WHERE is_active = 0 AND role_id = '-1';
        ";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string surname = reader.GetString(2);

                                forgotten.Add(new ForgottenUserInfo
                                {
                                    UserId = id,
                                    ForgottenName = $"{name}",
                                    ForgottenSurname = $"{surname}",
                                    ForgottenDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 
                                    AdminId = 1
                                }); ;
                            }
                }
            }

            return forgotten;
        }

        public static void ForgetUser(User user, int adminId)
        {
            user.Name = GenerateRandomString(6);
            user.Surname = GenerateRandomString(8);
            user.City = "Anonimowe";
            user.Post_Code = "00-000";
            user.Street = "Anonimowa";
            user.Street_number = "0";
            user.Apartment_number = null;
            user.Pesel = GenerateRandomPesel();
            user.DateOfBirth = "1900-01-01";
            user.Sex = "X";
            user.Email = $"anon{new Random().Next(10000, 99999)}@anon.com";
            user.Phone = "000000000";
            user.Login = "anon" + new Random().Next(10000, 99999);
            user.Password = GenerateRandomString(10);
            user.Role_id = -1;
            user.Is_active = false;

            using (var connection = new SqliteConnection("Data Source=" + dbpath))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
            UPDATE tbl_user
            SET
                login = $login,
                password = $password,
                name = $name,
                surname = $surname,
                city = $city,
                post_code = $post_code,
                street = $street,
                street_number = $street_number,
                apartment_number = $apartment_number,
                pesel = $pesel,
                date_of_birth = $date_of_birth,
                sex = $sex,
                email = $email,
                phone = $phone,
                role_id = $role_id,
                is_active = $is_active
            WHERE user_id = $user_id;
        ";

                command.Parameters.AddWithValue("$user_id", user.User_id);
                command.Parameters.AddWithValue("$login", user.Login);
                command.Parameters.AddWithValue("$password", user.Password);
                command.Parameters.AddWithValue("$name", user.Name);
                command.Parameters.AddWithValue("$surname", user.Surname);
                command.Parameters.AddWithValue("$city", user.City);
                command.Parameters.AddWithValue("$post_code", user.Post_Code);
                command.Parameters.AddWithValue("$street", user.Street);
                command.Parameters.AddWithValue("$street_number", user.Street_number);
                command.Parameters.AddWithValue("$apartment_number", (object?)user.Apartment_number ?? DBNull.Value);
                command.Parameters.AddWithValue("$pesel", user.Pesel);
                command.Parameters.AddWithValue("$date_of_birth", user.DateOfBirth);
                command.Parameters.AddWithValue("$sex", user.Sex);
                command.Parameters.AddWithValue("$email", user.Email);
                command.Parameters.AddWithValue("$phone", user.Phone);
                command.Parameters.AddWithValue("$role_id", user.Role_id);
                command.Parameters.AddWithValue("$is_active", user.Is_active ? 1 : 0);

                command.ExecuteNonQuery();
            }
        }


        private static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        private static string GenerateRandomPesel()
        {
            Random rand = new Random();
            return string.Join("", Enumerable.Range(0, 11).Select(i => rand.Next(10).ToString()));
        }

        public static int GetNextUserId()
        {
            using (var connection = new SqliteConnection("Data Source="+dbpath))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    SELECT user_id
                    FROM tbl_user
                    ORDER BY user_id DESC
                    LIMIT 1;
                ";
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int lastUserId))
                {
                    return lastUserId + 1;
                }
            }
            return 1;
        }

        public static void AddUser(User user)
        {
            using (var connection = new SqliteConnection("Data Source="+dbpath))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                                        INSERT INTO tbl_user (
                                        login, password, name, surname, city, post_code, street, street_number, apartment_number, 
                                        pesel, date_of_birth, sex, email, phone, role_id, is_active
                                        )
                                        VALUES (
                                        $login, $password, $name, $surname, $city, $post_code, $street, $street_number, $apartment_number, 
                                        $pesel, $date_of_birth, $sex, $email, $phone, $role_id, $is_active
                                        );
                                       ";
                command.Parameters.AddWithValue("$login", user.Login);
                command.Parameters.AddWithValue("$password", user.Password);
                command.Parameters.AddWithValue("$name", user.Name);
                command.Parameters.AddWithValue("$surname", user.Surname);
                command.Parameters.AddWithValue("$city", user.City);
                command.Parameters.AddWithValue("$post_code", user.Post_Code);
                command.Parameters.AddWithValue("$street", user.Street);
                command.Parameters.AddWithValue("$street_number", user.Street_number);

                if (user.Apartment_number == null)
                {
                    command.Parameters.AddWithValue("$apartment_number", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("$apartment_number", user.Apartment_number);
                }

                command.Parameters.AddWithValue("$pesel", user.Pesel);
                command.Parameters.AddWithValue("$date_of_birth", user.DateOfBirth);
                command.Parameters.AddWithValue("$sex", user.Sex);
                command.Parameters.AddWithValue("$email", user.Email);
                command.Parameters.AddWithValue("$phone", user.Phone);
                command.Parameters.AddWithValue("$role_id", user.Role_id);
                command.Parameters.AddWithValue("$is_active", 1);


                command.ExecuteNonQuery();
            }
        }

        public static void EditUser(User user)
        {
            using (var connection = new SqliteConnection("Data Source="+dbpath))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE tbl_user
                                        SET
                                            login = $login,
                                            password = $password,
                                            name = $name,
                                            surname = $surname,
                                            city = $city,
                                            post_code = $post_code,
                                            street = $street,
                                            street_number = $street_number,
                                            apartment_number = $apartment_number,
                                            pesel = $pesel,
                                            date_of_birth = $date_of_birth,
                                            sex = $sex,
                                            email = $email,
                                            phone = $phone,
                                            role_id = $role_id                                           
                                        WHERE user_id = $user_id;
                                        ";

                command.Parameters.AddWithValue("$user_id", user.User_id);
                command.Parameters.AddWithValue("$login", user.Login);
                command.Parameters.AddWithValue("$password", user.Password);
                command.Parameters.AddWithValue("$name", user.Name);
                command.Parameters.AddWithValue("$surname", user.Surname);
                command.Parameters.AddWithValue("$city", user.City);
                command.Parameters.AddWithValue("$post_code", user.Post_Code);
                command.Parameters.AddWithValue("$street", user.Street);
                command.Parameters.AddWithValue("$street_number", user.Street_number);

                if (user.Apartment_number == null)
                {
                    command.Parameters.AddWithValue("$apartment_number", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("$apartment_number", user.Apartment_number);
                }

                command.Parameters.AddWithValue("$pesel", user.Pesel);
                command.Parameters.AddWithValue("$date_of_birth", user.DateOfBirth);
                command.Parameters.AddWithValue("$sex", user.Sex);
                command.Parameters.AddWithValue("$email", user.Email);
                command.Parameters.AddWithValue("$phone", user.Phone);
                command.Parameters.AddWithValue("$role_id", user.Role_id);


                command.ExecuteNonQuery();
            }
        }

        public static List<User> GetAllUsers()
        {
            users.Clear();

            using (var connection = new SqliteConnection("Data Source="+dbpath))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                                        SELECT *
                                        FROM tbl_user;
                                       ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int userId = reader.GetInt32(0);
                        string login = reader.GetString(1);
                        string password = reader.GetString(2);
                        string name = reader.GetString(3);
                        string surname = reader.GetString(4);
                        string city = reader.GetString(5);
                        string postCode = reader.GetString(6);
                        string street = reader.GetString(7);
                        string streetNumber = reader.GetString(8);
                        string? apartmentNumber = reader.IsDBNull(9) ? null : reader.GetString(9);
                        string pesel = reader.GetString(10);
                        string dateOfBirth = reader.GetString(11);
                        string sex = reader.GetString(12);
                        string email = reader.GetString(13);
                        string phone = reader.GetString(14);
                        int roleId = reader.GetInt32(15);
                        bool isActive = reader.GetBoolean(16);

                        User user = new User(userId,login, password, name, surname, city, postCode, street, streetNumber, apartmentNumber,
                                             pesel, dateOfBirth, sex, email, phone, roleId, is_active: true);

                        users.Add(user);
                    }
                }
            }

            return users;
        }

        public static bool IsValueUnique(string value, string columnName)
        {
            var allowedColumns = new List<string> { "pesel", "email", "login"};
            if (!allowedColumns.Contains(columnName))
            {
                throw new ArgumentException("Nieprawidłowa nazwa kolumny.", nameof(columnName));
            }

            using (var connection = new SqliteConnection("Data Source="+dbpath))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = $"SELECT COUNT(*) FROM tbl_user WHERE {columnName} = $value;";
                command.Parameters.AddWithValue("$value", value);

                long count = (long)command.ExecuteScalar();
                return count == 0;
            }
        }
    }
}