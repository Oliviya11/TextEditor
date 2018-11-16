using System;
using System.Windows;
using System.Windows.Controls;
using TextEditor.managers;
using TextEditor.Models;
using TextEditor.utils;

/*
 * Class MainWindow was made similar to MainWindow from:
 * https://github.com/appleVovan/KMA.APZRPMJ2018.WalletSimulator
 */
namespace TextEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IContentWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
            if (!AutoLoginManager.Instance.readFromXml())
            {
                navigationModel.Navigate(ModesEnum.LogIn);
            }
            /*
            using (TextEditorDbContext db = new TextEditorDbContext())
            {
                // создаем два объекта User
                User user1 = new User("User1", "123");
                User user2 = new User("User2", "456");

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var users = db.Users;
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {
                    MessageBox.Show(u.Login);
                }
            }
            Console.Read();
            */

            /*
            using (TextEditorDbContext db = new TextEditorDbContext())
            {
                db.Database.ExecuteSqlCommand("delete from dbo.Users");
            }
            */
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}
