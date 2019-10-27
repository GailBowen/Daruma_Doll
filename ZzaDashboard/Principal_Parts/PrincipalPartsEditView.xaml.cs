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

        public Guid PrincipalPartId
        {
            get { return (Guid)GetValue(PrincipalPartIdProperty); }
            set { SetValue(PrincipalPartIdProperty, value); }
        }

        public static readonly DependencyProperty PrincipalPartIdProperty =
            DependencyProperty.Register("PrincipalPartId", typeof(Guid), 
            typeof(PrincipalPartsEditView), new PropertyMetadata(Guid.Empty));
    }
}
