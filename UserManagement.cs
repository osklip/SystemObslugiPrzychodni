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
using System.Globalization;

namespace SystemObslugiPrzychodni
{
    public class UserManagement
    {
        public static List<User> users = new List<User>();
        public static string dbpath = "C:\\Users\\cmoli\\Desktop\\SystemObslugiPrzychodni-master\\database.db";

 

        private static int lastUserId = 0;

        public static int[] CurrentUserPermissions { get; private set; } = new int[7]; // Publiczna tablica na uprawnienia

        public static void LoadCurrentUserPermissions(string login)
        {

            if (string.IsNullOrEmpty(login))
            {
                throw new InvalidOperationException("Login użytkownika jest pusty.");
            }

            int? userId = null;

            using (var connection = new SqliteConnection("Data Source=" + dbpath))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                SELECT user_id
                FROM tbl_user
                WHERE login = $login;
            ";
                command.Parameters.AddWithValue("$login", login);

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    userId = id;
                }
                else
                {
                    throw new InvalidOperationException("Nie znaleziono użytkownika o podanym loginie.");
                }
            }

            if (userId.HasValue)
            {
                // Pobierz uprawnienia na podstawie user_id
                CurrentUserPermissions = GetUserPerms(userId);
            }
        }


        public class ForgottenUserInfo
        {
            public int UserId { get; set; }
            public string ForgottenName { get; set; }
            public string ForgottenSurname { get; set; }
            public string ForgottenDate { get; set; }
            public int AdminId { get; set; }
        }

        public static List<(User user, int[] permissions)> GetUsersWithPermissions()
        {
            return users.Select(user => (user, GetUserPerms(user.User_id))).ToList();
        }
        public static int[] GetUserPerms(int? userId)
        {
            int[] perms = new int[7];
            using (var connection = new SqliteConnection("Data Source=" + dbpath))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
            SELECT *
            FROM tbl_user_perms
            WHERE user_id = $user_id;
";
                command.Parameters.AddWithValue("$user_id", userId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        perms[0] = reader.GetInt32(1); //dodawanie
                        perms[1] = reader.GetInt32(2); //edycja
                        perms[2] = reader.GetInt32(3); //wyswietlanie
                        perms[3] = reader.GetInt32(4); //zapominanie
                        perms[4] = reader.GetInt32(5); //listowanie zapomnianych
                        perms[5] = reader.GetInt32(6); //dodawanie uprawnien
                        perms[6] = reader.GetInt32(7); //obsluga pacjentow
                    }
                }
            }
            return perms;



        }
        public static void UpdateUserPerms(int? userId, int[] userPermissions)
        {
            using (var connection = new SqliteConnection("Data Source=" + dbpath))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
            UPDATE tbl_user_perms
            SET add_user = $add_user,
                edit_user = $edit_user,
                list_users = $list_users,
                forget_user = $forget_user,
                list_forget = $list_forget,
                grant_perms = $grant_perms,
                patients_service = $patients_service
            WHERE user_id = $user_id;
        ";
                command.Parameters.AddWithValue("$user_id", userId);
                command.Parameters.AddWithValue("$add_user", userPermissions[0]);
                command.Parameters.AddWithValue("$edit_user", userPermissions[1]);
                command.Parameters.AddWithValue("$list_users", userPermissions[2]);
                command.Parameters.AddWithValue("$forget_user", userPermissions[3]);
                command.Parameters.AddWithValue("$list_forget", userPermissions[4]);
                command.Parameters.AddWithValue("$grant_perms", userPermissions[5]);
                command.Parameters.AddWithValue("$patients_service", userPermissions[6]);

                command.ExecuteNonQuery();
            }
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
                                string revokedate = reader.GetString(17);
                                int revokerid = reader.GetInt32(18);

                        

                                forgotten.Add(new ForgottenUserInfo
                                {
                                    UserId = id,
                                    ForgottenName = $"{name}",
                                    ForgottenSurname = $"{surname}",
                                    ForgottenDate = $"{revokedate}", 
                                    AdminId = revokerid
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
                is_active = $is_active,
                revoker_id = $adminId
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
                command.Parameters.AddWithValue("$adminId", adminId);

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
                                        FROM tbl_user
                                        WHERE is_active = 1;
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

        public static bool ValidatorPESEL(DateTime dateOfBirth, string pesel, string sex)
        {
            if (pesel.Length != 11 || !pesel.All(char.IsDigit))
                return false;

            string year = dateOfBirth.Year.ToString("00");
            string day = dateOfBirth.Day.ToString("00");
            string rr = dateOfBirth.Year.ToString().Substring(2, 2);

            int mm = dateOfBirth.Month;
            if (dateOfBirth.Year >= 2000 && dateOfBirth.Year < 2100)
                mm += 20; // dodanie 20 do miesiąca

            string rrmmdd = rr + mm.ToString("00") + day;
            if (!pesel.StartsWith(rrmmdd))
                return false;

            int sexNumber = int.Parse(pesel[9].ToString());
            bool IsWoman = sexNumber % 2 == 0;

            if ((sex.ToLower() == "Kobieta" && !IsWoman) ||
                (sex.ToLower() == "Mężczyzna" && IsWoman))
            {
                return false;
            }

            int[] wages = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sum = 0;

            for (int i = 0; i < 10; i++)
            {
                int number = int.Parse(pesel[i].ToString());
                int product = (number * wages[i]) % 10; // tylko ostatnia cyfra
                sum += product;
            }

            int controlNumber = (10 - (sum % 10)) % 10;

            return controlNumber == int.Parse(pesel[10].ToString());
        }
    }
}