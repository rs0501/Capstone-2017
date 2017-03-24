﻿using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPresentationLayer
{
    /// <summary>
    /// Interaction logic for CreateNewUser.xaml
    /// </summary>
    public partial class frmCreateNewUser : Window
    {
        public frmCreateNewUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bobby Thorne
        /// 2/12/17
        /// Update
        /// Bobby Thorne
        /// 3/10/2017
        /// 
        /// This manages the create new user it checks each field and
        /// indicates what is invalid later update needs a better check
        /// for username if there is a unexpected exception it will 
        /// just say that the username is already used
        /// 
        /// Update
        /// Added warning labelson right of the text field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            User _user = new User() {
                UserId = 0,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Phone = txtPhone.Text,
                EmailAddress = txtEmailAddress.Text,
                EmailPreferences = (bool)cboEmailPreferences.IsChecked,
                UserName = txtUserName.Text,
                Active = true
            };
            UserManager _userManager = new UserManager();
            string result;

            pwbPassword.Background = Brushes.White;
            pwbConfirmPassword.Background = Brushes.White;
            txtUserName.Background = Brushes.White;
            txtFirstName.Background = Brushes.White;
            txtLastName.Background = Brushes.White;
            txtPhone.Background = Brushes.White;
            txtEmailAddress.Background = Brushes.White;

            lblConfirmPasswordWarning.Visibility = Visibility.Hidden;
            lblEmailWarning.Visibility = Visibility.Hidden;
            lblUserWarning.Visibility = Visibility.Hidden;
            lblPasswordWarning.Visibility = Visibility.Hidden;
            lblPhoneWarning.Visibility = Visibility.Hidden;
            lblFirstNameWarning.Visibility = Visibility.Hidden;
            lblLastNameWarning.Visibility = Visibility.Hidden;

            result = _userManager.CreateNewUser(_user, pwbPassword.Password,pwbConfirmPassword.Password);
            if (result.Equals("Created"))
            {
                this.DialogResult = true;
                lblConfirmPasswordWarning.Visibility = Visibility.Hidden;
                lblEmailWarning.Visibility = Visibility.Hidden;
                lblUserWarning.Visibility = Visibility.Hidden;
                lblPasswordWarning.Visibility = Visibility.Hidden;
                lblPhoneWarning.Visibility = Visibility.Hidden;
                lblFirstNameWarning.Visibility = Visibility.Hidden;
                lblLastNameWarning.Visibility = Visibility.Hidden;


            }
            else if (result.Equals("Invalid Username"))
            {
                txtUserName.Background = Brushes.Red;
                lblUserWarning.Content = "Invalid Username";
                lblUserWarning.Visibility = Visibility.Visible;
            }
            else if (result.Equals("Used Username"))
            {
                txtUserName.Background = Brushes.Red;
                lblUserWarning.Content = "Username already used";
                lblUserWarning.Visibility = Visibility.Visible;
            }
            else if (result.Equals("Invalid Password"))
            {
                pwbPassword.Background = Brushes.Red;
                lblPasswordWarning.Content = "Invalid Password";
                lblPasswordWarning.Visibility = Visibility.Visible;
            }
            else if (result.Equals("Password No Match"))
            {
                pwbPassword.Background = Brushes.Red;
                pwbConfirmPassword.Background = Brushes.Red;
                lblConfirmPasswordWarning.Content = "Passwords do not match";
                lblConfirmPasswordWarning.Visibility = Visibility.Visible;
            }

            else if (result.Equals("Invalid FirstName"))
            {
                txtFirstName.Background = Brushes.Red;
                lblFirstNameWarning.Content = "Must be at between 2 and 50 letters long";
                lblFirstNameWarning.Visibility = Visibility.Visible;
            }
            else if (result.Equals("Invalid LastName"))
            {
                txtLastName.Background = Brushes.Red;
                lblLastNameWarning.Content = "Must be at between 2 and 50 letters long";
                lblLastNameWarning.Visibility = Visibility.Visible;
            }
            else if (result.Equals("Invalid Phone"))
            {
                txtPhone.Background = Brushes.Red;
                lblPhoneWarning.Content = "ex. 1234567890";
                lblPhoneWarning.Visibility = Visibility.Visible;
            }
            else if (result.Equals("Used Email"))
            {
                txtEmailAddress.Background = Brushes.Red;
                lblEmailWarning.Content = "Email already used";
                lblEmailWarning.Visibility = Visibility.Visible;
            }
            else if (result.Equals("Invalid Email"))
            {
                txtEmailAddress.Background = Brushes.Red;
                lblEmailWarning.Content = "Invalid Email";
                lblEmailWarning.Visibility = Visibility.Visible;
            }

        }


        private void btnCancelCreateNewUser_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}