using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;


namespace optic
{
    public partial class sinav_islemleri : Form
    {
        public sinav_islemleri()
        {
            InitializeComponent();
        }


        private void mysqltest_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    // Veritabanına bir kullanıcı ekleyin
                    var newUser = new User { Name = "Test User" };
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    MessageBox.Show("Kullanıcı başarıyla eklendi.");

                    // Veritabanındaki tüm kullanıcıları getirin
                    var users = context.Users.ToList();
                    foreach (var user in users)
                    {
                        Console.WriteLine($"ID: {user.Id}, Name: {user.Name}");
                    }

                    MessageBox.Show("Veritabanındaki kullanıcılar başarıyla listelendi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı işlemi sırasında bir hata oluştu: {ex.Message}");
            }

        }
    }
}
