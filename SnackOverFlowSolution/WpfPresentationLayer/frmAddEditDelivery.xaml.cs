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
using LogicLayer;
namespace WpfPresentationLayer
{
    /// <summary>
    /// Interaction logic for frmAddEditDelivery.xaml
    /// </summary>
    public partial class frmAddEditDelivery : Window
    {
        IStatusManager _statusManager;
        IDeliveryTypeManager _deliveryTypeManager;
        IDeliveryManager _deliveryManager;
        bool _isEdit;
        Delivery _delivery;
        public frmAddEditDelivery(Delivery delivery, IDeliveryManager deliveryManager, bool isEdit = false)
        {
            InitializeComponent();
            _deliveryManager = deliveryManager;
            _statusManager = new StatusManager();
            _deliveryTypeManager = new DeliveryTypeManager();
            _delivery = delivery;
            _isEdit = isEdit;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                comBoxStatus.ItemsSource = _statusManager.RetrieveStatusList();
                comBoxType.ItemsSource = _deliveryTypeManager.RetrieveDeliveryTypeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }

            if (_isEdit)
            {
                dtpckDeliveryDate.SelectedDate = _delivery.DeliveryDate;
                comBoxStatus.SelectedItem = _delivery.StatusId;
                comBoxType.SelectedItem = _delivery.DeliveryTypeId;
                lblAddEditDelivery.Content = "Edit Delivery";
                this.Title = "Edit Delivery";
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_isEdit)
            {
                Delivery newDelivery = new Delivery()
                {
                    DeliveryDate = dtpckDeliveryDate.SelectedDate,
                    DeliveryTypeId = (string)comBoxType.SelectedItem,
                    StatusId = (string)comBoxStatus.SelectedItem,
                    Verification = _delivery.Verification,
                    RouteId = _delivery.RouteId,
                    PackageList = _delivery.PackageList,
                    DeliveryId = _delivery.DeliveryId,
                    OrderId = _delivery.OrderId
                };
                try
                {
                    var result = _deliveryManager.UpdateDelivery(_delivery, newDelivery);
                    if (result)
                    {
                        this.DialogResult = true;
                        MessageBox.Show("Delivery Successfully updated.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Update failed.");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
                }
            }
            else
            {
                throw new NotSupportedException("Adding stuff hasn't been implemented yet.");
            }
        }

    }
}
