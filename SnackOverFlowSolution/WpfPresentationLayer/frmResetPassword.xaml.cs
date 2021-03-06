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
    /// Interaction logic for ResetPassword.xaml
    /// </summary>
    public partial class frmResetPassword : Window
    {
        List<User> _users;
        IUserManager _userManager;

        /// <summary>
        /// Alissa Duffy
        /// Updated: 2017/04/21
        /// 
        /// Initialize Reset Password Window.
        /// Standardized method.
        /// </summary>
        /// <param name="_userManager"></param>
        /// <param name="_users"></param>
        public frmResetPassword(IUserManager _userManager, List<User> _users)
        {
            this._userManager = _userManager;
            InitializeComponent();
            this._users = _users;
            cboUsers.ItemsSource = this._users;
        }
        /// <summary>
        /// Alissa Duffy
        /// Updated: 2017/04/21
        /// 
        /// Updates Password.
        /// Standardized method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (1 == _userManager.ResetPassword((String)_users[cboUsers.SelectedIndex].UserName, pwbPassword.Text))
                {
                    MessageBox.Show("User Password Changed");
                }
                else
                {
                    MessageBox.Show("Change failed.  Was the user deleted?");
                }
            }
            catch (Exception ex)
            {
                if (null != ex.InnerException)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// Alissa Duffy
        /// Updated: 2017/04/21
        /// 
        /// Generates Password.
        /// Standardized method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            pwbPassword.Text = _userManager.NewPassword();
        }
    }
}
