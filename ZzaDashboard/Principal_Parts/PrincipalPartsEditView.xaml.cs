using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ZzaDashboard.Principal_Parts
{
    public partial class PrincipalPartsEditView : UserControl
    {
        public PrincipalPartsEditView()
        {
            InitializeComponent();
        }

        public Guid CustomerId
        {
            get { return (Guid)GetValue(CustomerIdProperty); }
            set { SetValue(CustomerIdProperty, value); }
        }

        public static readonly DependencyProperty CustomerIdProperty =
            DependencyProperty.Register("CustomerId", typeof(Guid), 
            typeof(PrincipalPartsEditView), new PropertyMetadata(Guid.Empty));
    }
}
